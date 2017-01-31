using System;

namespace Awe.Menu
{
    public class AweMenuCategory
    {
        public string Title { get; private set; }
        public int Order { get; private set; }
        
        public AweMenuCategory(AweMenuCategory menuCategory)
        {
            Title = menuCategory.Title;
            Order = menuCategory.Order;
        }

        public AweMenuCategory(int order, string title)
        {
            title = title == null ? "Outros" : title;

            Title = title;
            Order = order;
        }

        public override int GetHashCode()
        {
            return ($"{this.Order}{this.Title}").GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var o = obj as AweMenuCategory;

            return o.Order == this.Order && o.Title.Equals(this.Title, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
