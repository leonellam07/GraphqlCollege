using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CollegeApi.DataBase.Models
{
    public class DetalleNota
    {

        public int Anio { get; set; }
        public int Bimestre { get; set; }
        public DateTime Fecha { get; set; }

        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }

        public string MateriaId { get; set; }
        public Materia Materia { get; set; }

        public decimal Nota { get; set; }
    }
}
