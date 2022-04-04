﻿using GestorUsuarios.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorUsuarios.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task PostUsuario(Usuario usuario);
        Task<Usuario> ObtenerUsuarioByLogin(int id);
    }
}
