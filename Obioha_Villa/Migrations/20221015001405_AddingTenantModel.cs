using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obioha_VillaAPI.Migrations
{
    public partial class AddingTenantModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Purchased_Date",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Middle_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marriage_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No_Of_kids = table.Column<int>(type: "int", nullable: false),
                    Imageurl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenancy_Period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenancy_Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tenancy_End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Move_in_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deposite_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Purchased_Date",
                table: "Houses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 50, 14, 977, DateTimeKind.Local).AddTicks(1294), new DateTime(2022, 10, 13, 22, 50, 14, 977, DateTimeKind.Local).AddTicks(1365) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 13, 22, 50, 14, 977, DateTimeKind.Local).AddTicks(1368), new DateTime(2022, 10, 13, 22, 50, 14, 977, DateTimeKind.Local).AddTicks(1370) });
        }
    }
}
