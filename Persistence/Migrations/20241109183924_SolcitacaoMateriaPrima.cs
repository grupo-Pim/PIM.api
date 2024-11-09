using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SolcitacaoMateriaPrima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolcitacaoCompraMateriaPrima",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    UsuarioSolcitanteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolcitacaoCompraMateriaPrima", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SolcitacaoCompraMateriaPrima_Usuarios_UsuarioSolcitanteID",
                        column: x => x.UsuarioSolcitanteID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolcitacaoCompraMateriaPrima_UsuarioSolcitanteID",
                table: "SolcitacaoCompraMateriaPrima",
                column: "UsuarioSolcitanteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolcitacaoCompraMateriaPrima");
        }
    }
}
