using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Controllers;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SimpleInjector.Integration.AspNetCore;
using BarbecueManager.Patterns.Net.Middleware;
using Swashbuckle;
using Swashbuckle.AspNetCore.Swagger;

namespace BarbecueManager.Api
{
    public class Startup
    {
        private Container container = new Container();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds services required for using options.
            services.AddOptions();

            services.AddMvc();

            //Add Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "BarbecueManager API",
                    Description = "Let's make a barbecue!",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "BarbecueManager", Url = "www.msampaio.com" }
                });
            });

            //services.AddSwaggerGen();
            //services.ConfigureSwaggerGen(options =>
            //{
            //    options.AddSecurityDefinition("oauth2", new Swashbuckle.Swagger.Model.ApiKeyScheme()
            //    {
            //        Name = "Authorization",
            //        In = "header",
            //        Type = "apiKey"

            //    });

            //    options.SingleApiVersion(new Info
            //    {
            //        Version = "v1",
            //        Title = "Boilerplate API",
            //        Description = "Description here",
            //        TermsOfService = "None",
            //        Contact = new Contact { Name = "Plataforma CORE", Url = "www.plataformacore.com.br" }
            //    });
            //});

            services.UseSimpleInjectorAspNetRequestScoping(container);

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseForwardedHeaders();

            app.UseMiddleware(typeof(ErrorMiddleware));

            //Dependency Injection
            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            InitializeContainer(app);
            container.Verify();

            app.UseMvc();

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Host = httpReq.Host.Value);
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Lifestyle.Transient - Por instanciação
            // Lifestyle.Scoped - Por requisição
            // Lifestyle.Singleton - Por inicialização
            // Lifestyle.Instance - Por inicialização

            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Patterns
            BarbecueManager.Patterns.Startup.Configure(container);

            //Authentication
            //BarbecueManager.Patterns.Net.Authentication.Startup.Configure(container);

            // Application
            BarbecueManager.Application.Startup.Configure(container);

            // Domain
            BarbecueManager.Domain.Startup.Configure(container);

            // Infraestrucure
            BarbecueManager.Infrastructure.Startup.Configure(container);

            // Cross-wire ASP.NET services (if any). For instance:
            container.RegisterSingleton(app.ApplicationServices.GetService<ILoggerFactory>());
            // NOTE: Prevent cross-wired instances as much as possible.
            // See: https://simpleinjector.org/blog/2016/07/


            //Bus RabbitMQ
            //Core.Patterns.Bus.Startup.Configure(container);

            //EventSource deve ser a ultima coisa a configurar.
            //Core.Boilerplate.Domain.Startup.SubscribeOnBus(container);
        }
    }
}
