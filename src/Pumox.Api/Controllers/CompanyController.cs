using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pumox.Services.Companies.Commands.CreateCompany;
using Pumox.Services.Companies.Commands.DeleteCompany;
using Pumox.Services.Companies.Commands.UpdateCompany;
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

        [HttpPut("update/{id:ulong}")]
        public async Task<IActionResult> Put([FromRoute] ulong id, UpdateCompanyCommand command)
        {
            command.Id = id;
            
            await _dispatcher.SendAsync(command);
            
            return NoContent();
        }

        [HttpDelete("delete/{id:ulong}")]
        public async Task<IActionResult> Delete([FromRoute] ulong id)
        {
            await _dispatcher.SendAsync(new DeleteCompanyCommand(id));
            
            return NoContent();
        }
    }
}