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
    public class LoginRepository : ILoginRepository
    {
        private readonly GestionContext context;
        public LoginRepository(GestionContext _context)
        {
            context = _context;
        }
        
        public async Task<Login> GetLogin(int id)
        {
            var login = await context.Logins.FirstOrDefaultAsync(l => l.Id == id);
            return login;
        }
        public async Task<Login> VerificarLogin(string usuario, string contraseña)
        {
            var login = await context.Logins.FirstOrDefaultAsync(l => l.Usuario == usuario && l.Contraseña == contraseña);
            return login;
        }
        public async Task InsertLogin(Login _login)
        {
            context.Add(_login);
            await context.SaveChangesAsync();
        }
        public async Task<bool> UpdateLogin(Login _login)
        {
            var login = await GetLogin(_login.Id);
            login.Usuario = _login.Usuario;
            login.Contraseña = _login.Contraseña;
            var rows = await context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteLogin(int id)
        {
            var login = await GetLogin(id);
            context.Logins.Remove(login);
            var rows = await context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
