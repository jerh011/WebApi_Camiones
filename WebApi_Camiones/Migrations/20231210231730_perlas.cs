using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Camiones.Migrations
{
    public partial class perlas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RutaName",
                table: "rutas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RutaName",
                table: "rutas");
        }
    }
}
