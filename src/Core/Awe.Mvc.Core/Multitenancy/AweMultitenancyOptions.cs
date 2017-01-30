using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Mvc.Core.Multitenancy
{
    public class AweMultitenancyOptions
    {
        public ICollection<AweAppTenant> Tenants { get; set; }
    }
}
