using MongoDB.Driver;
using SharedLibrary.Model;
using System;
using System.Threading.Tasks;

namespace Contact.API.Infrastructure.Reports
{
    public interface ILocationReportRepository
    {
        IMongoCollection<LocationReportModel> LocationReports { get; }
        Task GenerateAndSave(Guid reportId);
    }
}
