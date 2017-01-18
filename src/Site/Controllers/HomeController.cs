using Microsoft.AspNetCore.Mvc;
using System;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        [Menu(null, "Home")]
        public IActionResult Index()
        {
            return View();
        }

        [Menu("Ajuda", "Sobre")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Menu("Ajuda", "Contato")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
