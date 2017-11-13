using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments.Network
{
    public static class NetworkPolicy
    {
        public static ResourcePolicy<Config> Create<Config, Operations>(
            Func<INetworkManagementClient, Operations> getOperations,
            Func<GetAsyncParams<Operations>, Task<Config>> getAsync,
            Func<CreateOrUpdateAsyncParams<Operations, Config>, Task<Config>> createOrUpdateAsync)
            where Config : Resource
            => ResourcePolicy.Create(
                getOperations,
                getAsync,
                createOrUpdateAsync, 
                config => config.Location, 
                (config, location) => config.Location = location);
    }
}
