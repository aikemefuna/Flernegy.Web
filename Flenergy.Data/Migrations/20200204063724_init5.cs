using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flenergy.Data.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Wallets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Wallets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "Wallets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "Wallets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "PaymentSplits",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "PaymentSplits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "PaymentSplits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "PaymentSplits",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Estates",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Estates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "Estates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "Estates",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EstateAdmins",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EstateAdmins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "EstateAdmins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "EstateAdmins",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Discos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Discos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "Discos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "Discos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CustomerPinVendingProfiles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "CustomerPinVendingProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "CustomerPinVendingProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "CustomerPinVendingProfiles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BillingCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "BillingCategory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estate",
                table: "BillingCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstateId",
                table: "BillingCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "BillingCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "BillingCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Adm_ServiceCharge",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Adm_ServiceCharge",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "Adm_ServiceCharge",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "Adm_ServiceCharge",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Adm_Meter",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Adm_Meter",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "Adm_Meter",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "Adm_Meter",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Adm_Gateway",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Adm_Gateway",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "Adm_Gateway",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModified",
                table: "Adm_Gateway",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillingCategory_EstateId",
                table: "BillingCategory",
                column: "EstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingCategory_Estates_EstateId",
                table: "BillingCategory",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "EstateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingCategory_Estates_EstateId",
                table: "BillingCategory");

            migrationBuilder.DropIndex(
                name: "IX_BillingCategory_EstateId",
                table: "BillingCategory");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "PaymentSplits");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "PaymentSplits");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "PaymentSplits");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "PaymentSplits");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EstateAdmins");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EstateAdmins");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "EstateAdmins");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "EstateAdmins");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Discos");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Discos");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Discos");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Discos");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CustomerPinVendingProfiles");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "CustomerPinVendingProfiles");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "CustomerPinVendingProfiles");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "CustomerPinVendingProfiles");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BillingCategory");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "BillingCategory");

            migrationBuilder.DropColumn(
                name: "Estate",
                table: "BillingCategory");

            migrationBuilder.DropColumn(
                name: "EstateId",
                table: "BillingCategory");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "BillingCategory");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "BillingCategory");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Adm_ServiceCharge");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Adm_ServiceCharge");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Adm_ServiceCharge");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Adm_ServiceCharge");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Adm_Meter");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Adm_Meter");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Adm_Meter");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Adm_Meter");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Adm_Gateway");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Adm_Gateway");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Adm_Gateway");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Adm_Gateway");
        }
    }
}
