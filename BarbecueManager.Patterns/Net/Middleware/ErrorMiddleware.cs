using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BarbecueManager.Patterns.Net.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger _logger;

        public ErrorMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            _logger = loggerFactory.CreateLogger<ErrorMiddleware>();
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                try
                {
                    await HandleExceptionAsync(context, ex);
                }
                catch (Exception ex2)
                {
                    _logger.LogError(0, ex2, "An exception was thrown attempting to execute the error handler.");
                    throw;
                }
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            List<object> listErrors = new List<object>();

            string result = string.Empty;

            if (exception is FluentValidation.ValidationException)
            {
                var validationException = (FluentValidation.ValidationException)exception;

                foreach (var currentError in validationException.Errors)
                {
                    listErrors.Add(new
                    {
                        PropertyName = currentError.PropertyName,
                        ErrorMessage = currentError.ErrorMessage,
                    });
                }

                result = JsonConvert.SerializeObject(new { Errors = listErrors });
                code = HttpStatusCode.BadRequest;
            }
            else if (exception is Exception)
            {
                result = JsonConvert.SerializeObject(exception);
                code = HttpStatusCode.InternalServerError;
            }
            //if (exception is MyNotFoundException)
            //    code = HttpStatusCode.NotFound;
            //else if (exception is MyUnauthorizedException)
            //    code = HttpStatusCode.Unauthorized;
            //else if (exception is MyException)
            //    code = HttpStatusCode.BadRequest;

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                await context.Response.WriteAsync(result);
            }
        }
    }
}