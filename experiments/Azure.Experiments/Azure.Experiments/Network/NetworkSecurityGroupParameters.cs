using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class NetworkSecurityGroupParameters
        : NetworkParameters<NetworkSecurityGroup>
    {
        public override string Name { get; }

        public override ResourceGroupParameters ResourceGroup { get; }

        public override IEnumerable<Parameters> ResourceDependencies => NoDependencies;

        public NetworkSecurityGroupParameters(
            string name, ResourceGroupParameters resourceGroup)
        {
            Name = name;
            ResourceGroup = resourceGroup;
        }

        protected override Task<NetworkSecurityGroup> GetAsync(
            Context context, IGetParameters _)
            => context
                .CreateNetwork()
                .NetworkSecurityGroups
                .GetAsync(ResourceGroup.Name, Name);
    }
}
