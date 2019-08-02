using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.Types.Materia
{
    public class Materia_InputType : InputObjectGraphType
    {
         public Materia_InputType()
        {
            Name = "MateriaInput";
            Field<StringGraphType>("Id");
            Field<StringGraphType>("Nombre");
            Field<StringGraphType>("Descripcion");
            Field<DateGraphType>("FechaCreacion");
        }
    }
}
