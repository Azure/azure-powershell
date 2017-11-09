using Microsoft.Azure.Experiments.ResourceManager;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public static class NetworkSecurityGroupPolicy
    {
        public static ResourcePolicy<ResourceName, NetworkSecurityGroup> Policy { get; }
            = NetworkPolicy.Create(
                client => client.NetworkSecurityGroups,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<ResourceName, NetworkSecurityGroup> CreateNetworkSecurityGroupConfig(
            this ResourceConfig<string, ResourceGroup> resourceGroup,
            string name)
            => resourceGroup.CreateResourceConfig(Policy, name, new NetworkSecurityGroup());
    }
}
