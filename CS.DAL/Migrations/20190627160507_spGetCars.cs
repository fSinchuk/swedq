using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.DAL.Migrations
{
    public partial class spGetCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE PROCEDURE spGetCars AS BEGIN SELECT [Id],[LastPing],[CustomerId],[StatusId],[RegNr],[Vin]  FROM[dbo].[Customer_Cars] END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE spGetCars");
        }
    }
}
