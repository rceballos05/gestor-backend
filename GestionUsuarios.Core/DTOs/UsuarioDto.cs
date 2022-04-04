using System;
using System.Collections.Generic;
using System.Text;

namespace GestorUsuarios.Core.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Rut { get; set; }
        public string Fono { get; set; }
        public string Cargo { get; set; }
        public string Correo { get; set; }
        public int Rol { get; set; }
        public int IdLogin { get; set; }
    }
}
