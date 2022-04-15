using Report.API.Model;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.API.Services
{
    public interface IReportGeneratorService
    {
        Task<List<LocationReport>> GetList(BaseRequest request);
        Task<LocationReport> Get(System.Guid reportId);
        Task<Guid> Generate();
    }
}
