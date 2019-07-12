using Microsoft.AspNetCore.Builder;

namespace Pumox.Infrastructure.Authentication
{
    public class BasicAuthenticationFilter
    {
        public void Configure(IApplicationBuilder appBuilder) 
        {
            appBuilder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}