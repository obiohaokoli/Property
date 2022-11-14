using Obioha_WebAPP.Models.DTO;

namespace Obioha_WebAPP.Models.ViewModel
{
    public class CreateVM
    {
        public List<ImageCreateDTO> CreateImages { get; set; }
        public List<IFormFile> files { get; set; }

        public CreateVM()
        {
            CreateImages = new List<ImageCreateDTO>();
            files = new List<IFormFile>();  
        }
    }
}
