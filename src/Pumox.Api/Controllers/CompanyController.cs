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

        /// <summary>
        /// Create new Comany with employees
        /// </summary>
        /// <param name="command">Company with employee collection object.
        /// Employee collection is optional.</param>
        /// <returns>Id of new created company.</returns>        
        [BaseAuth]
        [HttpPost("create")]
        public async Task<IActionResult> Post(CreateCompanyCommand command)
        {
            var companyId = await _dispatcher.SendAndResponseDataAsync(command);

            return CreatedAtAction(null, companyId);
        }

        /// <summary>
        /// Company searcher with filters
        /// </summary>
        /// <param name="query">Search filter object with all properties as optional.</param>
        /// <returns>Companies collection fulfilling the search conditions.</returns>
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

        /// <summary>
        /// Update company with associated employees
        /// </summary>
        /// <param name="id">Company Id</param>
        /// <param name="command">Company object with updated properties and employees.</param>
        /// <returns>No content if saccesfull updated.</returns>
        [BaseAuth]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put([FromRoute] ulong id, [FromBody]UpdateCompanyCommand command)
        {
            command.Id = id;

            await _dispatcher.SendAsync(command);
            
            return NoContent();
        }

        /// <summary>
        /// Delete company and associated employees.
        /// </summary>
        /// <param name="id">Company Id</param>
        /// <returns>No content is saccesfull deleted.</returns>
        [BaseAuth]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] ulong id)
        {
            await _dispatcher.SendAsync(new DeleteCompanyCommand(id));
            
            return NoContent();
        }
    }
}