using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeApi.DataBase.Migrations
{
    public partial class DefaultTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Materias",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "DetalleNotas",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Materias",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "DetalleNotas",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");
        }
    }
}
