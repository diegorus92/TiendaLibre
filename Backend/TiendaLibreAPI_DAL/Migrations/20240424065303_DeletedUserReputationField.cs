using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaLibreAPI_DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeletedUserReputationField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReputationLvl",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "QtyToBuy",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtyToBuy",
                table: "Purchases");

            migrationBuilder.AddColumn<string>(
                name: "ReputationLvl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
