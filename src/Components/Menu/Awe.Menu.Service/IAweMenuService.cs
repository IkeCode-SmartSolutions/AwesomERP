using System.Collections.Generic;

namespace Awe.Menu.Service
{
    public interface IAweMenuService
    {
        ICollection<AweMenu> RegisteredMenus { get; }
        void RegisterMenu(AweMenu menu);
        void UnregisterMenu(AweMenu menu);
    }
}
