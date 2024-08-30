using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tabelaRelacionamentoNN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutoFornecedor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FornecedorID = table.Column<int>(type: "int", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoFornecedor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProdutoFornecedor_Fornecedor_FornecedorID",
                        column: x => x.FornecedorID,
                        principalTable: "Fornecedor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoFornecedor_Produto_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFornecedor_FornecedorID",
                table: "ProdutoFornecedor",
                column: "FornecedorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFornecedor_ProdutoID",
                table: "ProdutoFornecedor",
                column: "ProdutoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoFornecedor");
        }
    }
}
