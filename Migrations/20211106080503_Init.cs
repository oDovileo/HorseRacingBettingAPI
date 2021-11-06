using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacingBettingAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaceHorses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceHorses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceBettors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HorseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceBettors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceBettors_RaceHorses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "RaceHorses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceBettors_HorseId",
                table: "RaceBettors",
                column: "HorseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceBettors");

            migrationBuilder.DropTable(
                name: "RaceHorses");
        }
    }
}
