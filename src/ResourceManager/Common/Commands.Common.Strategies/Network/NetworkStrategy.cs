using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies.Network
{
    public static class NetworkStrategy
    {
        public static ResourceStrategy<TModel> Create<TModel, TOperations>(
            string type,
            string header,
            Func<NetworkManagementClient, TOperations> getOperations,
            Func<TOperations, GetAsyncParams, Task<TModel>> getAsync,
            Func<TOperations, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> createOrUpdateAsync)
            where TModel : Resource
            => ResourceStrategy.Create(
                type,
                new [] { "Microsoft.Network", header },
                getOperations,
                getAsync,
                createOrUpdateAsync, 
                model => model.Location, 
                (model, location) => model.Location = location);
    }
}
