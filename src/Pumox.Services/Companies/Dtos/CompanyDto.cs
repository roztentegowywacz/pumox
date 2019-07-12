using System.Collections.Generic;

namespace Pumox.Services.Companies.Dtos
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public ICollection<EmployeDto> Employees { get; set; }
    }
}