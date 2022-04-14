using AutoMapper;
using Contact.API.ApiModels;
using Contact.API.Model;

namespace Contact.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ContactCreateCommand, ContactModel>().ReverseMap();
            CreateMap<ContactInformationCreateCommand, ContactInformationModel>().ReverseMap();
        }
    }
}
