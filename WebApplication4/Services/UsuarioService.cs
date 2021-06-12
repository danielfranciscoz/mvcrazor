using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Database;
using WebApplication4.Interfaces;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class UsuarioService : IUsuarios
    {
        mydatabaseDB _db;
        public UsuarioService(mydatabaseDB db)
        {
            _db = db;
        }
        public void EditarUsuario(int idUsuario, UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsuarios()
        {
            return _db.Usuario.ToList();
        }

        public void GuardarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
