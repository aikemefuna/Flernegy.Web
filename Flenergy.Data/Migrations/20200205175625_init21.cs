using Microsoft.EntityFrameworkCore.Migrations;

namespace Flenergy.Data.Migrations
{
    public partial class init21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "EstateAdmins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LGA",
                table: "Discos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "EstateAdmins");

            migrationBuilder.DropColumn(
                name: "LGA",
                table: "Discos");
        }
    }
}
