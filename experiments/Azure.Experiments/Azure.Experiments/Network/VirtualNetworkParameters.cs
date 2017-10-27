using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network;

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

        protected override Task<VirtualNetwork> GetAsync(
            Context context, IGetParameters _)
            => context
                .CreateNetwork()
                .VirtualNetworks
                .GetAsync(ResourceGroup.Name, Name);
    }
}
