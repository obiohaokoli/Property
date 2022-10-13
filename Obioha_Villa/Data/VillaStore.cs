using Obioha_VillaAPI.Models.DTO;

namespace Obioha_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> VillaList =
        
            new List<VillaDTO>()
            {
                new VillaDTO() { Id = 1, Name = "pool villa" , Sqtf = 100, Occupancy = 4 },
                new VillaDTO() { Id = 2, Name = "Mesh villa", Sqtf = 120, Occupancy = 6}
            };
        
    }
}
