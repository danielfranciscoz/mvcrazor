using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication4.Models
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string NombreRol { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
