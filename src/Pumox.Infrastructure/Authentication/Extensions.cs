using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pumox.Infrastructure.Authentication
{
    public static class Extensions
    {
        public static IServiceCollection AddBasicAuthentication(this IServiceCollection services)
            => services.AddScoped<BasicAuthenticationMiddleware>();

        public static IServiceCollection ConfigureFakeAdmins(this IServiceCollection services)
        {
            IConfiguration configuration;
            
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            var options = configuration.GetSection("AdminsCredentials").Get<FakedAdmins>();

            return services.AddSingleton<FakedAdmins>(options);
        }
    }
}