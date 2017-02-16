using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Models
{
    public class AweTenantHost : AweBaseModel
    {
        public int TenantId { get; set; }
        public AweAppTenant Tenant { get; set; }
    }
}
