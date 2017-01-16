using Microsoft.AspNetCore.Mvc;

namespace Awe.Todo.Component
{
    [ViewComponent(Name = "ViewComponents.Todo")]
    public class TodoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int number)
        {
            return View(number + 1);
        }
    }
}
