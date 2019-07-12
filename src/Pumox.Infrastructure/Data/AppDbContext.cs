using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pumox.Core.Domain.Entities;
using Pumox.Core.Types.Enums;

namespace Pumox.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employe> Employees { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new EnumToStringConverter<JobTitle>();

            modelBuilder.Entity<Employe>()
                        .Property(e => e.JobTitle)
                        .HasConversion(converter);
        }
    }
}