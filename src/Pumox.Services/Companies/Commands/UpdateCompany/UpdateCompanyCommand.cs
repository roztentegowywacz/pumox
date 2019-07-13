using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pumox.Core.Types.Enums;

namespace Pumox.Services.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : ICommand
    {
        public ulong? Id { get; set; }
        public string Name { get; }
        public int EstablishmentYear { get; }
        public IEnumerable<UpdateEmployer> Employees { get; } = new List<UpdateEmployer>();

        [JsonConstructor]
        public UpdateCompanyCommand(string name, int establishmentYear,
            IEnumerable<UpdateEmployer> employees)
        {
            Name = name;
            EstablishmentYear = establishmentYear;
            Employees = employees;
        }

        public class UpdateEmployer
        {
            public string FirstName { get; }
            public string LastName { get; }
            public DateTime DateOfBirth { get; }
            public JobTitle JobTitle { get; }

            [JsonConstructor]
            public UpdateEmployer(string firstName, string lastName,
                DateTime dateOfBirth, JobTitle jobTitle)
            {
                FirstName = firstName;
                LastName = lastName;
                DateOfBirth = dateOfBirth;
                JobTitle = jobTitle;
            }
        }
    }
}