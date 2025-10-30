using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CyberSpaceGamers.Migrations
{
    /// <inheritdoc />
    public partial class seedproducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRating", "Genre", "Name", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, "16+", "Shooter", "BattleField 6", 59.99m, "Guns go pew pew woohoo" },
                    { 2, "18+", "Survival", "Resident Evil Village", 25.99m, "If you know, you know" },
                    { 3, "16+", "Horror", "Little Nightmares III", 49.00m, "Puny people fight larger nightmares" },
                    { 4, "12+", "Fighter", "Super Smash Bros Ultimate", 54.50m, "King K rool players are evil. ps - Sora is better." },
                    { 5, "16+", "Action", "Guardians of the Galaxy", 19.99m, "Groot is best Guardian. I am GRROOOT" },
                    { 6, "12+", "Adventure", "Fallout 4", 11.99m, "Explore to your earnest galore" },
                    { 7, "14+", "Action", "Saraj: Shadow Rebellion", 20.00m, "This game includes super Suraj" },
                    { 8, "14+", "Multiplayer", "Josh: Empires Unite", 20.99m, "This game includes The organised Joshua of Laws" },
                    { 9, "14+", "Adventure", "Dhruvisha’s Journey", 20.99m, "This game includes the determined Dhruvisha" },
                    { 10, "14+", "Horror", "Whispering Woods: Kanwal’s Secret", 20.99m, "This game includes the Scary Kanwal" },
                    { 11, "14+", "Mystery", "Crimson Evidence: Cameron Chronicles", 20.99m, "This game includes the big mouth but bigger heart jokester Cameron (Ps Best game here.)" },
                    { 12, "14+", "Strategic", "Liar's Bar", 5.99m, "Be strategic and sly or die" }
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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
