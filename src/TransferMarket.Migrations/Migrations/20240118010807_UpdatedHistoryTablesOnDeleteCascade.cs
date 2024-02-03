using Microsoft.EntityFrameworkCore.Migrations;

namespace TransferMarket.Migrations.Migrations
{
    public partial class UpdatedHistoryTablesOnDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamHistories_Teams_TeamId",
                table: "TeamHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferHistories_Transfers_TransferId",
                table: "TransferHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Footballers_FootballerId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Teams_TeamId",
                table: "Transfers");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamHistories_Teams_TeamId",
                table: "TeamHistories",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferHistories_Transfers_TransferId",
                table: "TransferHistories",
                column: "TransferId",
                principalTable: "Transfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Footballers_FootballerId",
                table: "Transfers",
                column: "FootballerId",
                principalTable: "Footballers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Teams_TeamId",
                table: "Transfers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamHistories_Teams_TeamId",
                table: "TeamHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferHistories_Transfers_TransferId",
                table: "TransferHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Footballers_FootballerId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Teams_TeamId",
                table: "Transfers");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamHistories_Teams_TeamId",
                table: "TeamHistories",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferHistories_Transfers_TransferId",
                table: "TransferHistories",
                column: "TransferId",
                principalTable: "Transfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Footballers_FootballerId",
                table: "Transfers",
                column: "FootballerId",
                principalTable: "Footballers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Teams_TeamId",
                table: "Transfers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
