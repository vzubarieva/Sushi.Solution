using Microsoft.EntityFrameworkCore.Migrations;

namespace Sushi.Migrations
{
    public partial class remove_userid_from_menuitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_AspNetUsers_UserId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_UserId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MenuItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MenuItems",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_UserId",
                table: "MenuItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_AspNetUsers_UserId",
                table: "MenuItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
