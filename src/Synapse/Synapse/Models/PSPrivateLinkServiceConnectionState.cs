using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSPrivateLinkServiceConnectionState
    {
        public PSPrivateLinkServiceConnectionState(PrivateLinkServiceConnectionState privateLinkServiceConnectionState)
        {
            this.Status = privateLinkServiceConnectionState?.Status;
            this.Description = privateLinkServiceConnectionState?.Description;
            this.ActionsRequired = privateLinkServiceConnectionState?.ActionsRequired;
        }

        /// <summary>
        /// Gets or sets the private link service connection status. Possible
        /// values include: 'Approved', 'Pending', 'Rejected', 'Disconnected'
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the private link service connection description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the actions required for private link service connection.
        /// </summary>
        public string ActionsRequired { get; set; }
    }
}