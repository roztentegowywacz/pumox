using System.Collections.Generic;
using System.Threading.Tasks;
using Pumox.Core.Domain.Entities;

namespace Pumox.Core.Domain.Repositories
{
    public interface ICompaniesRepository
    {
        void Add(Company company);
        Task<Company> GetWithEmployeesAsync(ulong id);
        void Update(Company company);
        void Remove(Company company);
        Task SaveChangesAsync();
    }
}