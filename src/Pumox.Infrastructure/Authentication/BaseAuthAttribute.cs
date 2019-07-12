using Microsoft.AspNetCore.Mvc;

namespace Pumox.Infrastructure.Authentication
{
    public class BaseAuthAttribute : MiddlewareFilterAttribute
    {
        public BaseAuthAttribute() : base(typeof(BasicAuthenticationFilter))
        {
        }
    }
}