using CollegeApi.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.DataBase
{
    public class CollegeApiContext : DbContext
    {
        public CollegeApiContext(DbContextOptions<CollegeApiContext> options) : base(options)
        {

        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<DetalleNota> DetalleNotas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .HasKey(entity => new { entity.Id });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(key => new { key.Id });

                entity.Property(prop => prop.FechaCreacion)
                    .HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<DetalleNota>(entity =>
            {
                entity.HasKey(key => new { key.Anio, key.Bimestre, key.MateriaId, key.EstudianteId });

                entity.HasOne<Estudiante>(table => table.Estudiante)
                    .WithMany(detail => detail.DetalleNotas)
                    .HasForeignKey(fkey => fkey.EstudianteId);

                entity.HasOne<Materia>(table => table.Materia)
                    .WithMany(detail => detail.DetalleNotas)
                    .HasForeignKey(fkey => fkey.MateriaId);

                entity.Property(prop => prop.Fecha)
                    .HasDefaultValueSql("getdate()");
            });


        }



    }
}
