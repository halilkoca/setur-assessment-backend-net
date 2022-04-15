using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SharedLibrary;
using Report.API;
using SharedLibrary.Model;

namespace Contact.API.Infrastructure.Reports
{
    public class LocationReportRepository : ILocationReportRepository, IDisposable
    {
        public LocationReportRepository()
        {
            var client = new MongoClient(Startup.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(Startup.Configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            LocationReports = database.GetCollection<LocationReportModel>(Startup.Configuration.GetValue<string>("DatabaseSettings:ReportCollection"));
        }

        public IMongoCollection<LocationReportModel> LocationReports { get; }

        public async Task<List<LocationReportModel>> Get(BaseRequest model)
        {
            var sortt = Builders<LocationReportModel>.Sort.Ascending(x => x.CreatedOn);

            var data = await LocationReports.Find(c => true)
                .Sort(sortt)
                .Skip((model.PageNumber - 1) * model.PageSize)
                .Limit(model.PageSize)
                .ToListAsync();

            return data;
        }

        public async Task<LocationReportModel> Get(Guid id)
        {
            return await LocationReports.Find(c => c.UUID == id).FirstOrDefaultAsync();
        }

        public async Task<LocationReportModel> Create(LocationReportModel model)
        {
            await LocationReports.InsertOneAsync(model);
            return model;
        }
        public void Dispose() { }
    }
}
