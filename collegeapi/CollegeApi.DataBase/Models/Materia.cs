using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CollegeApi.DataBase.Models
{
    public class Materia
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ICollection<DetalleNota> DetalleNotas { get; set; }
    }
}
