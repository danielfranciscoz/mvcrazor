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
        testdbContext _db;
        public UsuarioService(testdbContext db)
        {
            _db = db;
        }
        public void EditarUsuario(int idUsuario, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsuarios()
        {
            return _db.Usuarios.ToList();
        }

        public void GuardarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
