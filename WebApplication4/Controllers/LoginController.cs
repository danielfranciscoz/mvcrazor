using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class LoginController : Controller
    {
        const string SessionUser = "_User";
        public IConfiguration Configuration { get; }




        public ActionResult Login()

        {

            return View(new Usuario());

        }

        [HttpPost]
        public ActionResult Login(Usuario u)
        {

            if (u.Usuario1 == "Daniel")
            {
                HttpContext.Session.SetString(SessionUser, u.Usuario1);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "Datos ingresado no válido.");
            }

            return View(u);
        }

        [HttpPost]
        public ActionResult LogOut()

        {

            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Login");

        }


    }
}
