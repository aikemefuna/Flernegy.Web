using Microsoft.EntityFrameworkCore.Migrations;

namespace Flenergy.Data.Migrations
{
    public partial class init30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adm_Meter_Customers_CustomerId",
                table: "Adm_Meter");

            

            migrationBuilder.DropIndex(
                name: "IX_Customers_Adm_MeterId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Adm_MeterId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NoOfCustomer",
                table: "Adm_Meter");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NoOfMeter",
                table: "Customers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "Customers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Adm_Meter",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adm_Meter_Customers_CustomerId",
                table: "Adm_Meter");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NoOfMeter",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "Adm_MeterId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Adm_Meter",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
