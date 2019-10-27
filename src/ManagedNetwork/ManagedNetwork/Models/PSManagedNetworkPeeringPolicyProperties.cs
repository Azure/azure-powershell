using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ManagedNetwork.Models
{
    public class PSManagedNetworkPeeringPolicyProperties 
    {
        /// <summary>
        /// Gets or sets an type of policy
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets an Id for a Hub Vnet
        /// </summary>
        public PSResourceId Hub { get; set; }

        /// <summary>
        /// Gets or sets a list of Spoke Groups
        /// </summary>
        public List<PSResourceId> Spokes { get; set; }

        /// <summary>
        /// Gets or sets a list of Mesh Groups
        /// </summary>
        public List<PSResourceId> Mesh { get; set; }
    }
}
