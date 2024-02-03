using Microsoft.EntityFrameworkCore.Migrations;

namespace TransferMarket.Migrations.Migrations
{
    public partial class ChangedTransferHistoryNewTotalSumDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballerHistories_Footballers_FoorballerId",
                table: "FootballerHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsHistories_Teams_TeamId",
                table: "TeamsHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamsHistories",
                table: "TeamsHistories");

            migrationBuilder.RenameTable(
                name: "TeamsHistories",
                newName: "TeamHistories");

            migrationBuilder.RenameColumn(
                name: "FoorballerId",
                table: "FootballerHistories",
                newName: "FootballerId");

            migrationBuilder.RenameIndex(
                name: "IX_FootballerHistories_FoorballerId",
                table: "FootballerHistories",
                newName: "IX_FootballerHistories_FootballerId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsHistories_TeamId",
                table: "TeamHistories",
                newName: "IX_TeamHistories_TeamId");

            migrationBuilder.AlterColumn<double>(
                name: "NewTotalSum",
                table: "TransferHistories",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamHistories",
                table: "TeamHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerHistories_Footballers_FootballerId",
                table: "FootballerHistories",
                column: "FootballerId",
                principalTable: "Footballers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamHistories_Teams_TeamId",
                table: "TeamHistories",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballerHistories_Footballers_FootballerId",
                table: "FootballerHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamHistories_Teams_TeamId",
                table: "TeamHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamHistories",
                table: "TeamHistories");

            migrationBuilder.RenameTable(
                name: "TeamHistories",
                newName: "TeamsHistories");

            migrationBuilder.RenameColumn(
                name: "FootballerId",
                table: "FootballerHistories",
                newName: "FoorballerId");

            migrationBuilder.RenameIndex(
                name: "IX_FootballerHistories_FootballerId",
                table: "FootballerHistories",
                newName: "IX_FootballerHistories_FoorballerId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamHistories_TeamId",
                table: "TeamsHistories",
                newName: "IX_TeamsHistories_TeamId");

            migrationBuilder.AlterColumn<string>(
                name: "NewTotalSum",
                table: "TransferHistories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamsHistories",
                table: "TeamsHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerHistories_Footballers_FoorballerId",
                table: "FootballerHistories",
                column: "FoorballerId",
                principalTable: "Footballers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsHistories_Teams_TeamId",
                table: "TeamsHistories",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
