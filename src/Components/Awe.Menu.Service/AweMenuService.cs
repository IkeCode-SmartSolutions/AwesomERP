using System.Collections.Generic;
using System.Linq;

namespace Awe.Menu.Service
{
    public class AweMenuService : IAweMenuService
    {
        public ICollection<AweMenu> RegisteredMenus { get { return _registeredMenus.Select(i => i.Value).ToList(); } }
        Dictionary<string, AweMenu> _registeredMenus { get; set; } = new Dictionary<string, AweMenu>();

        public void RegisterMenu(AweMenu menu)
        {
            _registeredMenus[menu.GetSignature()] = menu;
        }

        public void UnregisterMenu(AweMenu menu)
        {
            var signature = menu.GetSignature();
            if (_registeredMenus.ContainsKey(signature))
            {
                _registeredMenus.Remove(signature);
            }
        }
    }
}
