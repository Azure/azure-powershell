using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class PublicIpAddressParameters
        : NetworkParameters<PublicIPAddress>
    {
        public override string Name { get; }

        public override ResourceGroupParameters ResourceGroup { get; }

        public override IEnumerable<Parameters> ResourceDependencies
            => NoDependencies;

        public PublicIpAddressParameters(
            string name, ResourceGroupParameters resourceGroup)
        {
            Name = name;
            ResourceGroup = resourceGroup;
        }

        protected override Task<PublicIPAddress> GetAsync(
            Context context, IGetParameters _)
            => context
                .CreateNetwork()
                .PublicIPAddresses
                .GetAsync(ResourceGroup.Name, Name);
    }
}
