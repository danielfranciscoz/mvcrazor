using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication4.Util;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication4.Models
{
    public partial class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo usuario es requerido para poder continuar")]
        [MaxLength(50)]
        [MinLength(20)]
        public string Usuario1 { get; set; }
        [Required]
        public string Nombre { get; set; }
        [EmailAddress]
        [Required]
        public string Correo { get; set; }
        [RequiredInt(ErrorMessage ="El rol prohibido no puede ser seleccionado")]
        public int IdRol { get; set; }
    }
}
