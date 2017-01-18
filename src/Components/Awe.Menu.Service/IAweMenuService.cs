using System.Collections.Generic;

namespace Awe.Menu.Service
{
    public interface IAweMenuService
    {
        Dictionary<int, AweMenu> RegisteredMenus { get; }
        void RegisterMenu(int order, AweMenu menu);
    }
}
