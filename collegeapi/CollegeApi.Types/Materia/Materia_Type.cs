using CollegeApi.DataAccess.Repositories;
using CollegeApi.DataAccess.Repositories.Contracts;
using CollegeApi.Types.DetalleNota;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.Types.Materia
{
    public class Materia_Type : ObjectGraphType<DataBase.Models.Materia>
    {
        public Materia_Type(IDetalleNota_Repository detalleNota_Repository)
        {
            Field(x => x.Id);
            Field(x => x.Nombre);
            Field(x => x.Descripcion);
            Field(x => x.FechaCreacion);
            Field<ListGraphType<DetalleNota_Type>>(
             "detalleNotas",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "anio", Description = "Filtro para las notas clasificadas por año (opcional)" },
                    new QueryArgument<IntGraphType> { Name = "bimestre", Description = "Filtro para las notas clasificadas por bimestre (opcional)" }
                ),
                resolve: context =>
                {
                    //Variables del listado
                    var _anio = context.GetArgument<int?>("anio");
                    var _bimestre = context.GetArgument<int?>("bimestre");


                    //Posibles retornos según variables de los detalles de las notas
                    if (_anio != null && _bimestre != null)
                        return detalleNota_Repository.GetAllFor_Materia(context.Source.Id, _anio ?? 0, _bimestre ?? 0);

                    if (_anio != null)
                        return detalleNota_Repository.GetAllFor_Materia(context.Source.Id, _anio ?? 0);

                    return detalleNota_Repository.GetAllFor_Materia(context.Source.Id);
                }
            );
        }
    }
}
