using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obioha_VillaAPI.Migrations
{
    public partial class ListOfImagesAddedToHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9419), new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9466), new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9467) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9536), new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9542), new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9544) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
