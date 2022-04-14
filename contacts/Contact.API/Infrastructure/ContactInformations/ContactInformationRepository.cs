using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Contact.API.Model;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Linq;

namespace Contact.API.Infrastructure.ContactInformations
{
    public class ContactInformationRepository : IContactInformationRepository, IDisposable
    {
        public ContactInformationRepository()
        {
            var client = new MongoClient(Startup.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(Startup.Configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Contacts = database.GetCollection<ContactModel>(Startup.Configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }

        public IMongoCollection<ContactModel> Contacts { get; }

        public async Task<ContactInformationModel> Create(string id, ContactInformationModel model)
        {
            var contact = Contacts.AsQueryable().Where(x => x.UUID == id).FirstOrDefault();
            if (contact == null)
                throw new NullReferenceException("Contact Does Not Exist");

            model.UUID = ObjectId.GenerateNewId().ToString();
            contact.ContactInformations.Add(model);
            await Contacts.ReplaceOneAsync(c => c.UUID == id, contact);

            return model;
        }

        public async Task<bool> Update(string id, ContactInformationModel model)
        {
            var filter = Builders<ContactModel>.Filter.Eq(x => x.UUID, id)
                & Builders<ContactModel>.Filter
                .ElemMatch(x => x.ContactInformations, Builders<ContactInformationModel>
                .Filter.Eq(x => x.UUID, model.UUID));
            var update = Builders<ContactModel>.Update.Set("ContactInformations.$.Value", model.Value);
            var result = await Contacts.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id, string informationId)
        {
            var update = Builders<ContactModel>.Update.PullFilter(p => p.ContactInformations, f => f.UUID == informationId);
            var result = await Contacts.FindOneAndUpdateAsync(p => p.UUID == id, update);
            return true;
        }

        public async Task<bool> Delete(string id, List<string> informationIds)
        {
            var update = Builders<ContactModel>.Update.PullFilter(p => p.ContactInformations, f => informationIds.Contains(f.UUID));
            var result = await Contacts.FindOneAndUpdateAsync(p => p.UUID == id, update);
            return true;
        }

        public void Dispose() { }
    }
}
