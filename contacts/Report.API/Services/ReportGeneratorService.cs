using Contact.API.Infrastructure.Reports;
using Report.API.Model;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.API.Services
{
    public class ReportGeneratorService : IReportGeneratorService
    {
        private readonly ILocationReportRepository _locationReportRepository;

        public ReportGeneratorService(ILocationReportRepository locationReportRepository)
        {
            _locationReportRepository = locationReportRepository ?? throw new ArgumentNullException(nameof(locationReportRepository));
        }

        public Task<Guid> Generate()
        {

            _locationReportRepository.Create();

            throw new NotImplementedException();
        }

        public Task<LocationReport> Get(Guid reportId)
        {
            throw new NotImplementedException();
        }

        public Task<List<LocationReport>> GetList(BaseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
