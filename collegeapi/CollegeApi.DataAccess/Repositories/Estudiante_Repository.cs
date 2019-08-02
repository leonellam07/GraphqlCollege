using CollegeApi.DataAccess.Repositories.Contracts;
using CollegeApi.DataBase;
using CollegeApi.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeApi.DataAccess.Repositories
{
    public class Estudiante_Repository : IEstudiante_Repository
    {
        private readonly CollegeApiContext _db;

        public Estudiante_Repository(CollegeApiContext db)
        {
            _db = db;
        }

        public Estudiante Add(Estudiante estudiante)
        {
            _db.Estudiantes.Add(estudiante);
            _db.SaveChanges();
            return estudiante;
        }

        public Estudiante Delete(int id)
        {
            Estudiante estudiante = _db.Estudiantes.SingleOrDefault(x => x.Id == id);
            _db.Estudiantes.Remove(estudiante);
            _db.SaveChanges();
            return estudiante;
        }

        public IEnumerable<Estudiante> GetAll()
        {
            return _db.Estudiantes;
        }

        public IEnumerable<Estudiante> GetAll(int cantidad_registros)
        {
            return _db.Estudiantes
                .OrderBy(x => x.Id)
                .Take(cantidad_registros);
        }


        public Estudiante GetById(int id)
        {
            return _db.Estudiantes
                .SingleOrDefault(x => x.Id == id);
        }

        public Estudiante Update(Estudiante estudiante)
        {
            Estudiante _estudiante = _db.Estudiantes.SingleOrDefault(x => x.Id == estudiante.Id);
            _estudiante.NombrePrimero = estudiante.NombrePrimero;
            _estudiante.NombreSegundo = estudiante.NombreSegundo;
            _estudiante.Password = estudiante.Password;
            _estudiante.Usuario =  estudiante.Usuario;
            _estudiante.ApellidoMaterno = estudiante.ApellidoMaterno;
            _estudiante.ApellidoPaterno = estudiante.ApellidoPaterno;
            _estudiante.Correo = estudiante.Correo;
            _estudiante.FechaNacimiento = estudiante.FechaNacimiento;
            _estudiante.DetalleNotas = estudiante.DetalleNotas;
            _db.SaveChanges();

            return _estudiante;
        }
    }
}
