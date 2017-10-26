using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class SubnetParameters : Parameters<Subnet>
    {
        public VirtualNetworkParameters VirtualNetwork { get; }

        public override IEnumerable<Parameters> Dependencies
            => new[] { VirtualNetwork };

        public SubnetParameters(
            string name, VirtualNetworkParameters virtualNetwork)
            : base(name)
        {
            VirtualNetwork = virtualNetwork;
        }
    }
}
