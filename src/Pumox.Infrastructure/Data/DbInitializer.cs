using System;
using System.Collections.Generic;
using System.Linq;
using Pumox.Core.Domain.Entities;
using Pumox.Core.Types.Enums;

namespace Pumox.Infrastructure.Data
{
    public class DbInitializer
    {
        private readonly AppDbContext _ctx;

        private DbInitializer(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public static void Initialize(AppDbContext ctx)
        {
            var initializer = new DbInitializer(ctx);
            initializer.Seed();
        }

        private void Seed()
        {
            _ctx.Database.EnsureCreated();
            
            if (_ctx.Companies.Any())
                return;

            var company1 = new Company()
            {
                Name = "Test company",
                EstablishmentYear = 2019,
                Employees = new List<Employe>()
                {
                    new Employe()
                    {
                        FirstName = "Janusz",
                        LastName = "Kowalski",
                        DateOfBirth = new DateTime(1990, 01, 01),
                        JobTitle = JobTitle.Developer
                    },
                    new Employe()
                    {
                        FirstName = "Grażyna",
                        LastName = "Kowalska",
                        DateOfBirth = new DateTime(1986, 12, 25),
                        JobTitle = JobTitle.Manager
                    }
                }
            };
            _ctx.Companies.Add(company1);

            var company2 = new Company()
            {
                Name = "Informatex",
                EstablishmentYear = 2019,
                Employees = new List<Employe>()
                {
                    new Employe()
                    {
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        DateOfBirth = new DateTime(1992, 03, 01),
                        JobTitle = JobTitle.Developer
                    },
                    new Employe()
                    {
                        FirstName = "Anna",
                        LastName = "Michalska",
                        DateOfBirth = new DateTime(1996, 02, 25),
                        JobTitle = JobTitle.Developer
                    },
                    new Employe()
                    {
                        FirstName = "Władysław",
                        LastName = "Jagiełło",
                        DateOfBirth = new DateTime(1990, 02, 10),
                        JobTitle = JobTitle.Manager
                    }
                }
            };

            _ctx.Companies.Add(company2);

            _ctx.SaveChanges();
        }
    }
}