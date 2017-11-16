using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.Common.Strategies.Network
{
    public static class NetworkSecurityGroupStrategy
    {
        public static ResourceStrategy<NetworkSecurityGroup> Strategy { get; }
            = NetworkStrategy.Create(
                "networkSecurityGroups",
                client => client.NetworkSecurityGroups,
                p => p.Operations.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                p => p.Operations.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken));

        public static ResourceConfig<NetworkSecurityGroup> CreateNetworkSecurityGroupConfig(
            this ResourceConfig<ResourceGroup> resourceGroup, string name)
            => Strategy.CreateConfig(resourceGroup, name);
    }
}
