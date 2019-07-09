using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Pumox.Infrastructure.Mvc
{
    public static class Extensions
    {
        public static IMvcCoreBuilder AddCustomMvc(this IServiceCollection services)
            => services
                .AddMvcCore()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }
}