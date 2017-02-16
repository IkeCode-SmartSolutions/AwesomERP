using System.Collections.Generic;

namespace Awe.Mvc.Core.Multitenancy
{
    public class AweMultitenancyOptions
    {
        public ICollection<AweAppTenant2> Tenants { get; set; }
    }
}
