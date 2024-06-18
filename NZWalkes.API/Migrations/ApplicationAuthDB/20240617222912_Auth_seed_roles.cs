using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalkes.API.Migrations.ApplicationAuthDB
{
    /// <inheritdoc />
    public partial class Auth_seed_roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d4619ea-d3c8-4870-b40b-f3d63431f7f1", "1d4619ea-d3c8-4870-b40b-f3d63431f7f1", "Writer", "WRITER" },
                    { "451ecfa3-0fa7-4cad-9830-bd8011fbbe82", "451ecfa3-0fa7-4cad-9830-bd8011fbbe82", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d4619ea-d3c8-4870-b40b-f3d63431f7f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "451ecfa3-0fa7-4cad-9830-bd8011fbbe82");
        }
    }
}
