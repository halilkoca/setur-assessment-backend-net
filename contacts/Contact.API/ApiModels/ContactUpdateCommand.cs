using Contact.API.Model;

namespace Contact.API.ApiModels
{
    public class ContactUpdateCommand
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
    }
}
