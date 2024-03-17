using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGptiCelular.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPlanesMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Megas = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Renta = table.Column<double>(type: "float", nullable: false),
                    Comision = table.Column<double>(type: "float", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planes");
        }
    }
}
