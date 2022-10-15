using AutoMapper;
using Obioha_VillaAPI.Models;
using Obioha_VillaAPI.Models.DTO;

namespace Obioha_VillaAPI.Configuration
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<House, HouseDTO>().ReverseMap();
            CreateMap<House, HouseCreateDTO>().ReverseMap();
            CreateMap<House, HouseUpdateDTO>().ReverseMap();

            CreateMap<Tenant, TenantDTO>().ReverseMap();
            CreateMap<Tenant, TenantCreateDTO>().ReverseMap();
            CreateMap<Tenant, TenantUpdateDTO>().ReverseMap();
        }
    }
}
