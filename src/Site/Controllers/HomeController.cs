using Microsoft.AspNetCore.Mvc;
using System;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        [Menu("", -1, null, "Home", icon: "wb-dashboard")]
        public IActionResult Index()
        {
            return View();
        }

        [Menu("Ajuda", 9999, null, "Sobre")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Menu("Ajuda", 9999, null, "Contato")]
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
