using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;

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
            this.Properties = managedPrivateEndpoint?.Properties != null? new PSManagedPrivateEndpointProperties(managedPrivateEndpoint.Properties) : null;
        }

        public string WorkspaceName { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get;  set; }

        public PSManagedPrivateEndpointProperties Properties { get;  set; }
    }
}
