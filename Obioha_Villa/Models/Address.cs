using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Net;
using System.Numerics;

namespace Obioha_VillaAPI.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Address_Id { get; set; }
        public string? House_Number { get; set; }
        public string? Postal_Code { get; set; }
        public string? Street_Name { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string?   Country { get; set; }
        public string? Work_Phone { get; set; }
        public string? Home_Phone { get; set; }
        public string? Email { get; set; }

       }
}
