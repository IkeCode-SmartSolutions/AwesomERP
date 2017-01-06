using Module.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: DefaultNamespace(nameof(TodoViewComponent))]
namespace TodoViewComponent
{
    public class ComponentDef : IBaseViewComponent
    {
        public string Description { get { return "TODO component description"; } }

        public string Name { get { return "TODO"; } }
    }
}
