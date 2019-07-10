using System;
using Pumox.Core.Types.Enums;

namespace Pumox.Services.Companies.Dtos
{
    public class EmployeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public JobTitle JobTitle { get; set; }
    }
}