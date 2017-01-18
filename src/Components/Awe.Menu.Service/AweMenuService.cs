using System;
using System.Collections.Generic;
using System.Linq;

namespace Awe.Menu.Service
{
    public class AweMenuService : IAweMenuService
    {
        public Dictionary<string, List<AweMenu>> RegisteredMenus { get { return _registeredMenus; } }

        Dictionary<string, List<AweMenu>> _registeredMenus { get; set; } = new Dictionary<string, List<AweMenu>>();

        public void RegisterMenu(string categoryName, List<AweMenu> menus)
        {
            categoryName = string.IsNullOrWhiteSpace(categoryName) ? "Geral" : categoryName;
            if (_registeredMenus.ContainsKey(categoryName))
                _registeredMenus[categoryName].AddRange(menus);
            else
                _registeredMenus[categoryName] = menus;
        }
    }
}
