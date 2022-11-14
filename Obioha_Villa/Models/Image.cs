using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obioha_VillaAPI.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Image_Id { get; set; }
        public string fileName { get; set; }
        [Required]
        [ForeignKey("House")]
        public int House_Id { get; set; }
        public House House { get; set; }
        public string? Image_Description { get; set; }
    }
}
