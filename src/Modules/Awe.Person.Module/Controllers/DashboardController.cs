using Microsoft.AspNetCore.Mvc;
using System;

namespace Awe.Person.Module.Controllers
{
    [Route("Pessoa")]
    public class DashboardController : Controller
    {
        public DashboardController()
        {
        }

        [Menu(null, "Dashboard", icon: "fa fa-users")]
        [Route("Dashboard", Name = "Awe.Person.Module.Dashboard")]
        public IActionResult Index()
        {
            return View("/Views/Person/Dashboard/Index.cshtml");
        }
    }
}
