using System.Linq;
using System.Threading.Tasks;
using Pumox.Core.Domain.Entities;
using Pumox.Core.Domain.Repositories;
using Pumox.Core.Types.Exceptions;

namespace Pumox.Services.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyHandler : ICommandHandler<UpdateCompanyCommand>
    {
        private readonly ICompaniesRepository _companiesRepository;

        public UpdateCompanyHandler(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task HandleAsync(UpdateCompanyCommand command)
        {
            var company = await _companiesRepository.GetWithEmployeesAsync((ulong)command.Id);
            
            if (company is null)
            {
                throw new NotFoundException(typeof(Company), (ulong)command.Id);
            }

            company.Name = command.Name;
            company.EstablishmentYear = command.EstablishmentYear;
            company.Employees = command.Employees?.Select(x => new Employe() 
            {
                DateOfBirth = x.DateOfBirth,
                FirstName = x.FirstName,
                LastName = x.LastName,
                JobTitle = x.JobTitle
            }).ToList();

            _companiesRepository.Update(company);

            await _companiesRepository.SaveChangesAsync();
        }
    }
}