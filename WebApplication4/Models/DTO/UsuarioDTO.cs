using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication4.Models
{
    public partial class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo usuario es requerido para poder continuar")]
        [MaxLength(50)]
        [MinLength(20)]
        public string Usuario1 { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}
