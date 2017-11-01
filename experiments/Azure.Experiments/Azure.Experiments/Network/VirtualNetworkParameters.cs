using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class VirtualNetworkParameters 
        : NetworkParameters<VirtualNetwork>
    {
        public override string Name { get; }

        public override ResourceGroupParameters ResourceGroup { get; }

        public override IEnumerable<ResourceParameters> ResourceDependencies => NoDependencies;

        public VirtualNetworkParameters(string name, ResourceGroupParameters resourceGroup)
        {
            Name = name;
            ResourceGroup = resourceGroup;
        }

        protected override Task<VirtualNetwork> GetAsync(NetworkManagementClient client)
            => client.VirtualNetworks.GetAsync(ResourceGroup.Name, Name);
    }
}
