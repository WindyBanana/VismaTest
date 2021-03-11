using Microsoft.EntityFrameworkCore.Migrations;

namespace VismaTest.Migrations
{
    public partial class AlteredNamePositionNameToTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionName",
                table: "EmployeePositions");

            migrationBuilder.AddColumn<string>(
                name: "PositionTitle",
                table: "EmployeePositions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionTitle",
                table: "EmployeePositions");

            migrationBuilder.AddColumn<string>(
                name: "PositionName",
                table: "EmployeePositions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
