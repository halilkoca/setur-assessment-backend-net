using Contact.API.EventBusConsumer;
using Contact.API.Infrastructure.ContactInformations;
using Contact.API.Infrastructure.Contacts;
using Contact.API.Infrastructure.Reports;
using EventBus.Messages.Constants;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Contact.API
{
    public class Startup
    {
        private IConfigurationRoot _conf { get; }
        private readonly IWebHostEnvironment _env;
        public static IConfiguration Configuration;

        public Startup(IWebHostEnvironment env)
        {
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
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactInformationRepository, ContactInformationRepository>();
            services.AddScoped<ILocationReportRepository, LocationReportRepository>();

            services.AddAutoMapper(typeof(Startup));

          
            string rabbitMQConnectionString = Configuration.GetValue<string>("EventBusSettings:HostAddress");

            services.AddMassTransit(config =>
            {
                config.AddConsumer<LocationReportConsumer>();

                config.UsingRabbitMq((context, configuraiton) =>
                {
                    configuraiton.Host(rabbitMQConnectionString);
                    configuraiton.ReceiveEndpoint(EventBusContants.LocationReportQueue, c =>
                    {
                        c.ConfigureConsumer<LocationReportConsumer>(context);
                    });
                });
            });
            services.AddMassTransitHostedService();

            services.AddControllers()
              .AddFluentValidation(s =>
              {
                  s.RegisterValidatorsFromAssemblyContaining<Startup>();
              });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact.API", Version = "v1" });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact.API v1"));
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
