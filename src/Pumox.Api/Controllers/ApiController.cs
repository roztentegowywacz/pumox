using Microsoft.AspNetCore.Mvc;
using Pumox.Infrastructure.Authentication;
using Pumox.Services.Dispatchers;

namespace Pumox.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected readonly IDispatcher _dispatcher;

        public ApiController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
  }
}