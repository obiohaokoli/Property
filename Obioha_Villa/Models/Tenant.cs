using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Obioha_VillaAPI.Models
{
    public class Tenant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id{ get; set; }
        public string First_Name{ get; set; }
        public string? Middle_Name{ get; set; }
        public string Last_Name{ get; set; }
        public string Nationality { get; set; }
        public string? Marriage_Status{ get; set; }
        public int No_Of_kids { get; set; }
        public string? Imageurl { get; set; }
        public string Tenancy_Period { get; set; }

        [ForeignKey("House")]
        public int House_Id { get; set; }
        public House House { get; set; }
        public DateTime Tenancy_Start_Date { get; set; }
        public DateTime Tenancy_End_Date { get; set; }
        public DateTime Move_in_date { get; set; }
        public Decimal Deposite_Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

      




    }
}
