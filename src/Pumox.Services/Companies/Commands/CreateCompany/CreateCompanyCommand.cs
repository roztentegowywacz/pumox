using System.Collections.Generic;
using Newtonsoft.Json;
using Pumox.Services.Companies.Dtos;

namespace Pumox.Services.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : ICommand
    {
        public string Name { get; }
        public int EstablishmentYear { get; }
        public ICollection<EmployeDto> Employees { get; } = new List<EmployeDto>();

        [JsonConstructor]
        public CreateCompanyCommand(string name, int establishmentYear,
            ICollection<EmployeDto> employees)
        {
            Name = name;
            EstablishmentYear = establishmentYear;
            Employees = employees;
        }
    }
}