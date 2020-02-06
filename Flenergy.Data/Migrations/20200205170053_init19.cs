using Microsoft.EntityFrameworkCore.Migrations;

namespace Flenergy.Data.Migrations
{
    public partial class init19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EstateCode",
                table: "Estates",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "EstateCode",
                table: "Estates",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
