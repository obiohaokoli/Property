using System.ComponentModel.DataAnnotations;

namespace Obioha_WebAPP.Models.DTO
{
    public class ImageDTO
    {
        public int Image_Id { get; set; }
        public string fileName { get; set; }
        [Required]
        public int House_Id { get; set; }
        public string? Image_Description { get; set; }
    }
}
