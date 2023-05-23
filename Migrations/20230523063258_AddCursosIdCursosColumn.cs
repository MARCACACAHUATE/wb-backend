using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class AddCursosIdCursosColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursosIdCursos",
                table: "CursoSeparacion",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserHasCursos",
                columns: table => new
                {
                    CursosIdCursos = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursosUser", x => new { x.CursosIdCursos, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CursosUser_Cursos_CursosIdCursos",
                        column: x => x.CursosIdCursos,
                        principalTable: "Cursos",
                        principalColumn: "IdCursos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursosUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoSeparacion_CursosIdCursos",
                table: "CursoSeparacion",
                column: "CursosIdCursos");

            migrationBuilder.CreateIndex(
                name: "IX_CursosUser_UsersId",
                table: "CursosUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoSeparacion_Cursos_CursosIdCursos",
                table: "CursoSeparacion",
                column: "CursosIdCursos",
                principalTable: "Cursos",
                principalColumn: "IdCursos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoSeparacion_Cursos_CursosIdCursos",
                table: "CursoSeparacion");

            migrationBuilder.DropTable(
                name: "CursosUser");

            migrationBuilder.DropIndex(
                name: "IX_CursoSeparacion_CursosIdCursos",
                table: "CursoSeparacion");

            migrationBuilder.DropColumn(
                name: "CursosIdCursos",
                table: "CursoSeparacion");
        }
    }
}
