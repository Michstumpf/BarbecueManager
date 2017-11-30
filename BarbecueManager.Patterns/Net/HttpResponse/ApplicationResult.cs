using BarbecueManager.Patterns.Application.Messages;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;
using System.IO;

namespace BarbecueManager.Patterns.Net.HttpResponse
{
    public class ApplicationResult<TEntity> : ActionResult
         where TEntity : class
    {
        private string ContentResponse { get; set; }
        private int StatusCodeResponse { get; set; }

        public InsertResponse<TEntity> InsertResponse { get; set; }


        public List<ValidationFailure> Errors { get; set; }


        public ApplicationResult(InsertResponse<TEntity> insertResponse)
        {
            var objResult = new
            {
                Payload = insertResponse.Payload,
            };
            StatusCodeResponse = insertResponse.StatusCode;

            ContentResponse = JsonConvert.SerializeObject(objResult, this.GetJsonSettings());
        }

        public ApplicationResult(UpdateResponse<TEntity> updateResponse)
        {
            var objResult = new
            {
                Payload = updateResponse.Payload,
            };
            StatusCodeResponse = updateResponse.StatusCode;

            ContentResponse = JsonConvert.SerializeObject(objResult, this.GetJsonSettings());
        }

        public ApplicationResult(DeleteResponse<TEntity> deleteResponse)
        {
            var objResult = new
            {
                Payload = deleteResponse.Payload,
            };
            StatusCodeResponse = deleteResponse.StatusCode;

            ContentResponse = JsonConvert.SerializeObject(objResult, this.GetJsonSettings());
        }

        public ApplicationResult(QueryResponse<TEntity> identityResponse)
        {
            var objResult = new
            {
                Payload = identityResponse.Payload,
            };
            StatusCodeResponse = identityResponse.StatusCode;

            ContentResponse = JsonConvert.SerializeObject(objResult, this.GetJsonSettings());
        }

        public ApplicationResult(QueryResponse<TEntity[]> queryResponse)
        {
            var objResult = new
            {
                Payload = queryResponse.Payload,
            };
            StatusCodeResponse = queryResponse.StatusCode;

            ContentResponse = JsonConvert.SerializeObject(objResult, this.GetJsonSettings());
        }


        private JsonSerializerSettings GetJsonSettings()
        {
            return new JsonSerializerSettings()
            {
                Converters = new JsonConverter[] { new StringEnumConverter() { CamelCaseText = false } },
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        protected ApplicationResult()
        {
        }

        //public override 
        public override void ExecuteResult(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodeResponse;
            context.HttpContext.Response.ContentType = "application/json";

            var xmlBytes = Encoding.UTF8.GetBytes(ContentResponse);
            context.HttpContext.Response.Body.WriteAsync(xmlBytes, 0, xmlBytes.Length);

            base.ExecuteResult(context);
        }

        private string Serialize<T>(T value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var type = value.GetType();
            JsonSerializer serializer = new JsonSerializer();

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, value);
                return writer.ToString();
            }
        }
    }
}
