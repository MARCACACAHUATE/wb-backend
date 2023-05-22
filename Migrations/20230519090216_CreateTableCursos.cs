using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableCursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCursos = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    Tematica = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Detalle = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CostoReservacion = table.Column<int>(type: "integer", nullable: false),
                    CostoTotal = table.Column<int>(type: "integer", nullable: false),
                    Calle = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Municipio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    EstadoCursoName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCursos);
                });

            migrationBuilder.CreateTable(
                name: "CursoSeparacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Firstname = table.Column<string>(name: "First_name", type: "character varying(45)", maxLength: 45, nullable: false),
                    Lastname = table.Column<string>(name: "Last_name", type: "character varying(45)", maxLength: 45, nullable: false),
                    Edad = table.Column<int>(type: "integer", nullable: false),
                    Telefono = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Cantidad_personas_contratadas = table.Column<int>(name: "Cantidad_personas_contratadas", type: "integer", nullable: false),
                    IdCursos = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoSeparacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoSeparacion_Cursos_IdCursos",
                        column: x => x.IdCursos,
                        principalTable: "Cursos",
                        principalColumn: "IdCursos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHasCursos",
                columns: table => new
                {
                    CursosIdCursos = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHasCursos", x => new { x.CursosIdCursos, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserHasCursos_Cursos_CursosIdCursos",
                        column: x => x.CursosIdCursos,
                        principalTable: "Cursos",
                        principalColumn: "IdCursos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHasCursos_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_CursoSeparacion_IdCursos",
                table: "CursoSeparacion",
                column: "IdCursos");

            migrationBuilder.CreateIndex(
                name: "IX_UserHasCursos_UsersId",
                table: "UserHasCursos",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoSeparacion");

            migrationBuilder.DropTable(
                name: "UserHasCursos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
