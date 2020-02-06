using Microsoft.EntityFrameworkCore.Migrations;

namespace Flenergy.Data.Migrations
{
    public partial class init28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Adm_MeterId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "NoOfCustomer",
                table: "Adm_Meter",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Adm_MeterId",
                table: "Customers",
                column: "Adm_MeterId");

     
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropIndex(
                name: "IX_Customers_Adm_MeterId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Adm_MeterId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NoOfCustomer",
                table: "Adm_Meter");
        }
    }
}
