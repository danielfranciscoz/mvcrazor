using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Interfaces;

namespace WebApplication4.Controllers
{
    public class UsuariosController : Controller
    {
        List<UsuarioRead> usuarios;
        IUsuarioService _usuarioService;
        IRolesService _rolesService;
        SelectList lista;
        public UsuariosController(
            IUsuarioService usuarioService,
            IRolesService rolesService
            )
        {
            _usuarioService = usuarioService;
            _rolesService = rolesService;

            CargarRoles();
        }

        private void CargarRoles()
        {
            var roles = _rolesService.ObtenerRoles();
            lista = new SelectList(roles, "Id", "NombreRol");
        }
        // GET: UsuariosController
        public ActionResult Index()
        {
            //if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            //{
            //    return RedirectToAction("Index", "Login");
            //}

            usuarios = _usuarioService.ObtenerUsuarios();

            int cantidad = usuarios.Count();

            ViewBag.cantidad = cantidad;
            ViewData["cantidadVD"] = cantidad;

            return View(usuarios);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Detalle(int id)
        {
            Usuario u = _usuarioService.ObtenerUsuarioPorId(id); //ObtenerUsuario(id);

            if (u == null)
            {
                return NotFound();
            }
            return View(u);
        }

        // GET: UsuariosController/Create
        public ActionResult Crear()
        {

            ViewBag.Roles = lista;

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
                    _usuarioService.GuardarUsuario(user);
                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    ViewBag.Roles = lista;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Editar(int id)
        {
            Usuario u = _usuarioService.ObtenerUsuarioPorId(id);

            if (u == null)
            {
                return NotFound();
            }

            UsuarioDTO user = new UsuarioDTO()
            {
                Nombre = u.Nombre,
                Correo = u.Correo,
                Usuario1 = u.Usuario1,
                IdRol = u.IdRol
            };

            ViewBag.Roles = lista;

            return View(user);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, UsuarioDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioService.EditarUsuario(id, user);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ViewBag.Roles = lista;
                    return View();
                }


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
                _usuarioService.EliminarUsuario(id);

                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }

        }


    }
}
