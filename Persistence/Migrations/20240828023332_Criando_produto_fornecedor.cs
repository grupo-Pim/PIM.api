using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Criandoprodutofornecedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Municipios_MunicipioID",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Estados_UFID",
                table: "Municipios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Empresa_EmpresaID",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Municipios_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    FornecedorID = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorKG = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produto_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_FornecedorID",
                        column: x => x.FornecedorID,
                        principalTable: "Fornecedor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_EmpresaID",
                table: "Fornecedor",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_MunicipioID",
                table: "Fornecedor",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EmpresaID",
                table: "Produto",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorID",
                table: "Produto",
                column: "FornecedorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Municipios_MunicipioID",
                table: "Empresa",
                column: "MunicipioID",
                principalTable: "Municipios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Estados_UFID",
                table: "Municipios",
                column: "UFID",
                principalTable: "Estados",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Empresa_EmpresaID",
                table: "Usuarios",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Municipios_MunicipioID",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Estados_UFID",
                table: "Municipios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Empresa_EmpresaID",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Municipios_MunicipioID",
                table: "Empresa",
                column: "MunicipioID",
                principalTable: "Municipios",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Estados_UFID",
                table: "Municipios",
                column: "UFID",
                principalTable: "Estados",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Empresa_EmpresaID",
                table: "Usuarios",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "ID");
        }
    }
}
