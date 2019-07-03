using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.DAL.Migrations
{
    public partial class Changecustomercarcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customer_Cars");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customer_Cars");

            migrationBuilder.AddColumn<string>(
                name: "RegNr",
                table: "Customer_Cars",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vin",
                table: "Customer_Cars",
                maxLength: 17,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegNr",
                table: "Customer_Cars");

            migrationBuilder.DropColumn(
                name: "Vin",
                table: "Customer_Cars");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customer_Cars",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customer_Cars",
                nullable: false,
                defaultValue: "");
        }
    }
}
