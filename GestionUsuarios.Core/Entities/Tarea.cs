using System;
using System.Collections.Generic;

#nullable disable

namespace GestorUsuarios.Core.Entities
{
    public partial class Tarea
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NombreTarea { get; set; }
        public int Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
