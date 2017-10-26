using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class SubnetParameters : Parameters<Subnet>
    {
        public VirtualNetworkParameters VirtualNetwork { get; }

        public SubnetParameters(
            string name, VirtualNetworkParameters virtualNetwork)
            : base(name, new[] { virtualNetwork })
        {
            VirtualNetwork = virtualNetwork;
        }
    }
}
