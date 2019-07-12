using System.Collections.Generic;

namespace Pumox.Infrastructure.Authentication
{
    public class FakedAdmins
    {
        public IEnumerable<AdminCredentials> Collection { get; set; }
    }
}