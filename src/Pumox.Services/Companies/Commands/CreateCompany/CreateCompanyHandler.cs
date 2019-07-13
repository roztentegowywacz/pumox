using System.Linq;
using System.Threading.Tasks;
using Pumox.Core.Domain.Entities;
using Pumox.Core.Domain.Repositories;

namespace Pumox.Services.Companies.Commands.CreateCompany
{
    public class CreateCompanyHandler : ICommandHandler<CreateCompanyCommand, ulong>
    {
        private readonly ICompaniesRepository _companiesRepository;

        public CreateCompanyHandler(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<ulong> HandleAsync(CreateCompanyCommand command)
        {
            var company = new Company()
            {
                Name = command.Name,
                EstablishmentYear = command.EstablishmentYear,
                Employees = command.Employees?.Select(x => new Employe() 
                {
                    DateOfBirth = x.DateOfBirth,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle
                }).ToList()
            };
            _companiesRepository.Add(company);
            await _companiesRepository.SaveChangesAsync();
            
            return company.Id;
        }
    }
}