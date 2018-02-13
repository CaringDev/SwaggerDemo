using System;
using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json.Converters;

using Swashbuckle.AspNetCore.Swagger;

namespace SwaggerDemo.WebAPI
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
            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters()
                .AddJsonOptions(_ => { _.SerializerSettings.Converters.Add(new StringEnumConverter()); });

            services.AddSwaggerGen(
                _ =>
                    {
                        _.SwaggerDoc("v1", new Info { Title = "WebAPI", Version = "v1", Contact = new Contact { Name = "CaringDev" } });
                        _.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WebAPI.xml"));
                        _.IgnoreObsoleteActions();
                        _.DescribeAllEnumsAsStrings();
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UseSwaggerUI(
                        _ =>
                            {
                                _.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI V1");
                                _.ShowJsonEditor();
                                _.EnabledValidator();
                            });
            }

            app
                .UseMvc()
                .UseSwagger();
        }
    }
}