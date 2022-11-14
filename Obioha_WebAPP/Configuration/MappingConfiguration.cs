using AutoMapper;
using Obioha_WebAPP.Models.DTO;
using Obioha_WebAPP.Models.ViewModel;

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

            CreateMap<HouseCreateVM, HouseUpdateVM>().ReverseMap();

            CreateMap<ImageDTO, ImageCreateDTO>().ReverseMap();
            CreateMap<ImageDTO, ImageCreateDTO> ().ReverseMap();
        }
    }
}
