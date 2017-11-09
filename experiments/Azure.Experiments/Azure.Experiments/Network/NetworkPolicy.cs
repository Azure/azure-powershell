using Microsoft.Azure.Management.Network;
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
    }
}
