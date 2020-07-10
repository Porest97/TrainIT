using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainIT.Migrations
{
    public partial class AddedWorkouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeStarted = table.Column<DateTime>(nullable: false),
                    DateTimeEnded = table.Column<DateTime>(nullable: false),
                    ArenaId = table.Column<int>(nullable: true),
                    SportId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    Duration = table.Column<double>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    Kcal = table.Column<double>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workout_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workout_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workout_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workout_ArenaId",
                table: "Workout",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_PersonId",
                table: "Workout",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_SportId",
                table: "Workout",
                column: "SportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workout");
        }
    }
}
