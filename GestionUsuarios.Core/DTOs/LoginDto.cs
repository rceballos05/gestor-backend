using System;
using System.Collections.Generic;
using System.Text;

namespace GestorUsuarios.Core.DTOs
{
    public class LoginDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }
}
