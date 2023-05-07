using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class Migrandomodeloseventospd3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Eventos_Id_Municipio",
                table: "Eventos",
                column: "Id_Municipio");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Municipios_Id_Municipio",
                table: "Eventos",
                column: "Id_Municipio",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Municipios_Id_Municipio",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_Id_Municipio",
                table: "Eventos");
        }
    }
}
