using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbbackend.Migrations
{
    public partial class UpdateApartadoCursos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Espacios_disponibles",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Espacios_restantes",
                table: "Cursos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cursos",
                newName: "IdCursos");

            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Cursos",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "Cursos",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Cursos",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.RenameColumn(
                name: "Fecha_inicio",
                table: "Cursos",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "Fecha_finalizacion",
                table: "Cursos",
                newName: "FechaFin");

            migrationBuilder.AddColumn<int>(
                name: "IdEstadoCurso",
                table: "Cursos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicio",
                table: "Cursos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaFin",
                table: "Cursos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

       protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropColumn(
        name: "Calle",
        table: "Cursos");

    migrationBuilder.DropColumn(
        name: "Detalle",
        table: "Cursos");

    migrationBuilder.DropColumn(
        name: "Municipio",
        table: "Cursos");

    migrationBuilder.DropColumn(
        name: "IdEstadoCurso",
        table: "Cursos");

    migrationBuilder.RenameColumn(
        name: "IdCursos",
        table: "Cursos",
        newName: "Id");

    migrationBuilder.RenameColumn(
        name: "FechaInicio",
        table: "Cursos",
        newName: "Fecha_inicio");

    migrationBuilder.RenameColumn(
        name: "FechaFin",
        table: "Cursos",
        newName: "Fecha_finalizacion");

    migrationBuilder.AlterColumn<DateTime>(
        name: "Fecha_inicio",
        table: "Cursos",
        type: "timestamp with time zone",
        nullable: false,
        oldClrType: typeof(DateTime));

    migrationBuilder.AlterColumn<DateTime>(
        name: "Fecha_finalizacion",
        table: "Cursos",
        type: "timestamp with time zone",
        nullable: false,
        oldClrType: typeof(DateTime));

    migrationBuilder.AddColumn<string>(
        name: "Direccion",
        table: "Cursos",
        type: "text",
        nullable: false);

    migrationBuilder.AddColumn<int>(
        name: "Espacios_disponibles",
        table: "Cursos",
        type: "integer",
        nullable: false);

    migrationBuilder.AddColumn<int>(
        name: "Espacios_restantes",
        table: "Cursos",
        type: "integer",
        nullable: false);
        }
    }
}
