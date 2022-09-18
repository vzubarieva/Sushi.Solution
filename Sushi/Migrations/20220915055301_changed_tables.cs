using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sushi.Migrations
{
    public partial class changed_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Customers_CustomerId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CustomerId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "MenuItems");

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "MenuItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_OrderItemId",
                table: "MenuItems",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_OrderItems_OrderItemId",
                table: "MenuItems",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "OrderItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_OrderItems_OrderItemId",
                table: "MenuItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_OrderItemId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "MenuItems");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CustomerId",
                table: "MenuItems",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Customers_CustomerId",
                table: "MenuItems",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
