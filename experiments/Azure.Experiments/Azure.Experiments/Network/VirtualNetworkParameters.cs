using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class VirtualNetworkParameters 
        : ResourceParameters<VirtualNetwork>
    {
        public override IEnumerable<Parameters> ResourceDependencies
            => NoDependencies;

        public VirtualNetworkParameters(
            string name, ResourceGroupParameters resourceGroup)
            : base(name, resourceGroup)
        {
        }
    }
}
