using System.Collections.Generic;
using System.Threading.Tasks;
using Pumox.Core.Domain.Entities;
using Pumox.Core.Types;

namespace Pumox.Core.Domain.Repositories
{
    public interface ICompaniesRepository
    {
        void Add(Company company);
        Task<Company> GetWithEmployeesAsync(ulong id);
        Task<IEnumerable<Company>> SearchAsync(SearchCompanyModel query);
        void Update(Company company);
        void Remove(Company company);
        Task SaveChangesAsync();
    }
}