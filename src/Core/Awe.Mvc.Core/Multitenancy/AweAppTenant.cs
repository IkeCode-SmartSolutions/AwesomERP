namespace Awe.Mvc.Core.Multitenancy
{
    public class AweAppTenant2
    {
        public string Name { get; set; }
        public string[] Hostnames { get; set; }

        public string Theme { get; set; }

        public string ThemeVariant { get; set; }

        public string Skin { get; set; }

        public AweAppTenant2()
        {

        }
    }
}
