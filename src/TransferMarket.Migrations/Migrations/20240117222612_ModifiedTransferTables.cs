using Microsoft.EntityFrameworkCore.Migrations;

namespace TransferMarket.Migrations.Migrations
{
    public partial class ModifiedTransferTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewValue",
                table: "TeamsHistories",
                newName: "NewTotalValue");

            migrationBuilder.AddColumn<string>(
                name: "NewCity",
                table: "TeamsHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewLeague",
                table: "TeamsHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewName",
                table: "TeamsHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NewHeight",
                table: "FootballerHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "NewName",
                table: "FootballerHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewPosition",
                table: "FootballerHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NewWeight",
                table: "FootballerHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewCity",
                table: "TeamsHistories");

            migrationBuilder.DropColumn(
                name: "NewLeague",
                table: "TeamsHistories");

            migrationBuilder.DropColumn(
                name: "NewName",
                table: "TeamsHistories");

            migrationBuilder.DropColumn(
                name: "NewHeight",
                table: "FootballerHistories");

            migrationBuilder.DropColumn(
                name: "NewName",
                table: "FootballerHistories");

            migrationBuilder.DropColumn(
                name: "NewPosition",
                table: "FootballerHistories");

            migrationBuilder.DropColumn(
                name: "NewWeight",
                table: "FootballerHistories");

            migrationBuilder.RenameColumn(
                name: "NewTotalValue",
                table: "TeamsHistories",
                newName: "NewValue");
        }
    }
}
