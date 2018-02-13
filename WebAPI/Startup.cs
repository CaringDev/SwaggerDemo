using System;
using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                .AddJsonFormatters();
            services.AddSwaggerGen(
                _ =>
                    {
                        _.SwaggerDoc("v1", null);
                        _.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WebAPI.xml"));
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UseSwaggerUI(_ => { _.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI V1"); });
            }

            app
                .UseMvc()
                .UseSwagger();
        }
    }
}