using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies.Compute
{
    public static class ComputePolicy
    {
        public static ResourceStrategy<Model> Create<Model, Operations>(
            string header,
            Func<ComputeManagementClient, Operations> getOperations,
            Func<Operations, GetAsyncParams, Task<Model>> getAsync,
            Func<Operations, CreateOrUpdateAsyncParams<Model>, Task<Model>> createOrUpdateAsync)
            where Model : Resource
            => ResourceStrategy.Create(
                new[] { "Microsoft.Compute", header },
                getOperations,
                getAsync,
                createOrUpdateAsync,
                config => config.Location,
                (config, location) => config.Location = location);
    }
}
