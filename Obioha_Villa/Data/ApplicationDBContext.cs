using Microsoft.EntityFrameworkCore;
using Obioha_VillaAPI.Models;

namespace Obioha_VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
            : base(option)
        { }


       public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        
        {
            modelBuilder.Entity<House>().HasData(
                new House()
                {
                    Id = 1,
                    Name = "Manchester_One",
                    Built_Date = new DateTime(1960 - 10 - 01),
                    No_Of_Bedrooms = 3,
                    No_Of_Toilets = 2,
                    Occupancy = 4,
                    Property_Type = "End Terraced House",
                    Purchase_Cost = 125000,
                    Current_Cost= 190000,
                    Purpose = "Buy to Let",
                    Sitting_Rooms_No = 2,
                    Square_Feet = 75,
                    ImageUrl = "Manchester.jpg",
                    Purchased_Date = new DateTime(2021 - 06 - 21),
                    Created_Date = DateTime.Now,
                    Updated_Date = DateTime.Now

                },
                 new House()
                 {
                     Id = 2,
                     Name = "Derby_One",
                     Built_Date = new DateTime(1980 - 10 - 01),
                     No_Of_Bedrooms = 2,
                     No_Of_Toilets = 1,
                     Occupancy = 1,
                     Property_Type = "End Terraced House",
                     Purchase_Cost = 121500,
                     Current_Cost = 132000,
                     Purpose = "Buy to Let",
                     Sitting_Rooms_No = 2,
                     Square_Feet = 75,
                     ImageUrl = "Derby.jpg",
                     Purchased_Date = new DateTime(2022 - 10 - 30),
                     Created_Date = DateTime.Now,
                     Updated_Date = DateTime.Now

                 });
        }

    }
}
