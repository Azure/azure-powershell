using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSPrivateEndpointConnection : PSSynapseProxyResource
    {

        public PSPrivateEndpointConnection(PrivateEndpointConnection e)
            : base(e?.Id, e?.Name, e?.Type)
        {
            this.PrivateEndpoint = e?.PrivateEndpoint != null ? new PSPrivateEndpoint(e.PrivateEndpoint) : null;
            this.PrivateLinkServiceConnectionState = e?.PrivateLinkServiceConnectionState != null
                ? new PSPrivateLinkServiceConnectionState(e.PrivateLinkServiceConnectionState)
                : null;
            this.ProvisioningState = e?.ProvisioningState;
        }

        /// <summary>
        /// Gets the private endpoint which the connection belongs to.
        /// </summary>
        public PSPrivateEndpoint PrivateEndpoint { get; set; }

        /// <summary>
        /// Gets connection state of the private endpoint connection.
        /// </summary>
        public PSPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }

        /// <summary>
        /// Gets provisioning state of the private endpoint connection.
        /// </summary>
        public string ProvisioningState { get; set; }
    }
}