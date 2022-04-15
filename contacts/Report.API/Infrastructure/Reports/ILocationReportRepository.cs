using MongoDB.Driver;
using SharedLibrary;
using SharedLibrary.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.API.Infrastructure.Reports
{
    public interface ILocationReportRepository
    {
        IMongoCollection<LocationReportModel> LocationReports { get; }
        Task<List<LocationReportModel>> Get(BaseRequest model);
        Task<LocationReportModel> Get(Guid id);
        Task<LocationReportModel> Create(LocationReportModel model);
    }
}
