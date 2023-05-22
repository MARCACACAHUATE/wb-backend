using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class Cambiandoaladbproduccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservacionEvento");

            migrationBuilder.DropColumn(
                name: "Is_admin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Is_staff",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Users",
                newName: "Numero");

            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Users",
                type: "text",
                nullable: true);


            migrationBuilder.AddColumn<int>(
                name: "Id_TipoUser",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Users",
                type: "text",
                nullable: true);


            migrationBuilder.CreateTable(
                name: "TipoUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeUser = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsers", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "UserHasEventos",
                columns: table => new
                {
                    EventosId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHasEventos", x => new { x.EventosId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserHasEventos_Eventos_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHasEventos_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_TipoUser",
                table: "Users",
                column: "Id_TipoUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserHasEventos_UsersId",
                table: "UserHasEventos",
                column: "UsersId");


            migrationBuilder.AddForeignKey(
                name: "FK_Users_TipoUsers_Id_TipoUser",
                table: "Users",
                column: "Id_TipoUser",
                principalTable: "TipoUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TipoUsers_Id_TipoUser",
                table: "Users");

            migrationBuilder.DropTable(
                name: "TipoUsers");

            migrationBuilder.DropTable(
                name: "UserHasEventos");


            migrationBuilder.DropIndex(
                name: "IX_Users_Id_TipoUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Users");


            migrationBuilder.DropColumn(
                name: "Id_TipoUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Users",
                newName: "Direccion");

            migrationBuilder.AddColumn<bool>(
                name: "Is_admin",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Is_staff",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");


            migrationBuilder.CreateTable(
                name: "ReservacionEvento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Idevento = table.Column<int>(name: "Id_evento", type: "integer", nullable: false),
                    Iduser = table.Column<int>(name: "Id_user", type: "integer", nullable: false),
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
                name: "IX_ReservacionEvento_Id_evento",
                table: "ReservacionEvento",
                column: "Id_evento");

            migrationBuilder.CreateIndex(
                name: "IX_ReservacionEvento_Id_user",
                table: "ReservacionEvento",
                column: "Id_user");
        }
    }
}
