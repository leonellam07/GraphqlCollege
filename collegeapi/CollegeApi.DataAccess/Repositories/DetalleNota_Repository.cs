using CollegeApi.DataAccess.Repositories.Contracts;
using CollegeApi.DataBase;
using CollegeApi.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeApi.DataAccess.Repositories
{
    public class DetalleNota_Repository : IDetalleNota_Repository
    {
        private readonly CollegeApiContext _db;
        public DetalleNota_Repository(CollegeApiContext db)
        {
            _db = db;
        }

        public DetalleNota Add(DetalleNota detalleNota)
        {
            _db.DetalleNotas.Add(detalleNota);
            _db.SaveChanges();
            return detalleNota;
        }

        public DetalleNota Delete(DetalleNota detalleNota)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DetalleNota> GetAllFor_Estudiante(int estudianteId)
        {
            return _db.DetalleNotas
                .Where(x => x.EstudianteId == estudianteId);
        }

        public IEnumerable<DetalleNota> GetAllFor_Estudiante(int estudianteId, int anio)
        {
            return _db.DetalleNotas
                .Where(x => x.EstudianteId == estudianteId && x.Anio == anio);
        }

        public IEnumerable<DetalleNota> GetAllFor_Estudiante(int estudianteId, int anio, int bimestre)
        {
            return _db.DetalleNotas
                .Where(x => x.EstudianteId == estudianteId && x.Anio == anio && x.Bimestre == bimestre);
        }

        public IEnumerable<DetalleNota> GetAllFor_Materia(string materiaId)
        {
            return _db.DetalleNotas
                 .Where(x => x.MateriaId.Equals(materiaId));
        }

        public IEnumerable<DetalleNota> GetAllFor_Materia(string materiaId, int anio)
        {
            return _db.DetalleNotas
                .Where(x => x.MateriaId.Equals(materiaId) && x.Anio == x.Anio);
        }

        public IEnumerable<DetalleNota> GetAllFor_Materia(string materiaId, int anio, int bimestre)
        {
            return _db.DetalleNotas
                .Where(x => x.MateriaId.Equals(materiaId) && x.Anio == anio && x.Bimestre == bimestre);
        }

        public decimal GetAverage_DetalleNotas(int idEstudiante)
        {
            if (_db.DetalleNotas.Where(w => w.EstudianteId == idEstudiante).Count() > 0)
            {
                return _db.DetalleNotas.Where(w => w.EstudianteId == idEstudiante).Average(x => x.Nota);
            }

            return 0;
        }

        public decimal GetAverage_DetalleNotas(int idEstudiante, int anio)
        {
            if (_db.DetalleNotas.Where(w => w.EstudianteId == idEstudiante && w.Anio == anio).Count() > 0)
            {
                return _db.DetalleNotas.Where(w => w.EstudianteId == idEstudiante && w.Anio == anio).Average(x => x.Nota);
            }

            return 0;
        }

        public decimal GetAverage_DetalleNotas(int idEstudiante, int anio, int bimestre)
        {
            if (_db.DetalleNotas.Where(w => w.EstudianteId == idEstudiante && w.Anio == anio && w.Bimestre == bimestre).Count() > 0)
            {
                return _db.DetalleNotas.Where(w => w.EstudianteId == idEstudiante && w.Anio == anio && w.Bimestre == bimestre).Average(x => x.Nota);
            }

            return 0;
        }

        public DetalleNota Update(DetalleNota detalleNota)
        {
            throw new NotImplementedException();
        }
    }
}
