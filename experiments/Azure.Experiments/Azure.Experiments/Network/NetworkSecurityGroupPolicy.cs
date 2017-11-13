using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public static class NetworkSecurityGroupPolicy
    {
        public static ResourcePolicy<NetworkSecurityGroup> Policy { get; }
            = NetworkPolicy.Create(
                client => client.NetworkSecurityGroups,
                p => p.Operations.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                p => p.Operations.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Config, p.CancellationToken));

        public static ResourceConfig<NetworkSecurityGroup> CreateNetworkSecurityGroupConfig(
            this ResourceConfig<ResourceGroup> resourceGroup, string name)
            => Policy.CreateConfig(resourceGroup, name);
    }
}
