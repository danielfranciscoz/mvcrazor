using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_User")))
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult ErrorControlado(int code)
        {
            if (HttpStatusCode.NotFound.ToString().Equals(code))
            {
                ViewData["ErrorMessage"] = $"Lo sentimos, el registro que busca no existe";
                return View("~/Views/Shared/404.cshtml");

            }

            return RedirectToAction(nameof(Index));
        }
    }
}
