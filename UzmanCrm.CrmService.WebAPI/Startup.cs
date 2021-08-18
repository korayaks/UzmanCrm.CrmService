using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.ExampleService.Mappings;
using UzmanCrm.CrmService.Application.Service.Utilities;
using UzmanCrm.CrmService.Infrastructure.Extensions;

namespace UzmanCrm.CrmService.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UzmanCrm.CrmService.WebAPI", Version = "v1" });
            });

            services.AddOptions();//addoptions for autofac
            Infrastructure.Extensions.ServiceCollectionExtensions.AutoMapperConfigure(services);//AutoMapper
            var settings = new ConnectionSettings(new Uri("http://elasticsearch:9200"));
            services.AddSingleton<IElasticClient>(new ElasticClient(settings));
        }
        


        public void ConfigureContainer(ContainerBuilder builder)//autofac function
        {
            builder.RegisterModule(new DependencyRegister());
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();              
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UzmanCrm.CrmService.WebAPI v1"));

            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
