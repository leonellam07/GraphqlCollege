using CollegeApi.DataAccess.Repositories.Contracts;
using CollegeApi.Types.DetalleNota;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.Types.Estudiante
{
    public class Estudiante_Type : ObjectGraphType<DataBase.Models.Estudiante>
    {
        public Estudiante_Type(IDetalleNota_Repository detalleNota_Repository)
        {
            Field(x => x.Id);
            Field(x => x.NombrePrimero);
            Field(x => x.NombreSegundo);
            Field(x => x.ApellidoMaterno);
            Field(x => x.ApellidoPaterno);
            Field(x => x.Correo);
            Field(x => x.Usuario);
            Field(x => x.Password);
            Field(x => x.FechaNacimiento);
            Field<DecimalGraphType>(
                "promedio",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "anio", Description = "Filtro para las notas clasificadas por año (opcional)" },
                    new QueryArgument<IntGraphType> { Name = "bimestre", Description = "Filtro para las notas clasificadas por bimestre (opcional)" }
                ),
                resolve: context =>
                {
                    var _anio = context.GetArgument<int>("anio");
                    var _bimestre = context.GetArgument<int>("bimestre");

                    if (_anio > 0 && _bimestre > 0)
                    {
                        return detalleNota_Repository.GetAverage_DetalleNotas(context.Source.Id, _anio, _bimestre);
                    }

                    if (_anio > 0)
                    {
                        return detalleNota_Repository.GetAverage_DetalleNotas(context.Source.Id, _anio);
                    }

                    return detalleNota_Repository.GetAverage_DetalleNotas(context.Source.Id);
                }
            );
            Field<ListGraphType<DetalleNota_Type>>(
                "detalleNotas",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "anio", Description = "Filtro para las notas clasificadas por año (opcional)" },
                    new QueryArgument<IntGraphType> { Name = "bimestre", Description = "Filtro para las notas clasificadas por bimestre (opcional)" }
                ),
                resolve: context =>
                {
                    //Variables del listado
                    var _anio = context.GetArgument<int>("anio");
                    var _bimestre = context.GetArgument<int?>("bimestre");


                    //Posibles retornos según variables de los detalles de las notas
                    if (_anio > 0 && _bimestre > 0)
                        return detalleNota_Repository.GetAllFor_Estudiante(context.Source.Id, _anio, _bimestre ?? 0);

                    if (_anio > 0)
                        return detalleNota_Repository.GetAllFor_Estudiante(context.Source.Id, _anio);

                    return detalleNota_Repository.GetAllFor_Estudiante(context.Source.Id);
                }
            );

        }
    }
}
