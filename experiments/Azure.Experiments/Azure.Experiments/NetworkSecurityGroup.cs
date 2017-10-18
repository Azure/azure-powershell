using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    public sealed class NetworkSecurityGroupObject
        : ResourceObject<NetworkSecurityGroup, INetworkSecurityGroupsOperations>
    {
        public NetworkSecurityGroupObject(
            INetworkManagementClient client,
            string name,
            ResourceGroupObject rg)
            : base(name, rg)
        {
            Client = client.NetworkSecurityGroups;
        }

        protected override Task<NetworkSecurityGroup> CreateAsync(
            INetworkSecurityGroupsOperations c)
            => c.CreateOrUpdateAsync(
                ResourceGroupName,
                Name,
                new NetworkSecurityGroup { Location = "eastus" });

        protected override INetworkSecurityGroupsOperations CreateClient(
            Context c)
            => c.CreateNetwork().NetworkSecurityGroups;

        protected override Task<NetworkSecurityGroup> GetOrThrowAsync(
            INetworkSecurityGroupsOperations c)
            => c.GetAsync(ResourceGroupName, Name);

        private INetworkSecurityGroupsOperations Client { get; }
    }
}
