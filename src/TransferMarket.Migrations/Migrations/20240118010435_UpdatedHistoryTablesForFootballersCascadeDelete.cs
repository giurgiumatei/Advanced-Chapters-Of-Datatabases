using Microsoft.EntityFrameworkCore.Migrations;

namespace TransferMarket.Migrations.Migrations
{
    public partial class UpdatedHistoryTablesForFootballersCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballerHistories_Footballers_FootballerId",
                table: "FootballerHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerHistories_Footballers_FootballerId",
                table: "FootballerHistories",
                column: "FootballerId",
                principalTable: "Footballers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballerHistories_Footballers_FootballerId",
                table: "FootballerHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerHistories_Footballers_FootballerId",
                table: "FootballerHistories",
                column: "FootballerId",
                principalTable: "Footballers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
