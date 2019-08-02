using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.Types.DetalleNota
{
    public class DetalleNota_InputType : InputObjectGraphType
    {
        public DetalleNota_InputType()
        {
            Name = "DetalleNotaInput";
            Field<IntGraphType>("Anio");
            Field<IntGraphType>("Bimestre");
            Field<DateGraphType>("Fecha");
            Field<DecimalGraphType>("Nota");
            Field<IdGraphType>("EstudianteId");
            Field<IdGraphType>("MateriaId");
        }
    }
}
