using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Interfaces;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class LoginController : Controller
    {
        const string SessionUser = "_User";
        public IConfiguration Configuration { get; }

        private readonly IUsuarioService _usuarioService;


        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UsuarioLogin user)
        {

            Usuario usuario = _usuarioService.ObtenerUsuarioPorNombre(user.Usuario1);

            if (usuario != null)
            {

                if (user.password == "1234")
                { 
                    HttpContext.Session.SetString(SessionUser, usuario.Usuario1);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "La contraseña es incorrecta");
                }
            }
            else
            {
                ModelState.AddModelError("", "El usuario no existe");
            }

            return View();
        }

        [HttpPost]
        public ActionResult LogOut()

        {

            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));

        }


    }
}
