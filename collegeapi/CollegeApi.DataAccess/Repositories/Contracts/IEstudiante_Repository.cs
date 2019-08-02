using CollegeApi.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.DataAccess.Repositories.Contracts
{
    public interface IEstudiante_Repository
    {
        //Queries
        IEnumerable<Estudiante> GetAll();
        IEnumerable<Estudiante> GetAll(int cantidad_registros);
        Estudiante GetById(int id);
 

        //Mutations
        Estudiante Add(Estudiante estudiante);
        Estudiante Update(Estudiante estudiante);
        Estudiante Delete(int id);
    }
}
