using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obioha_VillaAPI.Migrations
{
    public partial class AddCurrentCostToHouseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Current_Cost",
                table: "Houses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 31, 19, 237, DateTimeKind.Local).AddTicks(427), new DateTime(2022, 10, 13, 22, 31, 19, 237, DateTimeKind.Local).AddTicks(466) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 31, 19, 237, DateTimeKind.Local).AddTicks(469), new DateTime(2022, 10, 13, 22, 31, 19, 237, DateTimeKind.Local).AddTicks(471) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Current_Cost",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 25, 9, 396, DateTimeKind.Local).AddTicks(6514), new DateTime(2022, 10, 13, 22, 25, 9, 396, DateTimeKind.Local).AddTicks(6550) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 25, 9, 396, DateTimeKind.Local).AddTicks(6554), new DateTime(2022, 10, 13, 22, 25, 9, 396, DateTimeKind.Local).AddTicks(6556) });
        }
    }
}
