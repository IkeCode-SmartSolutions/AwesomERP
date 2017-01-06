using Module.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: DefaultNamespace(nameof(Aew.Menu.Component))]
namespace Aew.Menu.Component
{
    public class ComponentDef : IBaseViewComponent
    {
        public string Description { get { return "Menu component description"; } }

        public string Name { get { return "Menu"; } }
    }
}
