using GestorUsuarios.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorUsuarios.Core.Interfaces
{
    public interface ILoginRepository
    {
        Task<Login> GetLogin(int id);
        Task<Login> VerificarLogin(string usuario, string contraseña);
        Task InsertLogin(Login _login);
        Task<bool> UpdateLogin(Login _login);
        Task<bool> DeleteLogin(int id);
    }
}
