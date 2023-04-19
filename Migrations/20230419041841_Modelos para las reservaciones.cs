using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class Modelosparalasreservaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservacionCurso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Iduser = table.Column<int>(name: "Id_user", type: "integer", nullable: false),
                    Idcurso = table.Column<int>(name: "Id_curso", type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservacionCurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservacionCurso_Cursos_Id_curso",
                        column: x => x.Idcurso,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservacionCurso_Users_Id_user",
                        column: x => x.Iduser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservacionEvento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Iduser = table.Column<int>(name: "Id_user", type: "integer", nullable: false),
                    Idevento = table.Column<int>(name: "Id_evento", type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservacionEvento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservacionEvento_Eventos_Id_evento",
                        column: x => x.Idevento,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservacionEvento_Users_Id_user",
                        column: x => x.Iduser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservacionCurso_Id_curso",
                table: "ReservacionCurso",
                column: "Id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_ReservacionCurso_Id_user",
                table: "ReservacionCurso",
                column: "Id_user");

            migrationBuilder.CreateIndex(
                name: "IX_ReservacionEvento_Id_evento",
                table: "ReservacionEvento",
                column: "Id_evento");

            migrationBuilder.CreateIndex(
                name: "IX_ReservacionEvento_Id_user",
                table: "ReservacionEvento",
                column: "Id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservacionCurso");

            migrationBuilder.DropTable(
                name: "ReservacionEvento");
        }
    }
}
