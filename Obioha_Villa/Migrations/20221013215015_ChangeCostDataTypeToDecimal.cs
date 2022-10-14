using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obioha_VillaAPI.Migrations
{
    public partial class ChangeCostDataTypeToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Purchase_Cost",
                table: "Houses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Current_Cost",
                table: "Houses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Current_Cost", "Purchase_Cost", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 50, 14, 977, DateTimeKind.Local).AddTicks(1294), 190000m, 125000m, new DateTime(2022, 10, 13, 22, 50, 14, 977, DateTimeKind.Local).AddTicks(1365) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Current_Cost", "Purchase_Cost", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 50, 14, 977, DateTimeKind.Local).AddTicks(1368), 132000m, 121500m, new DateTime(2022, 10, 13, 22, 50, 14, 977, DateTimeKind.Local).AddTicks(1370) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Purchase_Cost",
                table: "Houses",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Current_Cost",
                table: "Houses",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Current_Cost", "Purchase_Cost", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 34, 47, 911, DateTimeKind.Local).AddTicks(7610), 190000.0, 125000.0, new DateTime(2022, 10, 13, 22, 34, 47, 911, DateTimeKind.Local).AddTicks(7642) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Current_Cost", "Purchase_Cost", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 34, 47, 911, DateTimeKind.Local).AddTicks(7645), 132000.0, 121500.0, new DateTime(2022, 10, 13, 22, 34, 47, 911, DateTimeKind.Local).AddTicks(7647) });
        }
    }
}
