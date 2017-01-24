using Awe.Module.Core;
using System;

[assembly: DefaultNamespace("Awe.Theme.Core")]
namespace Awe.Theme.Core
{
    public class ThemeDef : IAweTheme
    {
        public string Description { get { return "Awe.Theme.Core description"; } }

        public string Name { get { return "Awe.Theme.Core"; } }

        public int? Order
        {
            get
            {
                return -9999;
            }
        }

        public void RegisterServices()
        {
            
        }
    }
}
