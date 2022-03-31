using System;
using System.Collections.Generic;

#nullable disable

namespace GestorUsuarios.Core.Entities
{
    public partial class Login
    {
        public Login()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
