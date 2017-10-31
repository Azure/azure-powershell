using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class NetworkSecurityGroupParameters
        : NetworkParameters<NetworkSecurityGroup>
    {
        public NetworkSecurityGroupParameters(
            string name, ResourceGroupParameters resourceGroup) 
            : base(name, resourceGroup, NoDependencies)
        {
        }

        protected override Task<NetworkSecurityGroup> GetAsync(
            Context context, IGetParameters _)
            => context
                .CreateNetwork()
                .NetworkSecurityGroups
                .GetAsync(ResourceGroup.Name, Name);
    }
}
