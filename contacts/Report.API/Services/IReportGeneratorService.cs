using SharedLibrary;
using SharedLibrary.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.API.Services
{
    public interface IReportGeneratorService
    {
        Task<List<LocationReportModel>> GetList(BaseRequest request);
        Task<LocationReportModel> Get(string reportId);
        Task<LocationReportModel> Generate();
    }
}
