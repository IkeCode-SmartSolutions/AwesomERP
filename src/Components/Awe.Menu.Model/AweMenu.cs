using Awe.Core.Crypto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Awe.Menu
{
    public class AweMenu
    {
        private AweMenu(string parent, string title, string hint, int order = 0, string icon = "")
        {
            Parent = parent;
            Title = title;
            Hint = hint;
            Order = order;
            Icon = icon;
        }

        public AweMenu(string routeName, string parent, string title, string hint, int order = 0, string icon = "")
            : this(parent, title, hint, order, icon)
        {
            RouteName = routeName;
        }

        public AweMenu(string controller, string action, string parent, string title, string hint, int order = 0, string icon = "")
            : this(parent, title, hint, order, icon)
        {
            RouteName = $"${controller}#{action}";
        }

        public string Parent { get; private set; }
        public string Title { get; private set; }
        public string Hint { get; private set; }
        public int Order { get; private set; }
        public string RouteName { get; private set; }
        public string Icon { get; private set; }
    }
}
