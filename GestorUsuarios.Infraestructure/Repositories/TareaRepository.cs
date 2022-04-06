using GestorUsuarios.Core.Entities;
using GestorUsuarios.Core.Interfaces;
using GestorUsuarios.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorUsuarios.Infraestructure.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly GestionContext context;
        public TareaRepository(GestionContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Tarea>> GetTareas()
        {
            var tareas = await context.Tareas.ToListAsync();
            return tareas;
        }
        public async Task<Tarea> GetTareaById(int id)
        {
            var tarea = await context.Tareas.Where(t => t.Id == id).FirstOrDefaultAsync();
            return tarea;
        }
        public async Task<IEnumerable<Tarea>> GetTareasByIdUsuario(int idUsuario)
        {
            var tareas = await context.Tareas.Where(t => t.IdUsuario == idUsuario).ToListAsync();
            return tareas;
        }
        public async Task<bool> InsertTarea(Tarea _tarea)
        {
            context.Add(_tarea);
            var response = await context.SaveChangesAsync();
            return response > 0;
        }
        public async Task<bool> UpdateTarea(Tarea _tarea)
        {
            var tarea = context.Tareas.FirstOrDefault(t => t.Id == _tarea.Id);
            tarea.NombreTarea = _tarea.NombreTarea;
            tarea.Estado = _tarea.Estado;
            var response = await context.SaveChangesAsync();
            return response > 0;
        }
        public async Task<bool> TerminarTarea(Tarea _tarea)
        {
            var tarea = context.Tareas.FirstOrDefault(t => t.Id == _tarea.Id);
            tarea.Estado = _tarea.Estado;
            tarea.FechaTermino = DateTime.Now;
            var response = await context.SaveChangesAsync();
            return response > 0;
        }
        public async Task<bool> DeleteTarea(int id)
        {
            var tarea = context.Tareas.FirstOrDefault(t => t.Id == id);
            context.Remove(tarea);
            var response = await context.SaveChangesAsync();
            return response > 0;
        }
    }
}
