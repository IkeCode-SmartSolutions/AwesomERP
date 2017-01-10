using Module.Core;
using System;

[assembly: DefaultNamespace("Awe.Theme.Core")]
namespace Awe.Remark.Theme
{
    public class ThemeDef : IBaseTheme
    {
        public string Description { get { return "Awe.Theme.Core description"; } }

        public string Name { get { return "Awe.Theme.Core"; } }
    }
}
