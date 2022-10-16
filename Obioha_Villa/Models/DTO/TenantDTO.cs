using System.ComponentModel.DataAnnotations;

namespace Obioha_VillaAPI.Models.DTO
{
    public class TenantDTO
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string Nationality { get; set; }
        [Required]
        public int House_Id { get; set; }
        public House House { get; set; }
        public string Marriage_Status { get; set; }
        public int No_Of_kids { get; set; }
        public string Tenancy_Period { get; set; }
        public string Tenancy_Start_Date { get; set; }
        public string Tenancy_End_Date { get; set; }
        public string Move_in_date { get; set; }
        public Decimal Deposite_Amount { get; set; }




    }
}
