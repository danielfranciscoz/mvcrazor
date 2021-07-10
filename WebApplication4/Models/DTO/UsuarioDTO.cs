using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication4.Util;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication4.Models
{
    public abstract class UsuarioAbstract
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Usuario1 { get; set; }

    }

    public class UsuarioDTO : UsuarioAbstract
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [EmailAddress(ErrorMessage = "El dato ingresado no es un correo válido")]
        public string Correo { get; set; }

        [NotAllowedId]
        public int? IdRol { get; set; }
    }

    public class UsuarioRead : UsuarioDTO
    {
        public int Id { get; set; }
        public string NombreRol { get; set; }
    }

    public class UsuarioLogin : UsuarioAbstract
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string password { get; set; }
    }
}
