using Microsoft.Azure.Experiments.ResourceManager;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments.Network
{
    public static class NetworkPolicy
    {
        public static ResourcePolicy<ResourceName, Info> Create<Operations, Info>(
            Func<INetworkManagementClient, Operations> getOperations,
            Func<Operations, ResourceName, Task<Info>> getAsync,
            Func<Operations, ResourceName, Info, Task<Info>> createOrUpdateAsync)
            where Info : Management.Network.Models.Resource
            => OperationsPolicy
                .Create(getAsync, createOrUpdateAsync)
                .Transform(getOperations)
                .CreateResourcePolicy(i => i.Location, (i, location) => i.Location = location);

        public static ResourcePolicy<ResourceName, NetworkSecurityGroup> NetworkSecurityGroup { get; }
            = Create(
                client => client.NetworkSecurityGroups,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<ResourceName, NetworkSecurityGroup> CreateNetworkSecurityGroupConfig(
            this ResourceConfig<string, ResourceGroup> resourceGroup,
            string name)
            => resourceGroup.CreateResourceConfig(NetworkSecurityGroup, name, new NetworkSecurityGroup());

        public static ResourcePolicy<ResourceName, PublicIPAddress> PublicIPAddress { get; }
            = Create(
                client => client.PublicIPAddresses,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<ResourceName, PublicIPAddress> CreatePublicIPAddressConfig(
            this ResourceConfig<string, ResourceGroup> resourceGroup,
            string name)
            => resourceGroup.CreateResourceConfig(PublicIPAddress, name, new PublicIPAddress());

        public static ResourcePolicy<ResourceName, VirtualNetwork> VirtualNetwork { get; }
            = Create(
                client => client.VirtualNetworks,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<ResourceName, VirtualNetwork> CreateVirtualNetworkConfig(
            this ResourceConfig<string, ResourceGroup> resourceGroup,
            string name)
            => resourceGroup.CreateResourceConfig(VirtualNetwork, name, new VirtualNetwork());

        public static ResourcePolicy<ResourceName, NetworkInterface> NetworkInterface { get; }
            = Create(
                client => client.NetworkInterfaces,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<ResourceName, NetworkInterface> CreateNetworkInterfaceConfig(
            this ResourceConfig<string, ResourceGroup> resourceGroup,
            string name,
            ResourceConfig<ResourceName, VirtualNetwork> virtualNetwork,
            ResourceConfig<ResourceName, NetworkSecurityGroup> networkSecurityGroup,
            ResourceConfig<ResourceName, PublicIPAddress> publicIPAddress)
            => resourceGroup.CreateResourceConfig(
                NetworkInterface,
                name,
                new NetworkInterface(),
                new IResourceConfig[] { virtualNetwork, networkSecurityGroup, publicIPAddress });
    }
}
