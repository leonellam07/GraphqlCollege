using CollegeApi.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.DataAccess.Repositories.Contracts
{
    public interface IMateria_Repository
    {   //Queries
        IEnumerable<Materia> GetAll();
        Materia GetById(string id);

        //Mutations
        Materia Add(Materia materia);
        Materia Update(Materia materia);
        Materia Delete(string id);
    }
}
