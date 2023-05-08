using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class updateapartadocursos : Migration
    {
        /// <inheritdoc />
       protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropTable(
        name: "Cursos");

    migrationBuilder.CreateTable(
        name: "Cursos",
        columns: table => new
        {
            idcursos = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
            tematica = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
            detalle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
            fecha_inicio = table.Column<DateTime>(type: "date", nullable: false),
            fecha_fin = table.Column<DateTime>(type: "date", nullable: false),
            costo_reservacion = table.Column<int>(type: "int", nullable: false),
            costo_total = table.Column<int>(type: "int", nullable: false),
            calle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
            numero = table.Column<int>(type: "int", nullable: false),
            municipio = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
            Id_EstadoCurso = table.Column<int>(type: "int", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Cursos", x => x.idcursos);
            table.ForeignKey(
                name: "FK_Cursos_EstadoCursos_Id_EstadoCurso",
                column: x => x.Id_EstadoCurso,
                principalTable: "EstadoCursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateIndex(
        name: "IX_Cursos_Id_EstadoCurso",
        table: "Cursos",
        column: "Id_EstadoCurso");
}

protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Cursos");

        }

    }
}
