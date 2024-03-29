﻿using System.ComponentModel.DataAnnotations;

namespace Obioha_WebAPP.Models.DTO
{
    public class HouseCreateDTO
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int  Square_Feet { get; set; }
        public decimal Purchase_Cost { get; set; }
        public decimal Current_Cost { get; set; }
        public string? Property_Type { get; set; }
        public string? Purpose { get; set; }
        public int No_Of_Bedrooms { get; set; }
        public int Sitting_Room_No { get; set; }
        public int No_Of_Toilets { get; set; }
        public string? ImageUrl { get; set; }
        public int Occupancy { get; set; }
        public DateTime Purchased_Date { get; set; }
        public DateTime Built_Date { get; set; }

    }
}
