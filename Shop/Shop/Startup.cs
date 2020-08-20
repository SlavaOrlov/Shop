using Autofac;
using AutoMapper;
using Shop.Api.Configuration;
using Shop.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Shop
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
            if (!env.IsProduction())
            {
                builder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            }
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
            services.AddControllers(o =>
            {
                o.AllowEmptyInputInBodyModelBinding = true;
            });
            ConfigureDependencies(services);
            services.Configure<DatabaseOptions>(Configuration);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "HouseholdAppliancesStore.API", Version = "v1" });
                c.IncludeXmlComments(String.Format(@"{0}\Swagger.XML", AppDomain.CurrentDomain.BaseDirectory));
            });
        }

        protected virtual void ConfigureDependencies(IServiceCollection services)
        { }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }
    }
}
