using Microsoft.EntityFrameworkCore.Migrations;

namespace Sushi.Migrations
{
    public partial class deleted_some_fillets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "MenuItemName", "MenuItemPrice" },
                values: new object[,]
                {
                    { 12, "Fillet of tomago", 6.0 },
                    { 13, "Fillet of inari", 6.0 },
                    { 14, "Fillet of madai", 6.0 },
                    { 15, "Fillet of tomago", 6.0 },
                    { 16, "Fillet of suzuki", 6.0 },
                    { 17, "Fillet of unagi", 6.0 },
                    { 18, "Fillet of ebi", 6.0 },
                    { 19, "Fillet of ika", 6.0 }
                });
        }
    }
}
