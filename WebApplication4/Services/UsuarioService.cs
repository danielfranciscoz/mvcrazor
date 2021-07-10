using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Database;
using WebApplication4.Interfaces;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class UsuarioService : IUsuarioService
    {
        mydatabaseDB _db;

        public UsuarioService(mydatabaseDB db)
        {
            _db = db;
        }
        public bool EditarUsuario(int id, UsuarioDTO user)
        {
            Usuario u = ObtenerUsuarioPorId(id);// ObtenerUsuario(id);

            u.Nombre = user.Nombre;
            u.Correo = user.Correo;
            u.Usuario1 = user.Usuario1;
            u.IdRol = user.IdRol;

            _db.Update(u);
            _db.SaveChanges();

            return true;
        }

        public bool EliminarUsuario(int id)
        {
            Usuario u = ObtenerUsuarioPorId(id);
            u.Activo = false;

            _db.Update(u);

            _db.SaveChanges();

            return true;
        }

        public int GuardarUsuario(UsuarioDTO user)
        {
            Usuario u = new Usuario()
            {
                Correo = user.Correo,
                Nombre = user.Nombre,
                Usuario1 = user.Usuario1,
                IdRol = user.IdRol,
                Activo = true
            };

            _db.Usuarios.Add(u);
            _db.SaveChanges();

            return u.Id;
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return _db.Usuarios.Find(id);
        }

        public Usuario ObtenerUsuarioPorNombre(string userName)
        {
            return _db.Usuarios.FirstOrDefault(f => f.Usuario1 == userName);
        }

        public List<UsuarioRead> ObtenerUsuarios()
        {
            return _db.Usuarios
        .Where(usuario => usuario.Activo == true)
        .Select(s => new UsuarioRead()
        {
            Id = s.Id,
            Correo = s.Correo,
            IdRol = s.IdRol.Value,
            Usuario1 = s.Usuario1,
            Nombre = s.Nombre,
          //  NombreRol = s.IdRolNavigation.NombreRol
        })
        .ToList();
        }
    }
}
