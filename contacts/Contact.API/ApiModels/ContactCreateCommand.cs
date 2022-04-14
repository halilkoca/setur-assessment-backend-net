using System.Collections.Generic;

namespace Contact.API.ApiModels
{
    public class ContactCreateCommand
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }

        public List<ContactInformationCreateCommand> ContactInformations { get; set; }

    }
}
