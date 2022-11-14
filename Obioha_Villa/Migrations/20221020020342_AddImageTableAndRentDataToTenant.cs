using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obioha_VillaAPI.Migrations
{
    public partial class AddImageTableAndRentDataToTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rent_Amount",
                table: "Tenants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Image_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    House_Id = table.Column<int>(type: "int", nullable: false),
                    Image_Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Image_Id);
                    table.ForeignKey(
                        name: "FK_Images_Houses_House_Id",
                        column: x => x.House_Id,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 20, 3, 3, 42, 296, DateTimeKind.Local).AddTicks(2421), new DateTime(2022, 10, 20, 3, 3, 42, 296, DateTimeKind.Local).AddTicks(2460) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 20, 3, 3, 42, 296, DateTimeKind.Local).AddTicks(2463), new DateTime(2022, 10, 20, 3, 3, 42, 296, DateTimeKind.Local).AddTicks(2464) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 20, 3, 3, 42, 296, DateTimeKind.Local).AddTicks(2533), new DateTime(2022, 10, 20, 3, 3, 42, 296, DateTimeKind.Local).AddTicks(2537) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 20, 3, 3, 42, 296, DateTimeKind.Local).AddTicks(2538), new DateTime(2022, 10, 20, 3, 3, 42, 296, DateTimeKind.Local).AddTicks(2541) });

            migrationBuilder.CreateIndex(
                name: "IX_Images_House_Id",
                table: "Images",
                column: "House_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "Rent_Amount",
                table: "Tenants");

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
        }
    }
}
