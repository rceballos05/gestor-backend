using GestorUsuarios.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorUsuarios.Core.Interfaces
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> GetTareas();
        Task<Tarea> GetTareaById(int id);
        Task<IEnumerable<Tarea>> GetTareasByIdUsuario(int idUsuario);
        Task<bool> InsertTarea(Tarea _tarea);
        Task<bool> UpdateTarea(Tarea _tarea);
        Task<bool> TerminarTarea(Tarea _tarea);
        Task<bool> DeleteTarea(int id);
    }
}
