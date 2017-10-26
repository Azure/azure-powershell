using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class VirtualNetworkParameters 
        : ResourceParameters<VirtualNetwork>
    {
        public VirtualNetworkParameters(
            string name, ResourceGroupParameters resourceGroup)
            : base(name, resourceGroup, NoDependencies)
        {
        }
    }
}
