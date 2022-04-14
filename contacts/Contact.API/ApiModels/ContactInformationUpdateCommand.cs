using Contact.API.Model;

namespace Contact.API.ApiModels
{
    public class ContactInformationUpdateCommand
    {
        public InformationType Type { get; set; }
        public string Value { get; set; }
    }
}
