using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pumox.Core.Domain.Entities;
using Pumox.Core.Domain.Repositories;
using Pumox.Core.Types;

namespace Pumox.Infrastructure.Data.Repositories
{
  public class CompaniesRepository : ICompaniesRepository
    {
        private AppDbContext _ctx;

        public CompaniesRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public void Add(Company company)
            => _ctx.Companies.Add(company);
        
        public async Task<Company> GetWithEmployeesAsync(ulong id)
            => await _ctx.Companies.Include(x => x.Employees)
                                   .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Company>> SearchAsync(SearchCompanyModel query)
            => await _ctx.Companies.Include(x => x.Employees)
                             .Where(x => x.Name.Contains(query.Keyword) ||
                                         x.Employees.Any(e => e.FirstName.Contains(query.Keyword) ||
                                                              e.LastName.Contains(query.Keyword)) ||
                                         x.Employees.Any(e => e.DateOfBirth > query.EmployeeDateOfBirthFrom &&
                                                              e.DateOfBirth < query.EmployeeDateOfBirthTo) ||
                                         x.Employees.Any(e => query.EmployeeJobTitles.Contains(e.JobTitle)))
                             .ToListAsync();

        public void Update(Company company)
            => _ctx.Companies.Update(company);

        public void Remove(Company company)
            => _ctx.Companies.Remove(company);
        
        public async Task SaveChangesAsync()
            => await _ctx.SaveChangesAsync();
    }
}