using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies.Compute
{
    public static class ComputePolicy
    {
        public static ResourceStrategy<TModel> Create<TModel, TOperations>(
            string header,
            Func<ComputeManagementClient, TOperations> getOperations,
            Func<TOperations, GetAsyncParams, Task<TModel>> getAsync,
            Func<TOperations, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> createOrUpdateAsync)
            where TModel : Resource
            => ResourceStrategy.Create(
                new[] { "Microsoft.Compute", header },
                getOperations,
                getAsync,
                createOrUpdateAsync,
                config => config.Location,
                (config, location) => config.Location = location);
    }
}
