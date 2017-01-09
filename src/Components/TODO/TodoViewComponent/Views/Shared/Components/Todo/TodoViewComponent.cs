using Microsoft.AspNetCore.Mvc;

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
