using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeApi.DataBase.Migrations
{
    public partial class etniaestudiantemodificado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Etnia",
                table: "Estudiantes",
                newName: "EtniaXD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EtniaXD",
                table: "Estudiantes",
                newName: "Etnia");
        }
    }
}
