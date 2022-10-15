using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obioha_VillaAPI.Migrations
{
    public partial class SeedingTenantModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Tenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(8975), new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9007) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9011), new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9012) });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "CreatedDate", "Deposite_Amount", "First_Name", "Imageurl", "Last_Name", "Marriage_Status", "Middle_Name", "Move_in_date", "Nationality", "No_Of_kids", "Tenancy_End_Date", "Tenancy_Period", "Tenancy_Start_Date", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9085), 1200m, "Micheal", "", "kpeke", "Married", "okigwe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2013), "Nigeria", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "one year", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2013), new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9088) },
                    { 2, new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9090), 1200m, "Peter", "", "Obi", "Married", "Awka", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2013), "Nigeria", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "one year", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2013), new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9093) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Tenants");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 15, 1, 14, 5, 510, DateTimeKind.Local).AddTicks(4853), new DateTime(2022, 10, 15, 1, 14, 5, 510, DateTimeKind.Local).AddTicks(4888) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 15, 1, 14, 5, 510, DateTimeKind.Local).AddTicks(4918), new DateTime(2022, 10, 15, 1, 14, 5, 510, DateTimeKind.Local).AddTicks(4919) });
        }
    }
}
