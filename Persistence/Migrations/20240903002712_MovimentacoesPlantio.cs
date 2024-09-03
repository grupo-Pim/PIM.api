using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MovimentacoesPlantio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovimentacoesPlantio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorID = table.Column<int>(type: "int", nullable: false),
                    PlantioID = table.Column<int>(type: "int", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EtapaAtualizada = table.Column<byte>(type: "tinyint", nullable: false),
                    EtapaAntiga = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacoesPlantio", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovimentacoesPlantio_Colaboradores_ColaboradorID",
                        column: x => x.ColaboradorID,
                        principalTable: "Colaboradores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimentacoesPlantio_Plantio_PlantioID",
                        column: x => x.PlantioID,
                        principalTable: "Plantio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesPlantio_ColaboradorID",
                table: "MovimentacoesPlantio",
                column: "ColaboradorID");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesPlantio_PlantioID",
                table: "MovimentacoesPlantio",
                column: "PlantioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacoesPlantio");
        }
    }
}
