using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
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
            where Info : Resource
            => OperationsPolicy
                .Create(getAsync, createOrUpdateAsync)
                .Transform(getOperations)
                .CreateResourcePolicy(i => i.Location, (i, location) => i.Location = location);

        public static ResourcePolicy<ResourceName, NetworkInterface> NetworkInterface { get; }
            = Create(
                client => client.NetworkInterfaces,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info) 
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourcePolicy<ResourceName, NetworkSecurityGroup> NetworkSecurityGroup { get; }
            = Create(
                client => client.NetworkSecurityGroups,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourcePolicy<ResourceName, PublicIPAddress> PublicIPAddresss { get; }
            = Create(
                client => client.PublicIPAddresses,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourcePolicy<ResourceName, VirtualNetwork> VirtualNetwork { get; }
            = Create(
                client => client.VirtualNetworks,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));
    }
}
