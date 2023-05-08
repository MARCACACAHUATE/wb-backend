using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbbackend.Migrations
{
    public partial class creaciontablacursoseparacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CursoSeparacion",
                columns: table => new
                {
                    idcurso_separacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(45)", nullable: true),
                    last_name = table.Column<string>(type: "varchar(45)", nullable: true),
                    edad = table.Column<int>(type: "int", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "varchar(45)", nullable: true),
                    cantidad_personas_contratadas = table.Column<int>(type: "int", nullable: true),
                    CursosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoSeparacion", x => x.idcurso_separacion);
                    table.ForeignKey(
                        name: "FK_CursoSeparacion_Cursos_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoSeparacion_CursosId",
                table: "CursoSeparacion",
                column: "CursosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoSeparacion");
        }
    }
}
