using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obioha_VillaAPI.Migrations
{
    public partial class SeedingDataInTheHouseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Built_Date", "Created_Date", "ImageUrl", "Name", "No_Of_Bedrooms", "No_Of_Toilets", "Occupancy", "Property_Type", "Purchase_Cost", "Purchased_Date", "Purpose", "Sitting_Rooms_No", "Square_Feet", "Updated_Date" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1949), new DateTime(2022, 10, 13, 22, 25, 9, 396, DateTimeKind.Local).AddTicks(6514), "Manchester.jpg", "Manchester_One", 3, 2, 4, "End Terraced House", 125000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1994), "Buy to Let", 2, 75, new DateTime(2022, 10, 13, 22, 25, 9, 396, DateTimeKind.Local).AddTicks(6550) });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Built_Date", "Created_Date", "ImageUrl", "Name", "No_Of_Bedrooms", "No_Of_Toilets", "Occupancy", "Property_Type", "Purchase_Cost", "Purchased_Date", "Purpose", "Sitting_Rooms_No", "Square_Feet", "Updated_Date" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1969), new DateTime(2022, 10, 13, 22, 25, 9, 396, DateTimeKind.Local).AddTicks(6554), "Derby.jpg", "Derby_One", 2, 1, 1, "End Terraced House", 121500.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1982), "Buy to Let", 2, 75, new DateTime(2022, 10, 13, 22, 25, 9, 396, DateTimeKind.Local).AddTicks(6556) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
