using CollegeApi.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.DataAccess.Repositories.Contracts
{
    public interface IDetalleNota_Repository
    {
        //Queries
        IEnumerable<DetalleNota> GetAllFor_Estudiante(int estudianteId);
        IEnumerable<DetalleNota> GetAllFor_Estudiante(int estudianteId, int anio);
        IEnumerable<DetalleNota> GetAllFor_Estudiante(int estudianteId, int anio, int bimestre);
        IEnumerable<DetalleNota> GetAllFor_Materia(string materiaId);
        IEnumerable<DetalleNota> GetAllFor_Materia(string materiaId, int anio);
        IEnumerable<DetalleNota> GetAllFor_Materia(string materiaId, int anio, int bimestre);

        //Mutations
        DetalleNota Add(DetalleNota detalleNota);
        DetalleNota Update(DetalleNota detalleNota);
        DetalleNota Delete(DetalleNota detalleNota);

        //Operaciones
        decimal GetAverage_DetalleNotas(int idEstudiante);
        decimal GetAverage_DetalleNotas(int idEstudiante, int anio);
        decimal GetAverage_DetalleNotas(int idEstudiante, int anio, int bimestre);

    }
}
