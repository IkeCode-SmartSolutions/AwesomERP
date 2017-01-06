using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Awe.Menu.Service;

namespace PersonComponent.Controllers
{
    [Route("Pessoa/Dashboard", Name = "PersonDashboard")]
    public class DashboardController : Controller
    {
        private readonly IAweMenuService _menuService;
        public DashboardController(IAweMenuService menuService)
        {
            _menuService = menuService;
        }

        //[Menu("Pessoa", "Dashboard")]
        public IActionResult Index()
        {

            return View();
        }
    }
}
