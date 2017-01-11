using Awe.Module.Core;
using System;

[assembly: DefaultNamespace("TodoViewComponent")]
namespace TodoViewComponent
{
    public class ComponentDef : IAweViewComponent
    {
        public string Description { get { return "TODO component description"; } }

        public string Name { get { return "TODO"; } }
    }
}
