using System.Threading.Tasks;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class NetworkSecurityGroupPolicy
        : NetworkPolicy<NetworkSecurityGroup, INetworkSecurityGroupsOperations>
    {
        public override Task<NetworkSecurityGroup> CreateOrUpdateAsync(CreateParams p)
            => p.Operations.CreateOrUpdateAsync(
                p.ResourceGroupName, p.Name, p.Info, p.CancellationToken);

        public override Task<NetworkSecurityGroup> GetAsync(GetParams p)
             => p.Operations.GetAsync(
                 p.ResourceGroupName, p.Name, cancellationToken: p.CancellationToken);

        public override INetworkSecurityGroupsOperations GetOperations(
            INetworkManagementClient client)
            => client.NetworkSecurityGroups;
    }

    /*
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
            => Policy.CreateConfig(name, _ => new NetworkSecurityGroup());
    }
    */
}
