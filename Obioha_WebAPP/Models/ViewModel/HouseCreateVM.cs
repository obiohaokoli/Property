using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Obioha_WebAPP.Models.DTO;

namespace Obioha_WebAPP.Models.ViewModel
{
    public class HouseCreateVM
    {
        public HouseCreateVM()
        {
             GetHouse = new HouseCreateDTO();
            ImageList = new List<ImageCreateDTO>();
            files = new List<IFormFile>();
                
        }
        public HouseCreateDTO GetHouse { get; set; }
        [ValidateNever]
        public List<ImageCreateDTO> ImageList { get; set; }

        [ValidateNever]
       public List<IFormFile> files { get; set; }
 
    }
}
