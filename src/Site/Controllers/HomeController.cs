using Microsoft.AspNetCore.Mvc;
using Awe.Menu.Service;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IAweMenuService menuService)
        {
            menuService.RegisterMenu(new Awe.Menu.AweMenu() {
                Title = "teste",
                RouteUrl = "/teste.html",
                Id = 1
            });
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

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
