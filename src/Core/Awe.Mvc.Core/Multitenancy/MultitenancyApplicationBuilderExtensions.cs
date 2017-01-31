using Awe.Mvc.Core.Multitenancy;
using Awe.Mvc.Core.Multitenancy.Internal;

namespace Microsoft.AspNetCore.Builder
{
    public static class MultitenancyApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMultitenancy<TTenant>(this IApplicationBuilder app)
        {
            Ensure.Argument.NotNull(app, nameof(app));
            return app.UseMiddleware<TenantResolutionMiddleware<TTenant>>();
        }

        public static IApplicationBuilder UseDefaultMultitenancy(this IApplicationBuilder app)
        {
            return app.UseMultitenancy<AweAppTenant>();
        }
    }
}
