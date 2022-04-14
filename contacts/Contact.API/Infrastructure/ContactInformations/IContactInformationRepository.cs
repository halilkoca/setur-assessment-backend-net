using Contact.API.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.API.Infrastructure.ContactInformations
{
    public interface IContactInformationRepository
    {
        IMongoCollection<ContactModel> Contacts { get; }

        Task<ContactInformationModel> Create(string id, ContactInformationModel model);
        Task<bool> Update(string id, ContactInformationModel model);
        Task<bool> Delete(string id, string informationId);
        Task<bool> Delete(string id, List<string> informationIds);
    }
}
