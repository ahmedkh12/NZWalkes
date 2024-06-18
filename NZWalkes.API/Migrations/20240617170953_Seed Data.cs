using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalkes.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1c39e209-b65f-43b7-b636-48827a3e8f47"), "Test Code1", "Test Name 1 ", "Test Image Url1 " },
                    { new Guid("a8076ec9-02f5-4226-bc54-f53704a49be9"), "Test Code4", "Test Name 4 ", "Test Image Url4 " },
                    { new Guid("eeadef98-d91c-4f6f-8834-2e8b03749543"), "Test Code 3", "Test Name 3 ", "Test Image Url3 " },
                    { new Guid("f8843075-1b5c-4495-80ba-a470a343e0b2"), "Test Code2", "Test Name 2 ", "Test Image Url2 " }
                });

            migrationBuilder.InsertData(
                table: "WalkDifficulties",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { new Guid("436a1bd0-e8c6-48e6-b55d-6ea25f51100c"), "Easy" },
                    { new Guid("90c72a00-8d60-4d14-afaf-63fcc2716ce1"), "Medieum" },
                    { new Guid("a06a0de4-c8bd-412e-9176-46fd314d333a"), "Hard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1c39e209-b65f-43b7-b636-48827a3e8f47"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a8076ec9-02f5-4226-bc54-f53704a49be9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("eeadef98-d91c-4f6f-8834-2e8b03749543"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f8843075-1b5c-4495-80ba-a470a343e0b2"));

            migrationBuilder.DeleteData(
                table: "WalkDifficulties",
                keyColumn: "Id",
                keyValue: new Guid("436a1bd0-e8c6-48e6-b55d-6ea25f51100c"));

            migrationBuilder.DeleteData(
                table: "WalkDifficulties",
                keyColumn: "Id",
                keyValue: new Guid("90c72a00-8d60-4d14-afaf-63fcc2716ce1"));

            migrationBuilder.DeleteData(
                table: "WalkDifficulties",
                keyColumn: "Id",
                keyValue: new Guid("a06a0de4-c8bd-412e-9176-46fd314d333a"));
        }
    }
}
