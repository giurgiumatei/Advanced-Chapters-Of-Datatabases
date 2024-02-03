using Microsoft.EntityFrameworkCore.Migrations;

namespace TransferMarket.Migrations.Migrations
{
    public partial class UpdatedHistoryTablesRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransferHistories_TransferId",
                table: "TransferHistories");

            migrationBuilder.DropIndex(
                name: "IX_TeamHistories_TeamId",
                table: "TeamHistories");

            migrationBuilder.DropIndex(
                name: "IX_FootballerHistories_FootballerId",
                table: "FootballerHistories");

            migrationBuilder.CreateIndex(
                name: "IX_TransferHistories_TransferId",
                table: "TransferHistories",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamHistories_TeamId",
                table: "TeamHistories",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerHistories_FootballerId",
                table: "FootballerHistories",
                column: "FootballerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransferHistories_TransferId",
                table: "TransferHistories");

            migrationBuilder.DropIndex(
                name: "IX_TeamHistories_TeamId",
                table: "TeamHistories");

            migrationBuilder.DropIndex(
                name: "IX_FootballerHistories_FootballerId",
                table: "FootballerHistories");

            migrationBuilder.CreateIndex(
                name: "IX_TransferHistories_TransferId",
                table: "TransferHistories",
                column: "TransferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamHistories_TeamId",
                table: "TeamHistories",
                column: "TeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FootballerHistories_FootballerId",
                table: "FootballerHistories",
                column: "FootballerId",
                unique: true);
        }
    }
}
