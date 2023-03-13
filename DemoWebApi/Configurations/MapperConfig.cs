using AutoMapper;
using WebApi.Domain.AuthModels;
using WebApi.Domain.DataModels;

namespace DemoWebApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<ContactDetails,ContactDTO>().ReverseMap();
            CreateMap<ContactDetails, ContactInformation>().ReverseMap();
            CreateMap<LoginInfo, LoginDTO>().ReverseMap();
            CreateMap<RegisterDetails,RegisterDetailsDTO>().ReverseMap();
        
        }
    }
}
