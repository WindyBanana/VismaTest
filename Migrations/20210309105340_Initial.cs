using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VismaTest.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ansatt",
                columns: table => new
                {
                    AnsattID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnsattNavn = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ansatt", x => x.AnsattID);
                });

            migrationBuilder.CreateTable(
                name: "Oppgave",
                columns: table => new
                {
                    OppgaveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OppgaveNavn = table.Column<string>(nullable: false),
                    OppgaveDato = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oppgave", x => x.OppgaveID);
                });

            migrationBuilder.CreateTable(
                name: "Stilling",
                columns: table => new
                {
                    StillingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stillingstittel = table.Column<string>(nullable: false),
                    StillingStartDato = table.Column<DateTime>(nullable: false),
                    StillingSluttDato = table.Column<DateTime>(nullable: false),
                    AnsattID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stilling", x => x.StillingID);
                    table.ForeignKey(
                        name: "FK_Stilling_Ansatt_AnsattID",
                        column: x => x.AnsattID,
                        principalTable: "Ansatt",
                        principalColumn: "AnsattID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StillingsOppgave",
                columns: table => new
                {
                    StillingsOppgaveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StillingID = table.Column<int>(nullable: false),
                    OppgaveID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StillingsOppgave", x => x.StillingsOppgaveID);
                    table.ForeignKey(
                        name: "FK_StillingsOppgave_Oppgave_OppgaveID",
                        column: x => x.OppgaveID,
                        principalTable: "Oppgave",
                        principalColumn: "OppgaveID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StillingsOppgave_Stilling_StillingID",
                        column: x => x.StillingID,
                        principalTable: "Stilling",
                        principalColumn: "StillingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stilling_AnsattID",
                table: "Stilling",
                column: "AnsattID");

            migrationBuilder.CreateIndex(
                name: "IX_StillingsOppgave_OppgaveID",
                table: "StillingsOppgave",
                column: "OppgaveID");

            migrationBuilder.CreateIndex(
                name: "IX_StillingsOppgave_StillingID",
                table: "StillingsOppgave",
                column: "StillingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StillingsOppgave");

            migrationBuilder.DropTable(
                name: "Oppgave");

            migrationBuilder.DropTable(
                name: "Stilling");

            migrationBuilder.DropTable(
                name: "Ansatt");
        }
    }
}
