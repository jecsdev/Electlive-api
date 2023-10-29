using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectLive_API.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Census",
                table: "Votings",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Enclosure",
                table: "Votings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enclosure",
                table: "Votings");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Votings",
                newName: "Census");
        }
    }
}
