using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedPrivateEndpointResource 
    {
        public PSManagedPrivateEndpointResource(ManagedPrivateEndpoint managedPrivateEndpoint, string workspaceName)
        {
            this.WorkspaceName = workspaceName;
            this.Id = managedPrivateEndpoint?.Id;
            this.Name = managedPrivateEndpoint?.Name;
            this.Type = managedPrivateEndpoint?.Type;
            this.Properties = managedPrivateEndpoint?.Properties;
               
        }

        public string WorkspaceName { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get;  set; }

        public ManagedPrivateEndpointProperties Properties { get;  set; }

    }
}
