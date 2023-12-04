using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Camiones.Migrations
{
    public partial class PrimeraRelacion_CamionerosCamion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "camiones",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Placas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_camiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "camionero_Camiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CamionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CamioneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_camionero_Camiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_camionero_Camiones_camioneros_CamioneroId",
                        column: x => x.CamioneroId,
                        principalTable: "camioneros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_camionero_Camiones_camiones_CamionId",
                        column: x => x.CamionId,
                        principalTable: "camiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_camionero_Camiones_CamioneroId",
                table: "camionero_Camiones",
                column: "CamioneroId");

            migrationBuilder.CreateIndex(
                name: "IX_camionero_Camiones_CamionId",
                table: "camionero_Camiones",
                column: "CamionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "camionero_Camiones");

            migrationBuilder.DropTable(
                name: "camiones");
        }
    }
}
