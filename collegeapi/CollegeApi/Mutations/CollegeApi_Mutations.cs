using CollegeApi.DataAccess.Repositories.Contracts;
using CollegeApi.DataBase.Models;
using CollegeApi.Types.DetalleNota;
using CollegeApi.Types.Estudiante;
using CollegeApi.Types.Materia;
using GraphQL.Types;

namespace CollegeApi.Mutations
{
    public class CollegeApi_Mutations : ObjectGraphType
    {
        public CollegeApi_Mutations
        (
            IEstudiante_Repository estudiante_Repository,
            IMateria_Repository materia_Repository,
            IDetalleNota_Repository detalleNota_Repository
        )
        {
            Name = "MutationsCollegeApi";

            //Estudiante

            Field<Estudiante_Type>(
                "addEstudiante",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<Estudiante_InputType>> { Name = "estudiante" }
                ),
                resolve: context =>
                {
                    var _estudiante = context.GetArgument<Estudiante>("estudiante");
                    return estudiante_Repository.Add(_estudiante);
                }
            ); 

            //Materia
            Field<Materia_Type>(
                "addMateria",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<Materia_InputType>> { Name = "materia" }
                ),
                resolve: context =>
                {
                    var _materia = context.GetArgument<Materia>("materia");
                    return materia_Repository.Add(_materia);
                }
            );

            //DetalleNota
            Field<DetalleNota_Type>(
               "addDetalleNota",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<DetalleNota_InputType>> { Name = "detalleNota" }
               ),
               resolve: context =>
               {
                   var _detalleNota = context.GetArgument<DetalleNota>("detalleNota");
                   return detalleNota_Repository.Add(_detalleNota);
               }
           );

        }
    }
}
