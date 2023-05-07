using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class Migrandomodeloseventospd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "Tematica",
                table: "Eventos",
                newName: "Servicios");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Eventos",
                newName: "Ocasion");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Eventos",
                newName: "Estado");

            migrationBuilder.AddColumn<string>(
                name: "ColorGlobos",
                table: "Eventos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "CostoEnvioMaterial",
                table: "Eventos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Id_Municipio",
                table: "Eventos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Mobiliario",
                table: "Eventos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombrePaquete",
                table: "Eventos",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventoSeparacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    HoraEvento = table.Column<string>(type: "text", nullable: false),
                    HoraMontaje = table.Column<string>(type: "text", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Calle = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    Colonia = table.Column<string>(type: "text", nullable: false),
                    IdEvento = table.Column<int>(name: "Id_Evento", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoSeparacions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventoSeparacions_Eventos_Id_Evento",
                        column: x => x.IdEvento,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreMunicipio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_Id_Municipio",
                table: "Eventos",
                column: "Id_Municipio");

            migrationBuilder.CreateIndex(
                name: "IX_EventoSeparacions_Id_Evento",
                table: "EventoSeparacions",
                column: "Id_Evento",
                unique: true);

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

            migrationBuilder.DropTable(
                name: "EventoSeparacions");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_Id_Municipio",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "ColorGlobos",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "CostoEnvioMaterial",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Id_Municipio",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Mobiliario",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "NombrePaquete",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "Servicios",
                table: "Eventos",
                newName: "Tematica");

            migrationBuilder.RenameColumn(
                name: "Ocasion",
                table: "Eventos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Eventos",
                newName: "Direccion");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Eventos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
