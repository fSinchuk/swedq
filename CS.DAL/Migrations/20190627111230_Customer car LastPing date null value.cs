using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.DAL.Migrations
{
    public partial class CustomercarLastPingdatenullvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastPing",
                table: "Customer_Cars",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastPing",
                table: "Customer_Cars",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
