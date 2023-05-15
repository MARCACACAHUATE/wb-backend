using Microsoft.EntityFrameworkCore.Migrations;

namespace wbbackend.Migrations
{
    public partial class CreacionSeparacionCurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CursoSeparacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Last_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Cantidad_personas_contratadas = table.Column<int>(type: "int", nullable: false),
                    CursosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoSeparacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoSeparacion_Cursos_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Cursos",
                        principalColumn: "IdCursos",
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