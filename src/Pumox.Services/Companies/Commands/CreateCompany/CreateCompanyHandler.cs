using System.Linq;
using System.Threading.Tasks;
using Pumox.Core.Domain.Entities;
using Pumox.Core.Domain.Repositories;

namespace Pumox.Services.Companies.Commands.CreateCompany
{
    public class CreateCompanyHandler : ICommandHandler<CreateCompanyCommand>
    {
        private readonly ICompaniesRepository _companiesRepository;

        public CreateCompanyHandler(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task HandleAsync(CreateCompanyCommand command)
        {
            var company = new Company()
            {
                Name = command.Name,
                EstablishmentYear = command.EstablishmentYear,
                Employees = command.Employees.Select(x => new Employe() 
                {
                    DateOfBirth = x.DateOfBirth,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle
                }).ToList()
            };
            await _companiesRepository.AddAsync(company);
            await _companiesRepository.SaveChangesAsync();
            var companyId = company.Id;
        }
    }
}