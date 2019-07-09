using Microsoft.EntityFrameworkCore;
using Pumox.Core.Domain.Entities;

namespace Pumox.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employe> Employees { get; set; }   
    }
}