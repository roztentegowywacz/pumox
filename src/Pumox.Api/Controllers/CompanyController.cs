using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pumox.Infrastructure.Authentication;
using Pumox.Services.Companies.Commands.CreateCompany;
using Pumox.Services.Companies.Commands.DeleteCompany;
using Pumox.Services.Companies.Commands.UpdateCompany;
using Pumox.Services.Companies.Queries.SearchCompany;
using Pumox.Services.Dispatchers;

namespace Pumox.Api.Controllers
{
    public class CompanyController : ApiController
    {
        public CompanyController(IDispatcher dispatcher) : base(dispatcher)
        { }

        [Route("")]
        public IActionResult Get() => Ok("Pumox Api works!");

        [BaseAuth]
        [HttpPost("create")]
        public async Task<IActionResult> Post(CreateCompanyCommand command)
        {
            var companyId = await _dispatcher.SendAndResponseDataAsync(command);

            return CreatedAtAction(null, companyId);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(SearchCompanyQuery query)
        {
            var companies = await _dispatcher.QueryAsync(query);

            if (companies is null)
            {
                return NotFound();
            }

            return Ok(companies);
        }

        [BaseAuth]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put([FromRoute] ulong id, UpdateCompanyCommand command)
        {            
            await _dispatcher.SendAsync(command);
            
            return NoContent();
        }

        [BaseAuth]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] ulong id)
        {
            await _dispatcher.SendAsync(new DeleteCompanyCommand(id));
            
            return NoContent();
        }
    }
}