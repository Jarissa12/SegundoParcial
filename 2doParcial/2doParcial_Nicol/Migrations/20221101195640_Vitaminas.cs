using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2doParcial_Nicol.Migrations
{
    public partial class Vitaminas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cantidad",
                table: "VerdurasDetalles",
                newName: "Cantidad");

            migrationBuilder.AddColumn<int>(
                name: "Existe",
                table: "Vitamina",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "VerdurasDetalles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "VerdurasDetalles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Existe",
                table: "Vitamina");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "VerdurasDetalles");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "VerdurasDetalles");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "VerdurasDetalles",
                newName: "cantidad");
        }
    }
}
