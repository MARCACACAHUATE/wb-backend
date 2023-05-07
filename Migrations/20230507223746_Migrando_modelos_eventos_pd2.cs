using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class Migrandomodeloseventospd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Municipios_MunicipioId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_MunicipioId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "Eventos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                table: "Eventos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_MunicipioId",
                table: "Eventos",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Municipios_MunicipioId",
                table: "Eventos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id");
        }
    }
}
