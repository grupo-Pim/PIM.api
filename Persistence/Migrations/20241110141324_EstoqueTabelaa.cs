using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EstoqueTabelaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueEntidade_Produto_ProdutoID",
                table: "EstoqueEntidade");

            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueEntidade_Usuarios_UsuarioID",
                table: "EstoqueEntidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstoqueEntidade",
                table: "EstoqueEntidade");

            migrationBuilder.RenameTable(
                name: "EstoqueEntidade",
                newName: "Estoque");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueEntidade_UsuarioID",
                table: "Estoque",
                newName: "IX_Estoque_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueEntidade_ProdutoID",
                table: "Estoque",
                newName: "IX_Estoque_ProdutoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Produto_ProdutoID",
                table: "Estoque",
                column: "ProdutoID",
                principalTable: "Produto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Usuarios_UsuarioID",
                table: "Estoque",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Produto_ProdutoID",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Usuarios_UsuarioID",
                table: "Estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque");

            migrationBuilder.RenameTable(
                name: "Estoque",
                newName: "EstoqueEntidade");

            migrationBuilder.RenameIndex(
                name: "IX_Estoque_UsuarioID",
                table: "EstoqueEntidade",
                newName: "IX_EstoqueEntidade_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Estoque_ProdutoID",
                table: "EstoqueEntidade",
                newName: "IX_EstoqueEntidade_ProdutoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstoqueEntidade",
                table: "EstoqueEntidade",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueEntidade_Produto_ProdutoID",
                table: "EstoqueEntidade",
                column: "ProdutoID",
                principalTable: "Produto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueEntidade_Usuarios_UsuarioID",
                table: "EstoqueEntidade",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
