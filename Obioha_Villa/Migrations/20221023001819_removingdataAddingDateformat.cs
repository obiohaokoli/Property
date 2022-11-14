using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obioha_VillaAPI.Migrations
{
    public partial class removingdataAddingDateformat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 23, 1, 18, 19, 614, DateTimeKind.Local).AddTicks(7342), new DateTime(2022, 10, 23, 1, 18, 19, 614, DateTimeKind.Local).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 23, 1, 18, 19, 614, DateTimeKind.Local).AddTicks(7393), new DateTime(2022, 10, 23, 1, 18, 19, 614, DateTimeKind.Local).AddTicks(7395) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 23, 1, 18, 19, 614, DateTimeKind.Local).AddTicks(7487), new DateTime(2022, 10, 23, 1, 18, 19, 614, DateTimeKind.Local).AddTicks(7492) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 23, 1, 18, 19, 614, DateTimeKind.Local).AddTicks(7494), new DateTime(2022, 10, 23, 1, 18, 19, 614, DateTimeKind.Local).AddTicks(7496) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "ImageUrl", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9419), "Manchester.jpg", new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "ImageUrl", "Updated_Date" },
                values: new object[] { new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9466), "Derby.jpg", new DateTime(2022, 10, 23, 0, 14, 34, 767, DateTimeKind.Local).AddTicks(9467) });

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
    }
}
