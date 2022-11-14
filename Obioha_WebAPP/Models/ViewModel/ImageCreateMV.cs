using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Obioha_WebAPP.Models.DTO;

namespace Obioha_WebAPP.Models.ViewModel
{
    public class ImageCreateVM
    {

     
        public ImageCreateDTO ImageList { get; set; }
       
        public IFormFile? file { get; set; }
    }
}
