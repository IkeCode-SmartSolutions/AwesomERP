using Microsoft.AspNetCore.Mvc;

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
