using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class DropColumnIdCursosfromCursoSeparacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoSeparacion_Cursos_CursosIdCursos",
                table: "CursoSeparacion");

            migrationBuilder.DropColumn(
                name: "IdCursos",
                table: "CursoSeparacion");

            migrationBuilder.AlterColumn<int>(
                name: "CursosIdCursos",
                table: "CursoSeparacion",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoSeparacion_Cursos_CursosIdCursos",
                table: "CursoSeparacion",
                column: "CursosIdCursos",
                principalTable: "Cursos",
                principalColumn: "IdCursos",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoSeparacion_Cursos_CursosIdCursos",
                table: "CursoSeparacion");

            migrationBuilder.AlterColumn<int>(
                name: "CursosIdCursos",
                table: "CursoSeparacion",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "IdCursos",
                table: "CursoSeparacion",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoSeparacion_Cursos_CursosIdCursos",
                table: "CursoSeparacion",
                column: "CursosIdCursos",
                principalTable: "Cursos",
                principalColumn: "IdCursos");
        }
    }
}
