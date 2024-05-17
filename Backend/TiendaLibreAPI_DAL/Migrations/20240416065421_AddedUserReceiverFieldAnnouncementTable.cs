using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaLibreAPI_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserReceiverFieldAnnouncementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserReceiverId",
                table: "Announcements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserReceiverId",
                table: "Announcements");
        }
    }
}
