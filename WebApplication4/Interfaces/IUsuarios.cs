using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Interfaces
{
    public interface IUsuarios
    {
        List<Usuario> GetUsuarios();
        void GuardarUsuario();
        void EditarUsuario(int idUsuario, Usuario usuario);
    }
}
