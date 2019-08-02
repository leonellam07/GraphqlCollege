using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeApi.DataBase.Migrations
{
    public partial class InicialCollegeApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombrePrimero = table.Column<string>(nullable: true),
                    NombreSegundo = table.Column<string>(nullable: true),
                    ApellidoMaterno = table.Column<string>(nullable: true),
                    ApellidoPaterno = table.Column<string>(nullable: true),
                    FechaCrecimiento = table.Column<DateTime>(nullable: false),
                    Correo = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleNotas",
                columns: table => new
                {
                    Anio = table.Column<int>(nullable: false),
                    Bimestre = table.Column<int>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: false),
                    MateriaId = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Nota = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleNotas", x => new { x.Anio, x.Bimestre, x.MateriaId, x.EstudianteId });
                    table.ForeignKey(
                        name: "FK_DetalleNotas_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleNotas_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleNotas_EstudianteId",
                table: "DetalleNotas",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleNotas_MateriaId",
                table: "DetalleNotas",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleNotas");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Materias");
        }
    }
}
