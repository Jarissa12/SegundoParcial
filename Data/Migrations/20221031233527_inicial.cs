using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2doParcial_Nicol.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vitaminas",
                columns: table => new
                {
                    VitaminaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitaminas", x => x.VitaminaId);
                });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Nombre" },
                values: new object[] { 1, "vitamina A" });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Nombre" },
                values: new object[] { 2, "vitamina c" });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Nombre" },
                values: new object[] { 3, "vitamina D" });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Nombre" },
                values: new object[] { 4, "vitamina E" });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Nombre" },
                values: new object[] { 5, "vitamina F" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vitaminas");
        }
    }
}
