using Contact.API.Infrastructure.Reports;
using EventBus.Messages.Events;
using MassTransit;
using SharedLibrary;
using SharedLibrary.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.API.Services
{
    public class ReportGeneratorService : IReportGeneratorService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILocationReportRepository _locationReportRepository;

        public ReportGeneratorService() { }

        public ReportGeneratorService(IPublishEndpoint publishEndpoint, ILocationReportRepository locationReportRepository)
        {
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _locationReportRepository = locationReportRepository ?? throw new ArgumentNullException(nameof(locationReportRepository));
        }

        public async Task<LocationReportModel> Generate()
        {
            var newRecord = await _locationReportRepository.Create(new LocationReportModel { CreatedOn = DateTime.UtcNow, Status = ReportStatus.Preparing });
            LocationReportDetail locationReportDetail = new() { Id = newRecord.UUID };

            await _publishEndpoint.Publish(new LocationReportEvent { LocationReportDetail = locationReportDetail });

            return newRecord;
        }

        public async Task<LocationReportModel> Get(string reportId)
        {
            return await _locationReportRepository.Get(reportId);
        }

        public async Task<List<LocationReportModel>> GetList(BaseRequest request)
        {
            return await _locationReportRepository.Get(request);
        }
    }
}
