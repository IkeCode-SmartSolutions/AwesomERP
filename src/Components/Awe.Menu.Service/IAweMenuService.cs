using System.Collections.Generic;

namespace Awe.Menu.Service
{
    public interface IAweMenuService
    {
        Dictionary<string, List<AweMenu>> RegisteredMenus { get; }

        void RegisterMenu(string categoryName, List<AweMenu> menus);
    }
}
