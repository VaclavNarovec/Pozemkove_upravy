using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PozemkoveUpravy.Migrations
{
    /// <inheritdoc />
    public partial class PozemkoveUpravyMigrace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OceneniPorostu_Pozemek_PozemekId",
                table: "OceneniPorostu");

            migrationBuilder.DropForeignKey(
                name: "FK_OceneniPozemku_Pozemek_PozemekId",
                table: "OceneniPozemku");

            migrationBuilder.DropForeignKey(
                name: "FK_Pozemek_Vlastnik_VlastnikId",
                table: "Pozemek");

            migrationBuilder.DropForeignKey(
                name: "FK_Vlastnik_PozemkovaUprava_PozemkovaUpravaId",
                table: "Vlastnik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vlastnik",
                table: "Vlastnik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PozemkovaUprava",
                table: "PozemkovaUprava");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pozemek",
                table: "Pozemek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OceneniPozemku",
                table: "OceneniPozemku");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OceneniPorostu",
                table: "OceneniPorostu");

            migrationBuilder.RenameTable(
                name: "Vlastnik",
                newName: "Vlastnici");

            migrationBuilder.RenameTable(
                name: "PozemkovaUprava",
                newName: "PozemkoveUpravy");

            migrationBuilder.RenameTable(
                name: "Pozemek",
                newName: "Pozemky");

            migrationBuilder.RenameTable(
                name: "OceneniPozemku",
                newName: "OceneniPozemkuA");

            migrationBuilder.RenameTable(
                name: "OceneniPorostu",
                newName: "OceneniPorostuA");

            migrationBuilder.RenameIndex(
                name: "IX_Vlastnik_PozemkovaUpravaId",
                table: "Vlastnici",
                newName: "IX_Vlastnici_PozemkovaUpravaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pozemek_VlastnikId",
                table: "Pozemky",
                newName: "IX_Pozemky_VlastnikId");

            migrationBuilder.RenameIndex(
                name: "IX_OceneniPozemku_PozemekId",
                table: "OceneniPozemkuA",
                newName: "IX_OceneniPozemkuA_PozemekId");

            migrationBuilder.RenameIndex(
                name: "IX_OceneniPorostu_PozemekId",
                table: "OceneniPorostuA",
                newName: "IX_OceneniPorostuA_PozemekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vlastnici",
                table: "Vlastnici",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PozemkoveUpravy",
                table: "PozemkoveUpravy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pozemky",
                table: "Pozemky",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OceneniPozemkuA",
                table: "OceneniPozemkuA",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OceneniPorostuA",
                table: "OceneniPorostuA",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OceneniPorostuA_Pozemky_PozemekId",
                table: "OceneniPorostuA",
                column: "PozemekId",
                principalTable: "Pozemky",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OceneniPozemkuA_Pozemky_PozemekId",
                table: "OceneniPozemkuA",
                column: "PozemekId",
                principalTable: "Pozemky",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pozemky_Vlastnici_VlastnikId",
                table: "Pozemky",
                column: "VlastnikId",
                principalTable: "Vlastnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vlastnici_PozemkoveUpravy_PozemkovaUpravaId",
                table: "Vlastnici",
                column: "PozemkovaUpravaId",
                principalTable: "PozemkoveUpravy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OceneniPorostuA_Pozemky_PozemekId",
                table: "OceneniPorostuA");

            migrationBuilder.DropForeignKey(
                name: "FK_OceneniPozemkuA_Pozemky_PozemekId",
                table: "OceneniPozemkuA");

            migrationBuilder.DropForeignKey(
                name: "FK_Pozemky_Vlastnici_VlastnikId",
                table: "Pozemky");

            migrationBuilder.DropForeignKey(
                name: "FK_Vlastnici_PozemkoveUpravy_PozemkovaUpravaId",
                table: "Vlastnici");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vlastnici",
                table: "Vlastnici");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pozemky",
                table: "Pozemky");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PozemkoveUpravy",
                table: "PozemkoveUpravy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OceneniPozemkuA",
                table: "OceneniPozemkuA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OceneniPorostuA",
                table: "OceneniPorostuA");

            migrationBuilder.RenameTable(
                name: "Vlastnici",
                newName: "Vlastnik");

            migrationBuilder.RenameTable(
                name: "Pozemky",
                newName: "Pozemek");

            migrationBuilder.RenameTable(
                name: "PozemkoveUpravy",
                newName: "PozemkovaUprava");

            migrationBuilder.RenameTable(
                name: "OceneniPozemkuA",
                newName: "OceneniPozemku");

            migrationBuilder.RenameTable(
                name: "OceneniPorostuA",
                newName: "OceneniPorostu");

            migrationBuilder.RenameIndex(
                name: "IX_Vlastnici_PozemkovaUpravaId",
                table: "Vlastnik",
                newName: "IX_Vlastnik_PozemkovaUpravaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pozemky_VlastnikId",
                table: "Pozemek",
                newName: "IX_Pozemek_VlastnikId");

            migrationBuilder.RenameIndex(
                name: "IX_OceneniPozemkuA_PozemekId",
                table: "OceneniPozemku",
                newName: "IX_OceneniPozemku_PozemekId");

            migrationBuilder.RenameIndex(
                name: "IX_OceneniPorostuA_PozemekId",
                table: "OceneniPorostu",
                newName: "IX_OceneniPorostu_PozemekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vlastnik",
                table: "Vlastnik",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pozemek",
                table: "Pozemek",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PozemkovaUprava",
                table: "PozemkovaUprava",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OceneniPozemku",
                table: "OceneniPozemku",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OceneniPorostu",
                table: "OceneniPorostu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OceneniPorostu_Pozemek_PozemekId",
                table: "OceneniPorostu",
                column: "PozemekId",
                principalTable: "Pozemek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OceneniPozemku_Pozemek_PozemekId",
                table: "OceneniPozemku",
                column: "PozemekId",
                principalTable: "Pozemek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pozemek_Vlastnik_VlastnikId",
                table: "Pozemek",
                column: "VlastnikId",
                principalTable: "Vlastnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vlastnik_PozemkovaUprava_PozemkovaUpravaId",
                table: "Vlastnik",
                column: "PozemkovaUpravaId",
                principalTable: "PozemkovaUprava",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
