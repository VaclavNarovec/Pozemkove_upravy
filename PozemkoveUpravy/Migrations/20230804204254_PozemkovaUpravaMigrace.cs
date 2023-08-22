using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PozemkoveUpravy.Migrations
{
    /// <inheritdoc />
    public partial class PozemkovaUpravaMigrace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PozemkovaUprava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Okres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Katastralni_uzemi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozemkovy_urad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Forma_pozemkove_upravy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pocatek = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Konec = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozemkovaUprava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vlastnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozemkovaUpravaId = table.Column<int>(type: "int", nullable: false),
                    Jmeno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijmeni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    Obec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cislo_popisne = table.Column<int>(type: "int", nullable: false),
                    PSC = table.Column<int>(type: "int", nullable: false),
                    List_vlastnictvi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vlastnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vlastnik_PozemkovaUprava_PozemkovaUpravaId",
                        column: x => x.PozemkovaUpravaId,
                        principalTable: "PozemkovaUprava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pozemek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VlastnikId = table.Column<int>(type: "int", nullable: false),
                    List_vlastnictvi = table.Column<int>(type: "int", nullable: false),
                    Cislo_pozemku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Druh_pozemku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zpusob_vyuziti_nemovitosti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zpusob_ochrany_nemovitosti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vymera_v_m2 = table.Column<float>(type: "real", nullable: false),
                    Vzdalenost_v_m = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozemek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pozemek_Vlastnik_VlastnikId",
                        column: x => x.VlastnikId,
                        principalTable: "Vlastnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OceneniPorostu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozemekId = table.Column<int>(type: "int", nullable: false),
                    VlastnikId = table.Column<int>(type: "int", nullable: false),
                    Druh_porostu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vymera_v_m2 = table.Column<float>(type: "real", nullable: false),
                    Cena_v_Kc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OceneniPorostu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OceneniPorostu_Pozemek_PozemekId",
                        column: x => x.PozemekId,
                        principalTable: "Pozemek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OceneniPozemku",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozemekId = table.Column<int>(type: "int", nullable: false),
                    VlastnikId = table.Column<int>(type: "int", nullable: false),
                    BPEJ = table.Column<int>(type: "int", nullable: false),
                    Vymera_v_m2 = table.Column<float>(type: "real", nullable: false),
                    Cena_v_Kc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OceneniPozemku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OceneniPozemku_Pozemek_PozemekId",
                        column: x => x.PozemekId,
                        principalTable: "Pozemek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OceneniPorostu_PozemekId",
                table: "OceneniPorostu",
                column: "PozemekId");

            migrationBuilder.CreateIndex(
                name: "IX_OceneniPozemku_PozemekId",
                table: "OceneniPozemku",
                column: "PozemekId");

            migrationBuilder.CreateIndex(
                name: "IX_Pozemek_VlastnikId",
                table: "Pozemek",
                column: "VlastnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Vlastnik_PozemkovaUpravaId",
                table: "Vlastnik",
                column: "PozemkovaUpravaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OceneniPorostu");

            migrationBuilder.DropTable(
                name: "OceneniPozemku");

            migrationBuilder.DropTable(
                name: "Pozemek");

            migrationBuilder.DropTable(
                name: "Vlastnik");

            migrationBuilder.DropTable(
                name: "PozemkovaUprava");
        }
    }
}
