using CollegeApi.DataAccess.Repositories.Contracts;
using CollegeApi.Types.DetalleNota;
using CollegeApi.Types.Estudiante;
using CollegeApi.Types.Materia;
using GraphQL.Types;

namespace CollegeApi.Queries
{
    public class CollegeApi_Queries : ObjectGraphType
    {
        public CollegeApi_Queries(
                  IEstudiante_Repository estudiante_Repository
                , IMateria_Repository materia_Repository
                , IDetalleNota_Repository detalleNota_Repository
        )
        {
            Name = "CollegeApiQueries";

            //Estudiante
            Field<ListGraphType<Estudiante_Type>>(
                "estudiantes",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "cantidadRegistros", Description = "Cantidad de Registros a devolver" }),
                resolve: (context =>
                {
                    var _cantidad_registros = context.GetArgument<int>("cantidadRegistros");
                    if (_cantidad_registros > 0)
                    {
                        estudiante_Repository.GetAll(_cantidad_registros);
                    }
                    return estudiante_Repository.GetAll();
                }

                )
            );

            Field<Estudiante_Type>(
                "estudiante",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id", Description = "Id del estudiante" }),
                resolve: context => estudiante_Repository.GetById(context.GetArgument<int>("id"))
            );

            //Materia 
            Field<ListGraphType<Materia_Type>>(
                "materias",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id", Description = "Id de la materia" }),
                resolve: context => materia_Repository.GetAll()
             );

            Field<Materia_Type>(
                "materia",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id", Description = "Id de la materia" }),
                resolve: context => materia_Repository.GetById(context.GetArgument<string>("id"))
           );


        }



    }
}
