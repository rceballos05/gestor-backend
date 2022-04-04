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
    public class UsuariosRepository : IUsuarioRepository
    {
        private readonly GestionContext context;
        public UsuariosRepository(GestionContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var usuarios =  await context.Usuarios.ToListAsync();
            return usuarios;
        }
        public async Task<Usuario> GetUsuario(int id)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            return usuario;
        }
        public async Task PostUsuario(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
        }
        public async Task<Usuario> ObtenerUsuarioByLogin(int id)
        {
            var login = await context.Usuarios.FirstOrDefaultAsync(u => u.IdLogin == id);
            return login;
        }
    }
}
