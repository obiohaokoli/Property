using Obioha_VillaAPI.Models.DTO;

namespace Obioha_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<HouseDTO> VillaList =
        
            new List<HouseDTO>()
            {
                new HouseDTO() { Id = 1, Name = "pool villa" , Square_Feet= 100, Occupancy = 4 },
                new HouseDTO() { Id = 2, Name= "Mesh villa", Square_Feet = 120, Occupancy = 6}
            };
        
    }
}
