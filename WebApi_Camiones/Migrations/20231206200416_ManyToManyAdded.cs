using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Camiones.Migrations
{
    public partial class ManyToManyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rutas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora_llegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cantidad_maxima = table.Column<int>(type: "int", nullable: false),
                    Cantidad_estimada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rutas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "camion_Rutas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRuta = table.Column<int>(type: "int", nullable: false),
                    CamionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_camion_Rutas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_camion_Rutas_camiones_CamionId",
                        column: x => x.CamionId,
                        principalTable: "camiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_camion_Rutas_rutas_IdRuta",
                        column: x => x.IdRuta,
                        principalTable: "rutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_camion_Rutas_CamionId",
                table: "camion_Rutas",
                column: "CamionId");

            migrationBuilder.CreateIndex(
                name: "IX_camion_Rutas_IdRuta",
                table: "camion_Rutas",
                column: "IdRuta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "camion_Rutas");

            migrationBuilder.DropTable(
                name: "rutas");
        }
    }
}
