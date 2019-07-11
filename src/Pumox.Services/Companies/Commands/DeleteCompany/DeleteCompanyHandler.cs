using System.Threading.Tasks;
using Pumox.Core.Domain.Repositories;

namespace Pumox.Services.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyHandler : ICommandHandler<DeleteCompanyCommand>
    {
        private readonly ICompaniesRepository _companiesRepository;

        public DeleteCompanyHandler(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task HandleAsync(DeleteCompanyCommand command)
        {
            var company = await _companiesRepository.GetWithEmployeesAsync(command.Id);
            
            if (company is null)
            {
                // TODO: rzuć wyjtkiem albo coś
            }

            _companiesRepository.Remove(company);

            await _companiesRepository.SaveChangesAsync();
        }
    }
}