using Microsoft.EntityFrameworkCore.Migrations;

namespace Razor_Pre_TPI_AppartRental.Data.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d401da3-4e31-4527-a011-0b4224af83e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf2d52ee-a03f-4a8a-ae26-def15f17af21");

            migrationBuilder.AddColumn<bool>(
                name: "Rated",
                table: "UserAppartements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8774070-cba0-4441-900b-0801bc98125a", "6cec5fce-a4f0-4062-b991-f5ad24a86d9f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c8e2b0d-0040-4f5f-9d15-4ca775634fd8", "f0d697ef-a699-4208-b2b7-65acd4345c1e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c8e2b0d-0040-4f5f-9d15-4ca775634fd8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8774070-cba0-4441-900b-0801bc98125a");

            migrationBuilder.DropColumn(
                name: "Rated",
                table: "UserAppartements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf2d52ee-a03f-4a8a-ae26-def15f17af21", "48923f89-3280-449d-bfc3-5940d831afb8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d401da3-4e31-4527-a011-0b4224af83e7", "5073ac09-cf20-43ce-84a2-9baf0f3ad974", "Admin", "ADMIN" });
        }
    }
}
