using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication4.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Usuario1 { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int? IdRol { get; set; }
        public bool Activo { get; set; }

        public virtual Role IdRolNavigation { get; set; }
    }
}
