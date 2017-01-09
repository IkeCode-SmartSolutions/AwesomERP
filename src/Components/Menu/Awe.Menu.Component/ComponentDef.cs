using Module.Core;
using System;

[assembly: DefaultNamespace("Aew.Menu.Component")]
namespace Aew.Menu.Component
{
    public class ComponentDef : IBaseViewComponent
    {
        public string Description { get { return "Menu component description"; } }

        public string Name { get { return "Menu"; } }
    }
}
