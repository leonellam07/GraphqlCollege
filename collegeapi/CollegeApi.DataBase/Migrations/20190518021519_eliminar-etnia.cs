using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeApi.DataBase.Migrations
{
    public partial class eliminaretnia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EtniaXD",
                table: "Estudiantes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EtniaXD",
                table: "Estudiantes",
                nullable: true);
        }
    }
}
