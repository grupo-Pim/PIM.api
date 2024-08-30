using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RetiradaRelacionamentoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto",
                column: "FornecedorID",
                principalTable: "Fornecedor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto",
                column: "FornecedorID",
                principalTable: "Fornecedor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
