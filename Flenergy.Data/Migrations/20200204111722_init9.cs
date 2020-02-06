using Microsoft.EntityFrameworkCore.Migrations;

namespace Flenergy.Data.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingCategory_Estates_EstateId",
                table: "BillingCategory");

            migrationBuilder.DropColumn(
                name: "Estate",
                table: "BillingCategory");

            migrationBuilder.AlterColumn<int>(
                name: "EstateId",
                table: "BillingCategory",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

      
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
      

            migrationBuilder.AlterColumn<int>(
                name: "EstateId",
                table: "BillingCategory",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Estate",
                table: "BillingCategory",
                nullable: false,
                defaultValue: 0);

  
        }
    }
}
