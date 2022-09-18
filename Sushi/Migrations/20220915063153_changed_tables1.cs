using Microsoft.EntityFrameworkCore.Migrations;

namespace Sushi.Migrations
{
    public partial class changed_tables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_OrderItems_OrderItemId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_OrderItemId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "MenuItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemsCount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Orders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "subTotalPrice",
                table: "Orders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MenuItemName",
                table: "OrderItems",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MenuItemPrice",
                table: "OrderItems",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "MenuItemPrice",
                table: "MenuItems",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ItemsCount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "subTotalPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MenuItemName",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "MenuItemPrice",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemPrice",
                table: "MenuItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "MenuItems",
                type: "int",
                nullable: true);

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
    }
}
