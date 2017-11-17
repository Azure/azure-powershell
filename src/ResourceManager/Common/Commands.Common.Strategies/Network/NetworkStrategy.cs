using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies.Network
{
    public static class NetworkStrategy
    {
        public static ResourceStrategy<Model> Create<Model, Operations>(
            string header,
            Func<NetworkManagementClient, Operations> getOperations,
            Func<Operations, GetAsyncParams, Task<Model>> getAsync,
            Func<Operations, CreateOrUpdateAsyncParams<Model>, Task<Model>> createOrUpdateAsync)
            where Model : Resource
            => ResourceStrategy.Create(
                new [] { "Microsoft.Network", header },
                getOperations,
                getAsync,
                createOrUpdateAsync, 
                model => model.Location, 
                (model, location) => model.Location = location);
    }
}
