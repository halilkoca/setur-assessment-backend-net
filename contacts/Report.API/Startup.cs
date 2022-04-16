using Contact.API.Infrastructure.Reports;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Report.API.Services;

namespace Report.API
{
    public class Startup
    {
        private IConfigurationRoot _conf { get; }
        private readonly IWebHostEnvironment _env;
        public static IConfiguration Configuration;

        public Startup(IWebHostEnvironment env)
        {
            _env = env;

            _conf = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            Configuration = _conf;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IReportGeneratorService, ReportGeneratorService>();
            services.AddScoped<ILocationReportRepository, LocationReportRepository>();


            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((context, configuraiton) =>
                {
                    configuraiton.Host(Configuration.GetValue<string>("EventBusSettings:HostAddress"));
                });
            });
            services.AddMassTransitHostedService();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Report.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Report.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
