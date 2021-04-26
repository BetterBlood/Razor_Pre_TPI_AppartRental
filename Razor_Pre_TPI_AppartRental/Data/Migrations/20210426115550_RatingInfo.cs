using Microsoft.EntityFrameworkCore.Migrations;

namespace Razor_Pre_TPI_AppartRental.Data.Migrations
{
    public partial class RatingInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatingInfo_AspNetUsers_ApplicationUserId",
                table: "RatingInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RatingInfo",
                table: "RatingInfo");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c8e2b0d-0040-4f5f-9d15-4ca775634fd8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8774070-cba0-4441-900b-0801bc98125a");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RatingInfo");

            migrationBuilder.DropColumn(
                name: "RatedAppartementsId",
                table: "RatingInfo");

            migrationBuilder.RenameTable(
                name: "RatingInfo",
                newName: "RatingInfos");

            migrationBuilder.RenameIndex(
                name: "IX_RatingInfo_ApplicationUserId",
                table: "RatingInfos",
                newName: "IX_RatingInfos_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RatingInfos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AppartementId",
                table: "RatingInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatingInfos",
                table: "RatingInfos",
                columns: new[] { "UserId", "AppartementId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69e3ea56-728e-4dc2-a6b8-de8d90fe5e9c", "1cdf80bc-36b2-43ba-9de6-40ea68a41a69", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b45bb6a-8d0c-48b1-bd60-26ffde2ecf84", "a1d7059a-c6a0-4943-94f9-b697f8c2d75c", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_RatingInfos_AspNetUsers_ApplicationUserId",
                table: "RatingInfos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatingInfos_AspNetUsers_ApplicationUserId",
                table: "RatingInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RatingInfos",
                table: "RatingInfos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69e3ea56-728e-4dc2-a6b8-de8d90fe5e9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b45bb6a-8d0c-48b1-bd60-26ffde2ecf84");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RatingInfos");

            migrationBuilder.DropColumn(
                name: "AppartementId",
                table: "RatingInfos");

            migrationBuilder.RenameTable(
                name: "RatingInfos",
                newName: "RatingInfo");

            migrationBuilder.RenameIndex(
                name: "IX_RatingInfos_ApplicationUserId",
                table: "RatingInfo",
                newName: "IX_RatingInfo_ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RatingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RatedAppartementsId",
                table: "RatingInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatingInfo",
                table: "RatingInfo",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8774070-cba0-4441-900b-0801bc98125a", "6cec5fce-a4f0-4062-b991-f5ad24a86d9f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c8e2b0d-0040-4f5f-9d15-4ca775634fd8", "f0d697ef-a699-4208-b2b7-65acd4345c1e", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_RatingInfo_AspNetUsers_ApplicationUserId",
                table: "RatingInfo",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
