using Obioha_WebAPP.Models.DTO;

namespace Obioha_WebAPP.Models.ViewModel
{
    public class HouseVM
    {
        public HouseVM()
        {
            houseDTO = new HouseDTO();
            imageList = new List<ImageDTO>();
            files = new List<IFormFile>();
        }
        public HouseDTO houseDTO { get; set; }

      public  List<IFormFile> files { get; set; }
      public  List<ImageDTO> imageList { get; set; }
    }
}
