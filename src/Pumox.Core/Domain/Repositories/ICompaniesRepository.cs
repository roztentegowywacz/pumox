using System.Threading.Tasks;
using Pumox.Core.Domain.Entities;

namespace Pumox.Core.Domain.Repositories
{
    public interface ICompaniesRepository
    {
        Task AddAsync(Company company);
        Task SaveChangesAsync();
    }
}