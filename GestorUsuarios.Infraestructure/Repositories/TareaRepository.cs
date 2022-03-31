using GestorUsuarios.Core.Entities;
using GestorUsuarios.Core.Interfaces;
using GestorUsuarios.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
