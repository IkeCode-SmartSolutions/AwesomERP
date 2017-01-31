using System.Collections.Generic;

namespace Awe.Menu.Service
{
    public interface IAweMenuService
    {
        Dictionary<AweMenuCategory, List<AweMenuItem>> RegisteredMenus { get; }
        
        void RegisterMenu(int categoryOrder, string categoryName, AweMenuItem menu);

        Dictionary<string, List<AweMenuItem>> BuildMenu();
    }
}
