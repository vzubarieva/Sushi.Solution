using Microsoft.EntityFrameworkCore.Migrations;

namespace Sushi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "MenuItemName", "MenuItemPrice" },
                values: new object[,]
                {
                    { 1, "Chihiro's deluxe", 45.0 },
                    { 17, "Fillet of unagi", 6.0 },
                    { 16, "Fillet of suzuki", 6.0 },
                    { 15, "Fillet of tomago", 6.0 },
                    { 14, "Fillet of madai", 6.0 },
                    { 13, "Fillet of inari", 6.0 },
                    { 12, "Fillet of tomago", 6.0 },
                    { 11, "Fillet of madai", 6.0 },
                    { 18, "Fillet of ebi", 6.0 },
                    { 10, "Fillet of sake", 6.0 },
                    { 8, "Shrimp tempura", 9.0 },
                    { 7, "Soft-shell crab", 11.0 },
                    { 6, "Gyouza", 7.0 },
                    { 5, "Dragon roll", 15.0 },
                    { 4, "Rainbow spider", 19.0 },
                    { 3, "Crazy salmon", 22.0 },
                    { 2, "Sushi special", 27.0 },
                    { 9, "Fillet of magura", 6.0 },
                    { 19, "Fillet of ika", 6.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 19);
        }
    }
}
