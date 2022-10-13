using System.ComponentModel.DataAnnotations;

namespace Obioha_VillaAPI.Models.DTO
{
    public class VillaDTO
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public int Sqtf { get; set; }
        public int Occupancy { get; set; }
    }
}
