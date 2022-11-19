using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Obioha_WebAPP.Models.DTO;

namespace Obioha_WebAPP.Models.ViewModel
{
    public class HouseUpdateVM
    {
        public HouseUpdateVM()
        {
            UpdateHouse = new HouseUpdateDTO();
            UpdateImageList = new List<ImageUpdateDTO>();
         
           

        }
        public HouseUpdateDTO UpdateHouse { get; set; }
        [ValidateNever]
        public List<ImageUpdateDTO> UpdateImageList { get; set; }
       
       
        
    }
}
