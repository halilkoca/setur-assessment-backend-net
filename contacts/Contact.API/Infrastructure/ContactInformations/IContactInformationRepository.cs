using Contact.API.Model;
using MongoDB.Driver;

namespace Contact.API.Infrastructure.ContactInformations
{
    public interface IContactInformationRepository
    {
        IMongoCollection<ContactModel> Contacts { get; }
    }
}
