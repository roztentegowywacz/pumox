using System.Collections.Generic;

namespace Pumox.Core.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }

        public virtual ICollection<Employe> Employees { get; set; }
    }
}