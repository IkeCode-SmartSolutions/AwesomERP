namespace System
{
    public class DefaultNamespaceAttribute : Attribute
    {
        private string _defaultNamespace;

        public DefaultNamespaceAttribute(string defaultNamespace)
        {
            _defaultNamespace = defaultNamespace;
        }

        public string DefaultNamespace { get { return _defaultNamespace; } }
    }
}
