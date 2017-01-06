using Microsoft.AspNetCore.Mvc;
using Module.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aew.Menu.Component
{
    [ViewComponent(Name = "Aew.Menu.Component.Default")]
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int number)
        {
            return View(number + 1);
        }
    }
}
