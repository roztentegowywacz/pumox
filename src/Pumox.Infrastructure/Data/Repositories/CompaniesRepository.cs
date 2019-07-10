using System.Threading.Tasks;
using Pumox.Core.Domain.Entities;
using Pumox.Core.Domain.Repositories;

namespace Pumox.Infrastructure.Data.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private AppDbContext _ctx;

        public CompaniesRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task AddAsync(Company company)
            => await _ctx.Companies.AddAsync(company);
        
        public async Task SaveChangesAsync()
            => await _ctx.SaveChangesAsync();
    }
}