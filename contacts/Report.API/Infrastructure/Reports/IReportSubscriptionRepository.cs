using MongoDB.Driver;
using Report.API.Model;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.API.Infrastructure.Reports
{
    public interface IReportSubscriptionRepository
    {
        IMongoCollection<LocationReport> LocationReports { get; }

        Task<IEnumerable<LocationReport>> Get(BaseRequest model);
        Task<LocationReport> Get(Guid id);
        Task<LocationReport> Create(LocationReport model);
    }
}
