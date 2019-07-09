using System.Collections.Generic;

namespace Pumox.Core.Domain.Entities
{
    public class Company
    {
        public ulong CompanyId { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }

        public ICollection<Employe> Employees { get; set; }
    }
}