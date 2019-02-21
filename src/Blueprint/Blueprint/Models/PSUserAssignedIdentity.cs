using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSUserAssignedIdentity
    {
        public string PrincipalId { get; set; }
        public string ClientId { get; set; }
    }
}
