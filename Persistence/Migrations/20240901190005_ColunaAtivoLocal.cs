using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ColunaAtivoLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "LocalPlantio",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "LocalPlantio");
        }
    }
}
