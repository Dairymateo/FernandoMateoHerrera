using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FernandoMateoHerrera.Migrations
{
    /// <inheritdoc />
    public partial class FernandoMateoHerreraVedoya : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    CarreraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Campus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.CarreraId);
                });

            migrationBuilder.CreateTable(
                name: "MHerrera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ecuatoriano = table.Column<bool>(type: "bit", nullable: false),
                    TimpoPromedio = table.Column<double>(type: "float", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHerrera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MHerrera_Carrera_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carrera",
                        principalColumn: "CarreraId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MHerrera_CarreraId",
                table: "MHerrera",
                column: "CarreraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MHerrera");

            migrationBuilder.DropTable(
                name: "Carrera");
        }
    }
}
