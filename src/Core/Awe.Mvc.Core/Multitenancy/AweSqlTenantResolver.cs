using Awe.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Mvc.Core.Multitenancy
{
    public class AweSqlTenantResolver : ITenantResolver<AweAppTenant2>
    {
        private readonly AweCoreDbContext _dbContext;

        public AweSqlTenantResolver(AweCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TenantContext<AweAppTenant2>> ResolveAsync(HttpContext context)
        {
            TenantContext<AweAppTenant2> tenantContext = null;

            var hostName = context.Request.Host.Value.ToLower();

            var tenant = _dbContext.Tenants.FirstOrDefault(t => t.TenantHosts.Any(h => h.Name.Equals(hostName)));

            if (tenant != null)
            {
                //tenantContext = new TenantContext<AweAppTenant>(tenant);
            }

            return await Task.FromResult(tenantContext);
        }
    }
}
