using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    public sealed class NetworkSecurityGroupObject
        : ResourceObject<NetworkSecurityGroup>
    {
        public NetworkSecurityGroupObject(
            INetworkManagementClient client,
            string name,
            ResourceGroupObject rg)
            : base(name, rg)
        {
            Client = client.NetworkSecurityGroups;
        }

        protected override Task<NetworkSecurityGroup> CreateAsync()
            => Client.CreateOrUpdateAsync(
                ResourceGroupName,
                Name,
                new NetworkSecurityGroup { Location = "eastus" });

        protected override Task<NetworkSecurityGroup> GetOrThrowAsync()
            => Client.GetAsync(ResourceGroupName, Name);

        private INetworkSecurityGroupsOperations Client { get; }
    }
}
