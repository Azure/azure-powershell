using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSDiskAccess
    {
        public IList<PrivateEndpointConnection> PrivateEndpointConnections { get; }
        public string ProvisioningState { get; }
        public DateTime? TimeCreated { get; }
    }
}
