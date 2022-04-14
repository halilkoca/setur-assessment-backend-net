using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Contact.API.Model;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SharedLibrary;

namespace Contact.API.Infrastructure.Contacts
{
    public class ContactRepository : IContactRepository, IDisposable
    {
        public ContactRepository()
        {
            var client = new MongoClient(Startup.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(Startup.Configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Contacts = database.GetCollection<ContactModel>(Startup.Configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }

        public IMongoCollection<ContactModel> Contacts { get; }

        public async Task<IEnumerable<ContactModel>> Get(BaseRequest model)
        {
            var sortt = Builders<ContactModel>.Sort.Ascending(x => x.Name);

            var data = await Contacts.Find(c => true)
                .Sort(sortt)
                .Skip((model.PageNumber - 1) * model.PageSize)
                .Limit(model.PageSize)
                .ToListAsync();
            return data;
        }

        public async Task<ContactModel> Get(string id)
        {
            return await Contacts.Find(c => c.UUID == id).FirstOrDefaultAsync();
        }

        public async Task<ContactModel> GetByName(string name)
        {
            FilterDefinition<ContactModel> filter = Builders<ContactModel>.Filter.Eq(p => p.Name, name);
            return await Contacts.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<ContactModel> Create(ContactModel model)
        {
            await Contacts.InsertOneAsync(model);
            return model;
        }

        public async Task<List<ContactModel>> Create(List<ContactModel> models)
        {
            await Contacts.InsertManyAsync(models);
            return models;
        }

        public async Task<ContactModel> Update(ContactModel model)
        {
            await Contacts.ReplaceOneAsync(c => c.UUID == model.UUID, model);
            return model;
        }

        public async Task<bool> Delete(string id)
        {
            DeleteResult result = await Contacts.DeleteOneAsync(x => x.UUID == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<bool> Delete(List<string> ids)
        {
            DeleteResult result = await Contacts.DeleteManyAsync(x => ids.Contains(x.UUID));
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public void Dispose()
        {
        }
    }
}
