using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pumox.Core.Types.Enums;

namespace Pumox.Services.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : ICommand<ulong>
    {
        public string Name { get; }
        public int EstablishmentYear { get; }
        public ICollection<CreateEmployer> Employees { get; } = new List<CreateEmployer>();

        [JsonConstructor]
        public CreateCompanyCommand(string name, int establishmentYear,
            ICollection<CreateEmployer> employees)
        {
            Name = name;
            EstablishmentYear = establishmentYear;
            Employees = employees;
        }

        public class CreateEmployer
        {
            public string FirstName { get; }
            public string LastName { get; }
            public DateTime DateOfBirth { get; }
            public JobTitle JobTitle { get; }

            [JsonConstructor]
            public CreateEmployer(string firstName, string lastName,
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