using Microsoft.EntityFrameworkCore.Migrations;

namespace Flenergy.Data.Migrations
{
    public partial class init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "NoOfCustomers",
                table: "BillingCategory",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfCustomers",
                table: "BillingCategory");
        }
    }
}
