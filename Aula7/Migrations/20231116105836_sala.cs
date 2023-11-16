using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula7.Migrations
{
    /// <inheritdoc />
    public partial class sala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idSala",
                table: "Reservas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idUsuario",
                table: "Reservas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idSala",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "idUsuario",
                table: "Reservas");
        }
    }
}
