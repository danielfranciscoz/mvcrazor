using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Interfaces
{
    public interface IUsuarioService
    {
        int GuardarUsuario(UsuarioDTO u);
        bool EditarUsuario(int id, UsuarioDTO u);
        bool EliminarUsuario(int id);
        List<UsuarioRead> ObtenerUsuarios();
        Usuario ObtenerUsuarioPorId(int id);
        Usuario ObtenerUsuarioPorNombre(string userName);
    }
}
