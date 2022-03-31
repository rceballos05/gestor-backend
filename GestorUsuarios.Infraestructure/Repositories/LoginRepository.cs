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

    }
}
