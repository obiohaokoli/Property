using System.ComponentModel.DataAnnotations;

namespace Obioha_WebAPP.Models.DTO
{
    public class TenantCreateDTO
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        [Required]
        public int House_Id { get; set; }
        public string Nationality { get; set; }
        public string Marriage_Status { get; set; }

        [Range(0,5,ErrorMessage ="This is between 0 to 5")]
        public int No_Of_kids { get; set; }
        public string? Imageurl { get; set; }
        public string Tenancy_Period { get; set; }
        public DateTime Tenancy_Start_Date { get; set; }
        public DateTime Tenancy_End_Date { get; set; }
        public DateTime Move_in_date { get; set; }
        public Decimal Deposite_Amount { get; set; }





    }
}
