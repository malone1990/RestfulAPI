using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestfulAPI.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TimeEntrys",
                columns: table => new
                {
                    TimeEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalHours = table.Column<double>(type: "float", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeEntrys", x => x.TimeEntryId);
                    table.ForeignKey(
                        name: "FK_TimeEntrys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeCards",
                columns: table => new
                {
                    TiemCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeEntryId = table.Column<int>(type: "int", nullable: false),
                    MonInfo = table.Column<double>(type: "float", nullable: false),
                    TueInfo = table.Column<double>(type: "float", nullable: false),
                    WedInfo = table.Column<double>(type: "float", nullable: false),
                    ThuInfo = table.Column<double>(type: "float", nullable: false),
                    FriInfo = table.Column<double>(type: "float", nullable: false),
                    SatInfo = table.Column<double>(type: "float", nullable: false),
                    SunInfo = table.Column<double>(type: "float", nullable: false),
                    Count = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeCards", x => x.TiemCardId);
                    table.ForeignKey(
                        name: "FK_TimeCards_TimeEntrys_TimeEntryId",
                        column: x => x.TimeEntryId,
                        principalTable: "TimeEntrys",
                        principalColumn: "TimeEntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeCards_TimeEntryId",
                table: "TimeCards",
                column: "TimeEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntrys_UserId",
                table: "TimeEntrys",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeCards");

            migrationBuilder.DropTable(
                name: "TimeEntrys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
