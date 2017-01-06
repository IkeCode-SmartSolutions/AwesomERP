using Microsoft.AspNetCore.Mvc;
using Module.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoViewComponent
{
    [ViewComponent(Name = "TodoViewComponent.Todo")]
    public class TodoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int number)
        {
            return View(number + 1);
        }
    }
}
