using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NJsonSchema;

using Newtonsoft.Json.Converters;

using NSwag.AspNetCore;

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage().UseSwaggerUi(
                    typeof(Startup).Assembly,
                    s =>
                        {
                            s.GeneratorSettings.DefaultEnumHandling = EnumHandling.String;
                            s.UseJsonEditor = true;
                        });
            }

            app.UseMvc();
        }
    }
}