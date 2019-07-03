using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.DAL.Migrations
{
    public partial class Addcarstatustocustomercars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customer_Cars");

            migrationBuilder.AddColumn<short>(
                name: "StatusId",
                table: "Customer_Cars",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Cars_StatusId",
                table: "Customer_Cars",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Cars_Car_Statuses_StatusId",
                table: "Customer_Cars",
                column: "StatusId",
                principalTable: "Car_Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Cars_Car_Statuses_StatusId",
                table: "Customer_Cars");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Cars_StatusId",
                table: "Customer_Cars");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Customer_Cars");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Customer_Cars",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
