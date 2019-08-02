﻿// <auto-generated />
using System;
using CollegeApi.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CollegeApi.DataBase.Migrations
{
    [DbContext(typeof(CollegeApiContext))]
    [Migration("20190515205640_update_fecha_nacimiento")]
    partial class update_fecha_nacimiento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CollegeApi.DataBase.Models.DetalleNota", b =>
                {
                    b.Property<int>("Anio");

                    b.Property<int>("Bimestre");

                    b.Property<string>("MateriaId");

                    b.Property<int>("EstudianteId");

                    b.Property<DateTime>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<decimal>("Nota");

                    b.HasKey("Anio", "Bimestre", "MateriaId", "EstudianteId");

                    b.HasIndex("EstudianteId");

                    b.HasIndex("MateriaId");

                    b.ToTable("DetalleNotas");
                });

            modelBuilder.Entity("CollegeApi.DataBase.Models.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoMaterno");

                    b.Property<string>("ApellidoPaterno");

                    b.Property<string>("Correo");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("NombrePrimero");

                    b.Property<string>("NombreSegundo");

                    b.Property<string>("Password");

                    b.Property<string>("Usuario");

                    b.HasKey("Id");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("CollegeApi.DataBase.Models.Materia", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("CollegeApi.DataBase.Models.DetalleNota", b =>
                {
                    b.HasOne("CollegeApi.DataBase.Models.Estudiante", "Estudiante")
                        .WithMany("DetalleNotas")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CollegeApi.DataBase.Models.Materia", "Materia")
                        .WithMany("DetalleNotas")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
