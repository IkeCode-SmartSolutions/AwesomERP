using System.Collections.Generic;

namespace Awe.Menu.Service
{
    public interface IAweMenuService
    {
        Dictionary<AweMenuCategory, List<AweMenu>> RegisteredMenus { get; }
        
        void RegisterMenu(int categoryOrder, string categoryName, AweMenu menu);

        Dictionary<string, List<AweMenu>> BuildMenu();
    }
}
