using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioTecnicoUnicont.Data.Migrations
{
    /// <inheritdoc />
    public partial class scriptdesafiotecnico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRESTADOR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRESTADOR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SERVICO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    VALOR = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TOMADOR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOMADOR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NOTAFISCAL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMNOTA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DATAEMISSAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdServico = table.Column<int>(type: "int", nullable: false),
                    IdPrestador = table.Column<int>(type: "int", nullable: false),
                    IdTomador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTAFISCAL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NOTA_PRESTADOR",
                        column: x => x.IdPrestador,
                        principalTable: "PRESTADOR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTA_SERVICO",
                        column: x => x.IdServico,
                        principalTable: "SERVICO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTA_TOMADOR",
                        column: x => x.IdTomador,
                        principalTable: "TOMADOR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NOTAFISCAL_IdPrestador",
                table: "NOTAFISCAL",
                column: "IdPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_NOTAFISCAL_IdServico",
                table: "NOTAFISCAL",
                column: "IdServico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NOTAFISCAL_IdTomador",
                table: "NOTAFISCAL",
                column: "IdTomador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTAFISCAL");

            migrationBuilder.DropTable(
                name: "PRESTADOR");

            migrationBuilder.DropTable(
                name: "SERVICO");

            migrationBuilder.DropTable(
                name: "TOMADOR");
        }
    }
}
