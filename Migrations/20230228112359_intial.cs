using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeightTracker.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Mesurements",
                columns: table => new
                {
                    MeasurementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    TakenOn = table.Column<DateTime>(type: "date", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesurements", x => x.MeasurementId);
                    table.ForeignKey(
                        name: "FK_Mesurements_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesurements_TakenOn_UserId",
                table: "Mesurements",
                columns: new[] { "TakenOn", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mesurements_UserId",
                table: "Mesurements",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mesurements");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
