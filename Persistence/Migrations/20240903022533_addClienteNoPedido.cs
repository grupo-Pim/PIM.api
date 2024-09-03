using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addClienteNoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosEntidade_Empresa_EmpresaID",
                table: "PedidosEntidade");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosEntidade_Produto_ProdutoID",
                table: "PedidosEntidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidosEntidade",
                table: "PedidosEntidade");

            migrationBuilder.RenameTable(
                name: "PedidosEntidade",
                newName: "Pedidos");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosEntidade_ProdutoID",
                table: "Pedidos",
                newName: "IX_Pedidos_ProdutoID");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosEntidade_EmpresaID",
                table: "Pedidos",
                newName: "IX_Pedidos_EmpresaID");

            migrationBuilder.AddColumn<int>(
                name: "ClienteID",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteID",
                table: "Pedidos",
                column: "ClienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteID",
                table: "Pedidos",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Empresa_EmpresaID",
                table: "Pedidos",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Produto_ProdutoID",
                table: "Pedidos",
                column: "ProdutoID",
                principalTable: "Produto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteID",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Empresa_EmpresaID",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Produto_ProdutoID",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteID",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ClienteID",
                table: "Pedidos");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "PedidosEntidade");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ProdutoID",
                table: "PedidosEntidade",
                newName: "IX_PedidosEntidade_ProdutoID");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_EmpresaID",
                table: "PedidosEntidade",
                newName: "IX_PedidosEntidade_EmpresaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidosEntidade",
                table: "PedidosEntidade",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosEntidade_Empresa_EmpresaID",
                table: "PedidosEntidade",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosEntidade_Produto_ProdutoID",
                table: "PedidosEntidade",
                column: "ProdutoID",
                principalTable: "Produto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
