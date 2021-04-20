using Microsoft.EntityFrameworkCore.Migrations;

namespace Razor_Pre_TPI_AppartRental.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf2d52ee-a03f-4a8a-ae26-def15f17af21", "48923f89-3280-449d-bfc3-5940d831afb8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d401da3-4e31-4527-a011-0b4224af83e7", "5073ac09-cf20-43ce-84a2-9baf0f3ad974", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d401da3-4e31-4527-a011-0b4224af83e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf2d52ee-a03f-4a8a-ae26-def15f17af21");
        }
    }
}
