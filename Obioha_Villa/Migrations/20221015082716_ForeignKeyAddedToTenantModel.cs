using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obioha_VillaAPI.Migrations
{
    public partial class ForeignKeyAddedToTenantModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "House_Id",
                table: "Tenants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 15, 9, 27, 15, 980, DateTimeKind.Local).AddTicks(8803), new DateTime(2022, 10, 15, 9, 27, 15, 980, DateTimeKind.Local).AddTicks(8842) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 15, 9, 27, 15, 980, DateTimeKind.Local).AddTicks(8847), new DateTime(2022, 10, 15, 9, 27, 15, 980, DateTimeKind.Local).AddTicks(8849) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 15, 9, 27, 15, 980, DateTimeKind.Local).AddTicks(8939), new DateTime(2022, 10, 15, 9, 27, 15, 980, DateTimeKind.Local).AddTicks(8944) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 15, 9, 27, 15, 980, DateTimeKind.Local).AddTicks(8947), new DateTime(2022, 10, 15, 9, 27, 15, 980, DateTimeKind.Local).AddTicks(8950) });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_House_Id",
                table: "Tenants",
                column: "House_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Houses_House_Id",
                table: "Tenants",
                column: "House_Id",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Houses_House_Id",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_House_Id",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "House_Id",
                table: "Tenants");

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

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9085), new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9088) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9090), new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9093) });
        }
    }
}
