using System;
using Pumox.Core.Types.Enums;

namespace Pumox.Core.Domain.Entities
{
    public class Employe
    {
        public ulong Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public JobTitle JobTitle { get; set; }

        public ulong CompanyId { get; set; }
        public Company Company { get; set; }
    }
}