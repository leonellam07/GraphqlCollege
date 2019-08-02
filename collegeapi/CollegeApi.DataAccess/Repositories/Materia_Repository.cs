using CollegeApi.DataAccess.Repositories.Contracts;
using CollegeApi.DataBase;
using CollegeApi.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeApi.DataAccess.Repositories
{
    public class Materia_Repository : IMateria_Repository
    {

        private readonly CollegeApiContext _db;

        public Materia_Repository(CollegeApiContext db)
        {
            _db = db;
        }

        public Materia Add(Materia materia)
        {
            _db.Materias.Add(materia);
            _db.SaveChanges();
            return materia;
        }

        public Materia Delete(string codigo)
        {
            Materia _materia = _db.Materias
                .SingleOrDefault(x => x.Id == codigo);

            _db.Materias.Remove(_materia);
            return _materia;
        }

        public IEnumerable<Materia> GetAll()
        {
            return _db.Materias;
        }

        public Materia GetById(string id)
        {
            return _db.Materias
                .SingleOrDefault(x => x.Id == id);
        }

        public Materia Update(Materia materia)
        {
            throw new NotImplementedException();
        }
    }
}
