using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Mvc.Core.Multitenancy
{
    public class AweConfigTenantResolver : ITenantResolver<AweAppTenant2>
    {
        private readonly IEnumerable<AweAppTenant2> tenants;

        public AweConfigTenantResolver(IOptions<AweMultitenancyOptions> options)
        {
            this.tenants = options.Value.Tenants;
        }

        public async Task<TenantContext<AweAppTenant2>> ResolveAsync(HttpContext context)
        {
            TenantContext<AweAppTenant2> tenantContext = null;

            var tenant = tenants.FirstOrDefault(t => t.Hostnames.Any(h => h.Equals(context.Request.Host.Value.ToLower())));

            if (tenant != null)
            {
                tenantContext = new TenantContext<AweAppTenant2>(tenant);
            }

            return await Task.FromResult(tenantContext);
        }
    }
}
