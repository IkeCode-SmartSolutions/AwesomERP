using Awe.Module.Core;
using System;

[assembly: DefaultNamespace("Awe.Todo.Component")]
namespace Awe.Todo.Component
{
    public class ComponentDef : IAweViewComponent
    {
        public string Description { get { return "TODO component description"; } }

        public string Name { get { return "TODO"; } }

        public int? Order
        {
            get
            {
                return 0;
            }
        }
    }
}
