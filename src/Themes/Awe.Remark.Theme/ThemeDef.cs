using Module.Core;
using System;

[assembly: DefaultNamespace("Awe.Remark.Theme")]
namespace Awe.Remark.Theme
{
    public class ThemeDef : IBaseTheme
    {
        public string Description { get { return "Remark theme description"; } }

        public string Name { get { return "Remark"; } }
    }
}
