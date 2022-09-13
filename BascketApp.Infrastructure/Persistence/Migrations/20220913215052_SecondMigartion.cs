using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BascketApp.Infrastructure.Persistence.Migrations
{
    public partial class SecondMigartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Close",
                table: "Basckets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Payed",
                table: "Basckets",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Close",
                table: "Basckets");

            migrationBuilder.DropColumn(
                name: "Payed",
                table: "Basckets");
        }
    }
}
