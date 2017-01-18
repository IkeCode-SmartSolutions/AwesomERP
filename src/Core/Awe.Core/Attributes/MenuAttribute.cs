namespace System
{
    public class MenuAttribute : Attribute
    {
        private string _parent;
        private string _title;
        private int _order;
        private string _icon;
        private string _hint;

        public MenuAttribute(string parent, string title, string hint = "", int order = 0, string icon = "")
        {
            _parent = parent;
            _title = title;
            _order = order;
            _icon = icon;
            _hint = string.IsNullOrWhiteSpace(hint) ? title : hint;
        }

        public string Parent { get { return _parent; } }

        public string Title { get { return _title; } }

        public int Order { get { return _order; } }

        public string Icon { get { return _icon; } }

        public string Hint { get { return _hint; } }
    }
}
