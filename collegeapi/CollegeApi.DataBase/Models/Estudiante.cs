using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeApi.DataBase.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string NombrePrimero { get; set; }
        public string NombreSegundo { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidoPaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public ICollection<DetalleNota> DetalleNotas { get; set; }
    }
}
