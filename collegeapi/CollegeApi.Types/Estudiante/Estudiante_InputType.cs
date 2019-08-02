using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.Types.Estudiante
{
    public class Estudiante_InputType: InputObjectGraphType
    {
        public Estudiante_InputType()
        {
            Name = "EstudianteInput";
            Field<StringGraphType>("NombrePrimero");
            Field<StringGraphType>("NombreSegundo");
            Field<StringGraphType>("ApellidoMaterno");
            Field<StringGraphType>("ApellidoPaterno");
            Field<StringGraphType>("Correo");
            Field<StringGraphType>("Usuario");
            Field<StringGraphType>("Password");
            Field<DateGraphType>("FechaNacimiento");
        }
    }
}
