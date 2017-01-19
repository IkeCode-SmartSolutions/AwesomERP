using System;
using System.Collections.Generic;
using System.Linq;

namespace Awe.Menu.Service
{
    public class AweMenuService : IAweMenuService
    {
        public Dictionary<string, List<AweMenu>> RegisteredMenus { get; private set; } = new Dictionary<string, List<AweMenu>>();

        public void RegisterMenu(string categoryName, AweMenu menu)
        {
            categoryName = string.IsNullOrWhiteSpace(categoryName) ? "Outros" : categoryName;

            if (RegisteredMenus.ContainsKey(categoryName))
            {
                RegisteredMenus[categoryName].Add(menu);
            }
            else
            {
                var newMenu = new List<AweMenu>() { menu };
                RegisteredMenus[categoryName] = newMenu;
            }

            //Adiciona os parents como item de menu, é apenas um "holder" pros filhos e evita de ter que criar [MenuAttribute] só pra isso.
            if(!string.IsNullOrWhiteSpace(menu.Parent) && !RegisteredMenus[categoryName].Any(i => i.Title == menu.Parent))
            {
                RegisteredMenus[categoryName].Add(new AweMenu() { Title = menu.Parent });
            }
        }

        public Dictionary<string, List<AweMenu>>  BuildMenu()
        {
            var result = new Dictionary<string, List<AweMenu>>();

            foreach (var registeredMenu in RegisteredMenus)
            {
                var tree = RecursiveMenu(null, registeredMenu.Value);

                result.Add(registeredMenu.Key, tree);
            }

            return result;
        }

        private List<AweMenu> RecursiveMenu(string parent, List<AweMenu> source)
        {
            var filtered = source.Where(i => i.Parent == parent).ToList();
            
            return (from menu in filtered
                   select new AweMenu(menu)
                   {
                      Children = RecursiveMenu(menu.Title, source)
                   }).ToList();
        }
    }
}
