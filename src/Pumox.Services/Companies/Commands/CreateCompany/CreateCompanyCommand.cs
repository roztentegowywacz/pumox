using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pumox.Core.Types.Enums;

namespace Pumox.Services.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : ICommand
    {
        public string Name { get; }
        public int EstablishmentYear { get; }
        public ICollection<Employer> Employees { get; } = new List<Employer>();

        [JsonConstructor]
        public CreateCompanyCommand(string name, int establishmentYear,
            ICollection<Employer> employees)
        {
            Name = name;
            EstablishmentYear = establishmentYear;
            Employees = employees;
        }

        public class Employer
        {
            public string FirstName { get; }
            public string LastName { get; }
            public DateTime DateOfBirth { get; }
            public JobTitle JobTitle { get; }
        }
    }
}