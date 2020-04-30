using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSPrivateEndpoint
    {
        public PSPrivateEndpoint(PrivateEndpoint privateEndpoint)
        {
            this.Id = privateEndpoint?.Id;
        }

        /// <summary>
        /// Gets resource id of the private endpoint.
        /// </summary>
        public string Id { get; private set; }
    }
}