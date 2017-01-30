using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Awe.Mvc.Core.Multitenancy
{
    public interface ITenantResolver<TTenant>
    {
        Task<TenantContext<TTenant>> ResolveAsync(HttpContext context);
    }
}