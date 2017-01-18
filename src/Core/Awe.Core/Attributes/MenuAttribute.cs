namespace System
{
    public class MenuAttribute : Attribute
    {
        private string _parent;
        private string _title;

        public MenuAttribute(string parent, string title)
        {
            _parent = parent;
            _title = title;
        }

        public string Parent { get { return _parent; } }
        public string Title { get { return _title; } }
    }
}
