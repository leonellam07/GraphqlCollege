using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeApi.DataBase.Migrations
{
    public partial class update_fecha_nacimiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaCrecimiento",
                table: "Estudiantes",
                newName: "FechaNacimiento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Estudiantes",
                newName: "FechaCrecimiento");
        }
    }
}
