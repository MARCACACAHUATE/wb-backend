using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class CambiarRelacionCursoCursoSeparacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoSeparacion_Cursos_IdCursos",
                table: "CursoSeparacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_CursoSeparacion_Cursos_IdCursos",
                table: "CursoSeparacion",
                column: "IdCursos",
                principalTable: "Cursos",
                principalColumn: "IdCursos",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
