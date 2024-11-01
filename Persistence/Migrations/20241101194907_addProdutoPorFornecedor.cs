using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addProdutoPorFornecedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropIndex(
                name: "IX_Produto_FornecedorID",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "FornecedorID",
                table: "Produto");
        }
    }
}
