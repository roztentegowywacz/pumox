using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pumox.Infrastructure.Authentication
{
    public class BasicAuthenticationMiddleware : IMiddleware
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Admins _admins;

        public BasicAuthenticationMiddleware(IHttpContextAccessor httpContextAccessor,
                                             Admins admins)
        {
            _httpContextAccessor = httpContextAccessor;
            _admins = admins;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                var token = GetCurrenToken();
                var credentials = DecodeToken(token);
                if (isAuthenticate(credentials))
                {
                    await next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return;
                }
            }
            catch
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }            
        }

        private string GetCurrenToken()
        {
            var authorizationHeader = _httpContextAccessor
                .HttpContext.Request.Headers["authorization"];

            return string.IsNullOrWhiteSpace(authorizationHeader)
                ? string.Empty
                : authorizationHeader.Single()
                                     .Trim()
                                     .Split(' ')
                                     .Last();
        }

        private AdminCredentials DecodeToken(string token)
        {
            var encodedBytes = Convert.FromBase64String(token);
            var decodedToken = Encoding.UTF8.GetString(encodedBytes);

            int seperatorIndex = decodedToken.IndexOf(':');
            if (seperatorIndex <= 0 || seperatorIndex == decodedToken.Length - 1)
            {
                throw new Exception();
            }

            return new AdminCredentials()
            {
                Login = decodedToken.Substring(0, seperatorIndex),
                Password = decodedToken.Substring(seperatorIndex + 1)
            };
        }

        private bool isAuthenticate(AdminCredentials credentials)
        {
            var admin = _admins.Collection.SingleOrDefault(x => x.Login == credentials.Login &&
                                                           x.Password == credentials.Password);

            return admin != null;
        }
    }
}