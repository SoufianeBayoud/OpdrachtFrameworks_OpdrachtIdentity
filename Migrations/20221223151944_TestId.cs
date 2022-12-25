using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpdrachtFrameworks.Migrations
{
    /// <inheritdoc />
    public partial class TestId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Klant",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Immo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Facture",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Klant",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Immo",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Facture",
                newName: "id");
        }
    }
}
