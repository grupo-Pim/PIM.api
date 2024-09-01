using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TBProdutoFornecedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Empresa_EmpresaID",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Municipios_MunicipioID",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Empresa_EmpresaID",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_FornecedorID",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "FornecedorID",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "ValorKG",
                table: "Produto",
                newName: "ValorVendaKG");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Produto",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "ProdutoFornecedor",
                columns: table => new
                {
                    FornecedorID = table.Column<int>(type: "int", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoFornecedor", x => new { x.FornecedorID, x.ProdutoID });
                    table.ForeignKey(
                        name: "FK_ProdutoFornecedor_Fornecedor_FornecedorID",
                        column: x => x.FornecedorID,
                        principalTable: "Fornecedor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutoFornecedor_Produto_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFornecedor_ProdutoID",
                table: "ProdutoFornecedor",
                column: "ProdutoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Empresa_EmpresaID",
                table: "Fornecedor",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Municipios_MunicipioID",
                table: "Fornecedor",
                column: "MunicipioID",
                principalTable: "Municipios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Empresa_EmpresaID",
                table: "Produto",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Empresa_EmpresaID",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Municipios_MunicipioID",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Empresa_EmpresaID",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "ProdutoFornecedor");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "ValorVendaKG",
                table: "Produto",
                newName: "ValorKG");

            migrationBuilder.AddColumn<int>(
                name: "FornecedorID",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorID",
                table: "Produto",
                column: "FornecedorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Empresa_EmpresaID",
                table: "Fornecedor",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Municipios_MunicipioID",
                table: "Fornecedor",
                column: "MunicipioID",
                principalTable: "Municipios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Empresa_EmpresaID",
                table: "Produto",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto",
                column: "FornecedorID",
                principalTable: "Fornecedor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
