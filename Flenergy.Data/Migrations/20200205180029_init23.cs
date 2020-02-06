using Microsoft.EntityFrameworkCore.Migrations;

namespace Flenergy.Data.Migrations
{
    public partial class init23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EstateAdmins",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "EstateAdmins");
        }
    }
}
