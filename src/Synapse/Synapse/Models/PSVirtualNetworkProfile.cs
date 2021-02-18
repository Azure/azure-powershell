using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSVirtualNetworkProfile
    {
        public string VirtualNetworkProfileComputeSubnetId { get; set; }

        public PSVirtualNetworkProfile(VirtualNetworkProfile virtualNetworkProfile)
        {
            this.VirtualNetworkProfileComputeSubnetId = virtualNetworkProfile?.ComputeSubnetId;
        }
    }
}