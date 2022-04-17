using Microsoft.Extensions.DependencyInjection;
using Report.API.Services;
using SharedLibrary.Model;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Report.API.Test
{
    public class LocationReportTest
    {
        IServiceProvider services;
        private readonly IReportGeneratorService _reportGeneratorService;

        public LocationReportTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMock<IReportGeneratorService>();
            services = serviceCollection.BuildServiceProvider();
            _reportGeneratorService = services.GetService<IReportGeneratorService>();
        }

        [Fact]
        public async Task Generate_Successfully()
        {
            var response = Setup_Model();
            services.GetMock<IReportGeneratorService>()
                .Setup(x => x.Generate())
                .Returns(Task.FromResult(response));

            await _reportGeneratorService.Generate();

        }

        private LocationReportModel Setup_Model()
        {
            return new LocationReportModel
            {
                UUID = "625bde1b3e26d37f227081ff",
                Status = ReportStatus.Preparing,
                CreatedOn = DateTime.UtcNow
            };
        }
    }
}
