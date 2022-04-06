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
        public async Task<bool> UpdateUsuario(Usuario _usuario)
        {
            var usuario = await GetUsuario(_usuario.Id);
            usuario.Nombre = _usuario.Nombre;
            usuario.Apellido = _usuario.Apellido;
            usuario.FechaNacimiento = _usuario.FechaNacimiento;
            usuario.Fono = _usuario.Fono;
            usuario.Correo = _usuario.Correo;
            usuario.Cargo = _usuario.Cargo;
            var response = await context.SaveChangesAsync();
            return response > 0;
        }
        public async Task<bool> DeleteUsuario(int id)
        {
            var usuario = await GetUsuario(id);
            context.Remove(usuario);
            var response = await context.SaveChangesAsync();
            return response > 0;
        }
    }
}
