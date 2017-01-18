using System;
using System.Collections.Generic;
using System.Linq;

namespace Awe.Menu.Service
{
    public class AweMenuService : IAweMenuService
    {
        public Dictionary<int, AweMenu> RegisteredMenus { get; private set; } 
            = new Dictionary<int, AweMenu>();

        public void RegisterMenu(int order, AweMenu menu)
        {
            RegisteredMenus[order] = menu;
        }
    }
}
