using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSDiskAccess
    {
        public IList<PrivateEndpointConnection> PrivateEndpointConnections { get; set; }
        public string ProvisioningState { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string Location { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IDictionary<string, string> Tags { get; set; }
    }
}
