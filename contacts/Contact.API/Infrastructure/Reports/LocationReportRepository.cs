using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using SharedLibrary.Model;
using Contact.API.Model;
using MongoDB.Driver.Linq;
using System.Linq;

namespace Contact.API.Infrastructure.Reports
{
    public class LocationReportRepository : ILocationReportRepository, IDisposable
    {
        public LocationReportRepository()
        {
            var client = new MongoClient(Startup.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(Startup.Configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Contacts = database.GetCollection<ContactModel>(Startup.Configuration.GetValue<string>("DatabaseSettings:ContactCollection"));
            LocationReports = database.GetCollection<LocationReportModel>(Startup.Configuration.GetValue<string>("DatabaseSettings:ReportCollection"));
        }

        public IMongoCollection<ContactModel> Contacts { get; }
        public IMongoCollection<LocationReportModel> LocationReports { get; }

        public async Task GenerateAndSave(Guid reportId)
        {
            var result = await Contacts.AsQueryable().Where(x =>
                x.ContactInformations.Any(a => a.Type == InformationType.Location)
                && x.ContactInformations.Any(a => a.Type == InformationType.PhoneNumber))
                .ToListAsync();

            var report = result
                .Select(x => new
                {
                    Location = x.ContactInformations.Where(b => b.Type == InformationType.Location).FirstOrDefault().Value,
                    LocationCount = x.ContactInformations.Where(a => a.Type == InformationType.Location).Count(),
                    PeopleCount = 1,
                    PhoneNumberCount = x.ContactInformations.Where(a => a.Type == InformationType.PhoneNumber).Count()
                })
                .GroupBy(b => b.Location)
                .Select(a => new LocationReportModel
                {
                    Location = a.Key,
                    LocationCount = a.Sum(b => b.LocationCount),
                    PeopleCount = a.Sum(b => b.PeopleCount),
                    PhoneNumberCount = a.Sum(b => b.PhoneNumberCount),
                    UUID = reportId,
                    CompletedOn = DateTime.UtcNow,
                    Status = ReportStatus.Completed
                })
                .OrderByDescending(a => a.LocationCount)
                .FirstOrDefault()
                ;

            await Update(report);
        }

        public async Task<LocationReportModel> Update(LocationReportModel model)
        {
            await LocationReports.ReplaceOneAsync(c => c.UUID == model.UUID, model);
            return model;
        }


        public void Dispose()
        {
        }
    }
}
