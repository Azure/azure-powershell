using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public static class NetworkSecurityGroupPolicy
    {
        public static ResourcePolicy<NetworkSecurityGroup> Policy { get; }
            = NetworkPolicy.Create(
                client => client.NetworkSecurityGroups,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<NetworkSecurityGroup> CreateNetworkSecurityGroupConfig(
            this ResourceName name)
            => Policy.CreateResourceConfig(name, _ => new NetworkSecurityGroup());
    }
}
