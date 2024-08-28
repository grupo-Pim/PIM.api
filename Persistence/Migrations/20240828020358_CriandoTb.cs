using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UFID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Municipios_Estados_UFID",
                        column: x => x.UFID,
                        principalTable: "Estados",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoEmpresa = table.Column<int>(type: "int", nullable: false),
                    PossuiFilial = table.Column<bool>(type: "bit", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MunicipioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Empresa_Municipios_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funcao = table.Column<int>(type: "int", nullable: false),
                    Acesso = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_MunicipioID",
                table: "Empresa",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_UFID",
                table: "Municipios",
                column: "UFID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaID",
                table: "Usuarios",
                column: "EmpresaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
