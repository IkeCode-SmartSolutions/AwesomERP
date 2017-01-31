using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Mvc.Core.Multitenancy
{
    public class AweDefaultTenantResolver : ITenantResolver<AweAppTenant>
    {
        private readonly IEnumerable<AweAppTenant> tenants;

        public AweDefaultTenantResolver(IOptions<AweMultitenancyOptions> options)
        {
            this.tenants = options.Value.Tenants;
        }

        public async Task<TenantContext<AweAppTenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<AweAppTenant> tenantContext = null;

            var tenant = tenants.FirstOrDefault(t => t.Hostnames.Any(h => h.Equals(context.Request.Host.Value.ToLower())));

            if (tenant != null)
            {
                tenantContext = new TenantContext<AweAppTenant>(tenant);
            }

            return await Task.FromResult(tenantContext);
        }
    }
}
