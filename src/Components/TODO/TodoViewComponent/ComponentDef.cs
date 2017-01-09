using Module.Core;
using System;

[assembly: DefaultNamespace("TodoViewComponent")]
namespace TodoViewComponent
{
    public class ComponentDef : IBaseViewComponent
    {
        public string Description { get { return "TODO component description"; } }

        public string Name { get { return "TODO"; } }
    }
}
