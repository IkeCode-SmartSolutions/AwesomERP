using System.Collections.Generic;
using System.Linq;

namespace Awe.Menu.Service
{
    public class AweMenuService : IAweMenuService
    {
        public Dictionary<AweMenuCategory, List<AweMenuItem>> RegisteredMenus { get; private set; } = new Dictionary<AweMenuCategory, List<AweMenuItem>>();
        
        public void RegisterMenu(int categoryOrder, string categoryName, AweMenuItem menu)
        {
            categoryName = categoryName == null ? "Outros" : categoryName;

            var category = new AweMenuCategory(categoryOrder, categoryName);

            if (RegisteredMenus.ContainsKey(category))
            {
                RegisteredMenus[category].Add(menu);
            }
            else
            {
                var newMenu = new List<AweMenuItem>() { menu };
                RegisteredMenus[category] = newMenu;
            }

            //Adiciona os parents como item de menu, é apenas um "holder" pros filhos e evita de ter que criar [MenuAttribute] só pra isso.
            if (!string.IsNullOrWhiteSpace(menu.Parent) && !RegisteredMenus[category].Any(i => i.Title == menu.Parent))
            {
                RegisteredMenus[category].Add(new AweMenuItem() { Title = menu.Parent });
            }
        }

        public Dictionary<string, List<AweMenuItem>> BuildMenu()
        {
            var result = new Dictionary<string, List<AweMenuItem>>();

            var ordered = RegisteredMenus.OrderBy(i => i.Key.Order).ToDictionary(i => i.Key.Title, i => i.Value);

            foreach (var registeredMenu in ordered)
            {
                var tree = RecursiveMenu(null, registeredMenu.Value);

                result.Add(registeredMenu.Key, tree);
            }

            return result;
        }

        private List<AweMenuItem> RecursiveMenu(string parent, List<AweMenuItem> source)
        {
            var filtered = source.Where(i => i.Parent == parent).ToList();
            
            return (from menu in filtered
                   select new AweMenuItem(menu)
                   {
                      Children = RecursiveMenu(menu.Title, source)
                   }).ToList();
        }
    }
}
