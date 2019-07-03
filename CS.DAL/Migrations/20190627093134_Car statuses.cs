using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.DAL.Migrations
{
    public partial class Carstatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Customer_Cars",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.CreateTable(
                name: "Car_Statuses",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_Statuses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car_Statuses");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Customer_Cars",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
