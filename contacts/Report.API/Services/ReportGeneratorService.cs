using Report.API.Model;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.API.Services
{
    public class ReportGeneratorService : IReportGeneratorService
    {
        public Task<Guid> Create()
        {
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
