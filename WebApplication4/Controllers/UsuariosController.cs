using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class UsuariosController : Controller
    {
        static List<UsuariosViewModel> usuarios = new List<UsuariosViewModel>() {
         new UsuariosViewModel()
            {
                Correo = "daniel.zamora@psg.uni.edu.ni",
                Nombre = "Daniel",
                Rol = "Administrador",
                Usuario = "dfzamora"
            },

       new UsuariosViewModel()
        {
            Correo = "jdoe@psg.uni.edu.ni",
                Nombre = "John",
                Rol = "Administrador",
                Usuario = "john"
            },

        new UsuariosViewModel()
        {
            Correo = "test@psg.uni.edu.ni",
                Nombre = "Test",
                Rol = "Analista",
                Usuario = "test"
            }
        };

        public UsuariosController()
        {

        }
        // GET: UsuariosController
        public ActionResult Index()
        {
           
            return View(usuarios);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuariosViewModel user)
        {
            try
            {
                usuarios.Add(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
