using System;
using System.Collections.Generic;
using System.Text;

namespace GestorUsuarios.Core.DTOs
{
    public class TareaDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NombreTarea { get; set; }
        public int Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }
    }
}
