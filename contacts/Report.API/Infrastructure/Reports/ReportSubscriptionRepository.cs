using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SharedLibrary;
using Report.API.Model;
using Report.API;

namespace Contact.API.Infrastructure.Reports
{
    public class ReportSubscriptionRepository : IReportSubscriptionRepository, IDisposable
    {
        public ReportSubscriptionRepository()
        {
            var client = new MongoClient(Startup.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(Startup.Configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            LocationReports = database.GetCollection<LocationReport>(Startup.Configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }

        public IMongoCollection<LocationReport> LocationReports { get; }

        public async Task<IEnumerable<LocationReport>> Get(BaseRequest model)
        {
            var sortt = Builders<LocationReport>.Sort.Ascending(x => x.CreatedOn);

            var data = await LocationReports.Find(c => true)
                .Sort(sortt)
                .Skip((model.PageNumber - 1) * model.PageSize)
                .Limit(model.PageSize)
                .ToListAsync();

            return data;
        }

        public async Task<LocationReport> Get(Guid id)
        {
            return await LocationReports.Find(c => c.UUID == id).FirstOrDefaultAsync();
        }

        public async Task<LocationReport> Create(LocationReport model)
        {
            await LocationReports.InsertOneAsync(model);
            return model;
        }

        public void Dispose()
        {
        }
    }
}
