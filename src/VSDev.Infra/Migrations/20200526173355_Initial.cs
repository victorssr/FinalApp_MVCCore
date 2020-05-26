using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VSDev.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROFESSOR",
                columns: table => new
                {
                    ID_PROFESSOR = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    NOM_PROFESSOR = table.Column<string>(maxLength: 300, nullable: false),
                    NUM_DOCUMENTO = table.Column<string>(maxLength: 14, nullable: false),
                    DAT_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    NUM_GENERO = table.Column<int>(nullable: false),
                    END_EMAIL = table.Column<string>(maxLength: 50, nullable: false),
                    NUM_CELULAR = table.Column<string>(maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFESSOR", x => x.ID_PROFESSOR);
                });

            migrationBuilder.CreateTable(
                name: "CURSO",
                columns: table => new
                {
                    ID_CURSO = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_PROFESSOR = table.Column<Guid>(nullable: false),
                    DSC_TITULO = table.Column<string>(maxLength: 300, nullable: false),
                    DSC_CURSO = table.Column<string>(type: "NTEXT", nullable: false),
                    NOM_IMAGEM = table.Column<string>(maxLength: 100, nullable: false),
                    QTD_DURACAO = table.Column<decimal>(type: "DECIMAL(9, 2)", nullable: false),
                    IND_ATIVO = table.Column<bool>(nullable: false),
                    DuracaoEmHoras = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURSO", x => x.ID_CURSO);
                    table.ForeignKey(
                        name: "FK_CURSO_PROFESSOR_ID_PROFESSOR",
                        column: x => x.ID_PROFESSOR,
                        principalTable: "PROFESSOR",
                        principalColumn: "ID_PROFESSOR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID_ENDERECO = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_PROFESSOR = table.Column<Guid>(nullable: false),
                    DSC_LOGRADOURO = table.Column<string>(maxLength: 200, nullable: false),
                    NUM_ENDERECO = table.Column<string>(maxLength: 10, nullable: false),
                    DSC_COMPLEMENTO = table.Column<string>(maxLength: 10, nullable: true),
                    NOM_BAIRRO = table.Column<string>(maxLength: 200, nullable: false),
                    NOM_CIDADE = table.Column<string>(maxLength: 200, nullable: false),
                    NUM_CEP = table.Column<string>(maxLength: 8, nullable: false),
                    Cep = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.ID_ENDERECO);
                    table.ForeignKey(
                        name: "FK_ENDERECO_PROFESSOR_ID_PROFESSOR",
                        column: x => x.ID_PROFESSOR,
                        principalTable: "PROFESSOR",
                        principalColumn: "ID_PROFESSOR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CURSO_ID_PROFESSOR",
                table: "CURSO",
                column: "ID_PROFESSOR");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_ID_PROFESSOR",
                table: "ENDERECO",
                column: "ID_PROFESSOR",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CURSO");

            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "PROFESSOR");
        }
    }
}
