using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Threading.Tasks;

namespace Azure.Experiments.Network
{
    public sealed class NetworkSecurityGroupObject
        : NetworkObject<NetworkSecurityGroup>
    {
        public NetworkSecurityGroupObject(
            INetworkManagementClient client,
            string name,
            ResourceGroupObject rg)
            : base(name, rg)
        {
            Client = client.NetworkSecurityGroups;
        }

        protected override Task<NetworkSecurityGroup> CreateAsync(string location)
            => Client.CreateOrUpdateAsync(
                ResourceGroupName,
                Name,
                new NetworkSecurityGroup { Location = location });

        protected override Task<NetworkSecurityGroup> GetOrThrowAsync()
            => Client.GetAsync(ResourceGroupName, Name);

        private INetworkSecurityGroupsOperations Client { get; }
    }
}
