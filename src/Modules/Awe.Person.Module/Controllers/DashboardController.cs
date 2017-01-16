using Microsoft.AspNetCore.Mvc;
//using Awe.Menu.Service;

namespace Awe.Person.Module.Controllers
{
    [Route("Pessoa/Dashboard", Name = "Awe.Person.Module.Dashboard")]
    public class DashboardController : Controller
    {
        //private readonly IAweMenuService _menuService;
        public DashboardController(/*IAweMenuService menuService*/)
        {
            //_menuService = menuService;
        }

        //[Menu("Pessoa", "Dashboard")]
        public IActionResult Index()
        {

            return View();
        }
    }
}
