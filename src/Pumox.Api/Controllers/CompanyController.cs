using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pumox.Services.Companies.Commands.CreateCompany;
using Pumox.Services.Dispatchers;

namespace Pumox.Api.Controllers
{
  public class CompanyController : ApiController
  {
    public CompanyController(IDispatcher dispatcher) : base(dispatcher)
    { }

    [HttpPost("create")]
    public async Task<IActionResult> Post(CreateCompanyCommand command)
    {
        await _dispatcher.SendAsync(command);
        return Ok();
    }
  }
}