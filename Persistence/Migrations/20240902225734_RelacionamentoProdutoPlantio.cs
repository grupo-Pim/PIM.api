using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoProdutoPlantio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoID",
                table: "Plantio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plantio_ProdutoID",
                table: "Plantio",
                column: "ProdutoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantio_Produto_ProdutoID",
                table: "Plantio",
                column: "ProdutoID",
                principalTable: "Produto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantio_Produto_ProdutoID",
                table: "Plantio");

            migrationBuilder.DropIndex(
                name: "IX_Plantio_ProdutoID",
                table: "Plantio");

            migrationBuilder.DropColumn(
                name: "ProdutoID",
                table: "Plantio");
        }
    }
}
