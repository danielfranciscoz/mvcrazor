using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication4.Controllers
{
    public class UsuariosController : Controller
    {
        mydatabaseDB _db;
        List<Usuario> usuarios;
        SelectList s;

        public UsuariosController(mydatabaseDB db)
        {
            _db = db;
            var roles = _db.Roles.Where(w => w.Eliminado == false);
            s = new SelectList(roles, "Id", "Nombre");
        }

        // GET: UsuariosController
        public ActionResult Index()
        {
            usuarios = _db.Usuarios.ToList();
            int cantidad = usuarios.Count();

            ViewBag.cantidad = cantidad;
            ViewData["cantidadVD"] = cantidad;

            return View(usuarios);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Detalle(int id)
        {
            Usuario u = ObtenerUsuario(id); //ObtenerUsuario(id);

            if (u == null)
            {
                return NotFound();
            }
            return View(u);
        }

        // GET: UsuariosController/Create
        public ActionResult Crear()
        {
            ViewBag.Roles = s;

            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(UsuarioDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario u = new Usuario()
                    {
                        Nombre = user.Nombre,
                        Correo = user.Correo,
                        Usuario1 = user.Usuario1,
                        IdRol = user.IdRol
                    };

                    _db.Usuarios.Add(u);

                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Roles = s;
                    return View();
                }


                // usuarios.Add(user);
            }
            catch
            {
                TempData["Error"] = "Ocurrio un error al tratar de guardar";
                return RedirectToAction(nameof(Crear));
            }
        }

        private int calcularId()
        {
            return usuarios.Max(m => m.Id) + 1;
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Editar(int id)
        {
            ViewBag.Roles = s;
            Usuario u = ObtenerUsuario(id);

            return View(u);
        }

        private Usuario ObtenerUsuario(int id)
        {
            return _db.Usuarios.Find(id);
            // return usuarios.FirstOrDefault(f => f.Id == id);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, UsuarioDTO user)
        {
            try
            {
                Usuario u = ObtenerUsuario(id);// ObtenerUsuario(id);

                u.Nombre = user.Nombre;
                u.Correo = user.Correo;
                u.Usuario1 = user.Usuario1;

                _db.Update(u);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Usuario u = ObtenerUsuario(id);// ObtenerUsuario(id);

                _db.Remove(u);
                _db.SaveChanges();

                //      usuarios.Remove(u);

                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }

        }

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            ViewData["ErrorMessage"] = $"Error occurred. The ErrorCode is: {code}";
            return View("~/Views/Shared/HandleError.cshtml");
        }


    }
}
