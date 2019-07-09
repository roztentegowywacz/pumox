using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pumox.Infrastructure.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddSqlite(this IServiceCollection services)
        {
            IConfiguration configuration;
            
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            var databaseOptions = new DatabaseOptions();
            configuration.Bind("Database", databaseOptions);

            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlite(databaseOptions.ConnectionString));
            
            return services;
        }
    }
}