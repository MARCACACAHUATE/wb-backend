using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class EventoandCursomodelscreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Tematica = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Fechainicio = table.Column<DateTime>(name: "Fecha_inicio", type: "timestamp with time zone", nullable: false),
                    Fechafinalizacion = table.Column<DateTime>(name: "Fecha_finalizacion", type: "timestamp with time zone", nullable: false),
                    Espaciosdisponibles = table.Column<int>(name: "Espacios_disponibles", type: "integer", nullable: false),
                    Espaciosrestantes = table.Column<int>(name: "Espacios_restantes", type: "integer", nullable: false),
                    Costoreservacion = table.Column<float>(name: "Costo_reservacion", type: "real", nullable: false),
                    Costototal = table.Column<float>(name: "Costo_total", type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Tematica = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Costoreservacion = table.Column<float>(name: "Costo_reservacion", type: "real", nullable: false),
                    Costototal = table.Column<float>(name: "Costo_total", type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
