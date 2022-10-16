using AutoMapper;
using Obioha_WebAPP.Models.DTO;

namespace Obioha_WebAPP.Configuration
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
           
            CreateMap<HouseDTO, HouseCreateDTO>().ReverseMap();
            CreateMap<HouseDTO, HouseUpdateDTO>().ReverseMap();

           
            CreateMap<TenantDTO, TenantCreateDTO>().ReverseMap();
            CreateMap<TenantDTO, TenantUpdateDTO>().ReverseMap();
        }
    }
}
