using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedPrivateEndpointProperties 
    {
        public PSManagedPrivateEndpointProperties(ManagedPrivateEndpointProperties properties)
        {
            this.PrivateLinkResourceId = properties?.PrivateLinkResourceId;
            this.GroupId = properties?.GroupId;
            this.ProvisioningState = properties?.ProvisioningState;
            this.IsReserved = properties?.IsReserved;
            this.ConnectionState = properties?.ConnectionState != null? new PSManagedPrivateEndpointConnectionState(properties?.ConnectionState) : null;
        }      

        public string PrivateLinkResourceId { get; set; }

        public string GroupId { get; set; }

        public string ProvisioningState { get; }

        public PSManagedPrivateEndpointConnectionState ConnectionState { get; set; }

        public bool? IsReserved { get; }
    }
}
