using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeApi.DataBase.Migrations
{
    public partial class etniaestudiante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Etnia",
                table: "Estudiantes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Etnia",
                table: "Estudiantes");
        }
    }
}
