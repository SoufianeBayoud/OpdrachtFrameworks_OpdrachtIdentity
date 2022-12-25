using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpdrachtFrameworks.Migrations
{
    /// <inheritdoc />
    public partial class FourthOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Immo_Klant_KlantId",
                table: "Immo");

            migrationBuilder.DropIndex(
                name: "IX_Immo_KlantId",
                table: "Immo");

            migrationBuilder.DropColumn(
                name: "KlantId",
                table: "Immo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KlantId",
                table: "Immo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Immo_KlantId",
                table: "Immo",
                column: "KlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Immo_Klant_KlantId",
                table: "Immo",
                column: "KlantId",
                principalTable: "Klant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
