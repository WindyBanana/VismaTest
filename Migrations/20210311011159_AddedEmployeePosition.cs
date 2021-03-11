using Microsoft.EntityFrameworkCore.Migrations;

namespace VismaTest.Migrations
{
    public partial class AddedEmployeePosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosiotionMissions_Missions_TaskMissionID",
                table: "PosiotionMissions");

            migrationBuilder.DropIndex(
                name: "IX_PosiotionMissions_TaskMissionID",
                table: "PosiotionMissions");

            migrationBuilder.DropColumn(
                name: "PositionName",
                table: "PosiotionMissions");

            migrationBuilder.DropColumn(
                name: "TaskMissionID",
                table: "PosiotionMissions");

            migrationBuilder.DropColumn(
                name: "TaskName",
                table: "PosiotionMissions");

            migrationBuilder.AddColumn<int>(
                name: "MissionID",
                table: "PosiotionMissions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MissionName",
                table: "PosiotionMissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionTitle",
                table: "PosiotionMissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EmployeePositions",
                columns: table => new
                {
                    EmployeePositionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<int>(nullable: false),
                    EmployeeName = table.Column<int>(nullable: false),
                    PositionID = table.Column<int>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => x.EmployeePositionID);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PosiotionMissions_MissionID",
                table: "PosiotionMissions",
                column: "MissionID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_EmployeeID",
                table: "EmployeePositions",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_PositionID",
                table: "EmployeePositions",
                column: "PositionID");

            migrationBuilder.AddForeignKey(
                name: "FK_PosiotionMissions_Missions_MissionID",
                table: "PosiotionMissions",
                column: "MissionID",
                principalTable: "Missions",
                principalColumn: "MissionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosiotionMissions_Missions_MissionID",
                table: "PosiotionMissions");

            migrationBuilder.DropTable(
                name: "EmployeePositions");

            migrationBuilder.DropIndex(
                name: "IX_PosiotionMissions_MissionID",
                table: "PosiotionMissions");

            migrationBuilder.DropColumn(
                name: "MissionID",
                table: "PosiotionMissions");

            migrationBuilder.DropColumn(
                name: "MissionName",
                table: "PosiotionMissions");

            migrationBuilder.DropColumn(
                name: "PositionTitle",
                table: "PosiotionMissions");

            migrationBuilder.AddColumn<int>(
                name: "PositionName",
                table: "PosiotionMissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskMissionID",
                table: "PosiotionMissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskName",
                table: "PosiotionMissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PosiotionMissions_TaskMissionID",
                table: "PosiotionMissions",
                column: "TaskMissionID");

            migrationBuilder.AddForeignKey(
                name: "FK_PosiotionMissions_Missions_TaskMissionID",
                table: "PosiotionMissions",
                column: "TaskMissionID",
                principalTable: "Missions",
                principalColumn: "MissionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
