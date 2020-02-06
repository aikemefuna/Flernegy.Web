using Microsoft.EntityFrameworkCore.Migrations;

namespace Flenergy.Data.Migrations
{
    public partial class init15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LGA",
                table: "Estates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Estates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LGA",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Estates");
        }
    }
}
