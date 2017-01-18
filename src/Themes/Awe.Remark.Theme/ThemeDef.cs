using Awe.Module.Core;
using Awe.Mvc.Core.TagHelpers;
using System;

[assembly: DefaultNamespace("Awe.Remark.Theme")]
namespace Awe.Remark.Theme
{
    public class ThemeDef : IAweTheme
    {
        public string Description { get { return "Remark theme description"; } }

        public string Name { get { return "Remark"; } }

        public int? Order
        {
            get
            {
                return 0;
            }
        }
    }
}
