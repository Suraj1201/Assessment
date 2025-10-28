using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CyberSpaceGamers.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRating", "Genre", "Name", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, "18+", "Action", "Game One", 10.99m, "Game One Description" },
                    { 2, "12+", "Adventure", "Game Two", 11.99m, "Game Two Description" },
                    { 3, "18+", "RPG", "Game Three", 10.99m, "Game Three Description" },
                    { 4, "12+", "Indie", "Game Four", 11.99m, "Game Four Description" },
                    { 5, "12+", "Indie", "Game Four", 11.99m, "Game Four Description" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
