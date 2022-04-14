using Contact.API.Model;
using MongoDB.Driver;
using SharedLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.API.Infrastructure.Contacts
{
    public interface IContactRepository
    {
        IMongoCollection<ContactModel> Contacts { get; }

        Task<IEnumerable<ContactModel>> Get(BaseRequest model);
        Task<ContactModel> Get(string id);
        Task<ContactModel> GetByName(string name);
        Task<ContactModel> Create(ContactModel model);
        Task<List<ContactModel>> Create(List<ContactModel> models);
        Task<ContactModel> Update(ContactModel model);
        Task<bool> Delete(string id);
        Task<bool> Delete(List<string> ids);
    }
}
