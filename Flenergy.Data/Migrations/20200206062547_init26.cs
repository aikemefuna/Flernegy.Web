using Microsoft.EntityFrameworkCore.Migrations;

namespace Flenergy.Data.Migrations
{
    public partial class init26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adm_Meter_Customers_CustomerId",
                table: "Adm_Meter");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Adm_Meter",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EstateId",
                table: "Adm_Meter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adm_Meter_EstateId",
                table: "Adm_Meter",
                column: "EstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adm_Meter_Customers_CustomerId",
                table: "Adm_Meter",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adm_Meter_Estates_EstateId",
                table: "Adm_Meter",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "EstateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adm_Meter_Customers_CustomerId",
                table: "Adm_Meter");

            migrationBuilder.DropForeignKey(
                name: "FK_Adm_Meter_Estates_EstateId",
                table: "Adm_Meter");

            migrationBuilder.DropIndex(
                name: "IX_Adm_Meter_EstateId",
                table: "Adm_Meter");

            migrationBuilder.DropColumn(
                name: "EstateId",
                table: "Adm_Meter");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Adm_Meter",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adm_Meter_Customers_CustomerId",
                table: "Adm_Meter",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
