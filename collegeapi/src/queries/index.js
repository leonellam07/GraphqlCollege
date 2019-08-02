import gql from 'graphql-tag';

export const ESTUDIANTES_QUERY = gql `{
  estudiantes
  {
    id
    nombrePrimero
    nombreSegundo
    apellidoMaterno
    apellidoPaterno
    detalleNotas{
      anio
      bimestre
      nota
      fecha
      materia{
        id
        nombre
      }
    }
    
  }
}`;
  