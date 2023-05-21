using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbbackend.Migrations
{
    /// <inheritdoc />
    public partial class MoveConfirmacionPagofromeventotoseparacionandchangetypedatatelefono : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmaciónPago",
                table: "Eventos");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "TypeUser",
                table: "TipoUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "ConfirmaciónPago",
                table: "EventoSeparacions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmaciónPago",
                table: "EventoSeparacions");

            migrationBuilder.AlterColumn<int>(
                name: "Telefono",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "TypeUser",
                table: "TipoUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "ConfirmaciónPago",
                table: "Eventos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
