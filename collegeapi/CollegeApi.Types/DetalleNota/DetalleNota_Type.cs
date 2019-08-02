using CollegeApi.DataAccess.Repositories.Contracts;
using CollegeApi.Types.Estudiante;
using CollegeApi.Types.Materia;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.Types.DetalleNota
{
    public class DetalleNota_Type : ObjectGraphType<DataBase.Models.DetalleNota>
    {
        public DetalleNota_Type(IMateria_Repository materia_Repository, IEstudiante_Repository estudiante_Repository)
        {
            Field(x => x.Anio);
            Field(x => x.Bimestre);
            Field(x => x.Fecha);
            Field(x => x.Nota);
            Field(x => x.EstudianteId);
            Field(x => x.MateriaId);
            Field<Estudiante_Type>(
                "estudiante",
                resolve: ( context => 
                    {
                        return estudiante_Repository.GetById(context.Source.EstudianteId);
                    }
                )
            );
            Field<Materia_Type>(
                "materia",
                resolve: (context =>
                    {
                        return materia_Repository.GetById(context.Source.MateriaId);
                    }
                )
            );
        }
    }
}
