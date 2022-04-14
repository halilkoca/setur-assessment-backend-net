using System.Collections.Generic;

namespace Contact.API.Model
{
    public class ContactModel
    {
        public ContactModel()
        {
            ContactInformations = new HashSet<ContactInformationModel>();
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }


        public virtual ICollection<ContactInformationModel> ContactInformations { get; set; }
    }
}
