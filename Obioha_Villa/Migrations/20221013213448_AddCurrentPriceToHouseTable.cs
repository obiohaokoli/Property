using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obioha_VillaAPI.Migrations
{
    public partial class AddCurrentPriceToHouseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Current_Cost", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 34, 47, 911, DateTimeKind.Local).AddTicks(7610), 190000.0, new DateTime(2022, 10, 13, 22, 34, 47, 911, DateTimeKind.Local).AddTicks(7642) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Current_Cost", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 34, 47, 911, DateTimeKind.Local).AddTicks(7645), 132000.0, new DateTime(2022, 10, 13, 22, 34, 47, 911, DateTimeKind.Local).AddTicks(7647) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Current_Cost", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 31, 19, 237, DateTimeKind.Local).AddTicks(427), 0.0, new DateTime(2022, 10, 13, 22, 31, 19, 237, DateTimeKind.Local).AddTicks(466) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Current_Cost", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 31, 19, 237, DateTimeKind.Local).AddTicks(469), 0.0, new DateTime(2022, 10, 13, 22, 31, 19, 237, DateTimeKind.Local).AddTicks(471) });
        }
    }
}
