using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Mvc.Core.Multitenancy
{
    public class AweCachingAppTenantResolver : MemoryCacheTenantResolver<AweAppTenant>
    {
        private readonly IEnumerable<AweAppTenant> tenants;

        public AweCachingAppTenantResolver(IMemoryCache cache, ILoggerFactory loggerFactory, IOptions<AweMultitenancyOptions> options)
            : base(cache, loggerFactory)
        {
            this.tenants = options.Value.Tenants;
        }

        protected override string GetContextIdentifier(HttpContext context)
        {
            return context.Request.Host.Value.ToLower();
        }

        protected override IEnumerable<string> GetTenantIdentifiers(TenantContext<AweAppTenant> context)
        {
            return context.Tenant.Hostnames;
        }

        protected override Task<TenantContext<AweAppTenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<AweAppTenant> tenantContext = null;

            var tenant = tenants.FirstOrDefault(t => t.Hostnames.Any(h => h.Equals(context.Request.Host.Value.ToLower())));

            if (tenant != null)
            {
                tenantContext = new TenantContext<AweAppTenant>(tenant);
            }

            return Task.FromResult(tenantContext);
        }

        protected override MemoryCacheEntryOptions CreateCacheEntryOptions()
        {
            return base.CreateCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));
        }
    }
}
