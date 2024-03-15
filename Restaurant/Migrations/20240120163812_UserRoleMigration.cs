using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f0627fe-bbb3-437d-a5a5-76281922d035", "24f3603c-1b63-4798-aaed-673714b41def", "Admin", "admin" },
                    { "a5364240-a4a7-4f77-bc7b-edda2e7e3ced", "2783c7a2-b799-47a2-9125-7649751afef8", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f0627fe-bbb3-437d-a5a5-76281922d035");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5364240-a4a7-4f77-bc7b-edda2e7e3ced");
        }
    }
}
