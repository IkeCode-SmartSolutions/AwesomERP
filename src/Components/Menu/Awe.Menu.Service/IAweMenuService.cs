using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Menu.Service
{
    public interface IAweMenuService
    {
        ICollection<AweMenu> RegisteredMenus { get; }
        void RegisterMenu(AweMenu menu);
        void UnregisterMenu(AweMenu menu);
    }
}
