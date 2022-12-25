using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpdrachtFrameworks.Migrations
{
    /// <inheritdoc />
    public partial class ThirdOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Immo_id",
                table: "Facture");

            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Klant_id",
                table: "Facture");

            migrationBuilder.DropForeignKey(
                name: "FK_Immo_Klant_id",
                table: "Immo");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Immo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "KlantId",
                table: "Immo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Facture",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ImmoId",
                table: "Facture",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KlantId",
                table: "Facture",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Immo_KlantId",
                table: "Immo",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_ImmoId",
                table: "Facture",
                column: "ImmoId");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_KlantId",
                table: "Facture",
                column: "KlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Immo_ImmoId",
                table: "Facture",
                column: "ImmoId",
                principalTable: "Immo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Klant_KlantId",
                table: "Facture",
                column: "KlantId",
                principalTable: "Klant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Immo_Klant_KlantId",
                table: "Immo",
                column: "KlantId",
                principalTable: "Klant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Immo_ImmoId",
                table: "Facture");

            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Klant_KlantId",
                table: "Facture");

            migrationBuilder.DropForeignKey(
                name: "FK_Immo_Klant_KlantId",
                table: "Immo");

            migrationBuilder.DropIndex(
                name: "IX_Immo_KlantId",
                table: "Immo");

            migrationBuilder.DropIndex(
                name: "IX_Facture_ImmoId",
                table: "Facture");

            migrationBuilder.DropIndex(
                name: "IX_Facture_KlantId",
                table: "Facture");

            migrationBuilder.DropColumn(
                name: "KlantId",
                table: "Immo");

            migrationBuilder.DropColumn(
                name: "ImmoId",
                table: "Facture");

            migrationBuilder.DropColumn(
                name: "KlantId",
                table: "Facture");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Immo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Facture",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Immo_id",
                table: "Facture",
                column: "id",
                principalTable: "Immo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Klant_id",
                table: "Facture",
                column: "id",
                principalTable: "Klant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Immo_Klant_id",
                table: "Immo",
                column: "id",
                principalTable: "Klant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
