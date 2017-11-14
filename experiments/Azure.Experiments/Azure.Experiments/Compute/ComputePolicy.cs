using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments.Compute
{
    public static class ComputePolicy
    {
        public static ResourcePolicy<Config> Create<Config, Operations>(
            string header,
            Func<IComputeManagementClient, Operations> getOperations,
            Func<GetAsyncParams<Operations>, Task<Config>> getAsync,
            Func<CreateOrUpdateAsyncParams<Operations, Config>, Task<Config>> createOrUpdateAsync)
            where Config : Resource
            => ResourcePolicy.Create(
                new[] { "Microsoft.Compute", header },
                getOperations,
                getAsync,
                createOrUpdateAsync,
                config => config.Location,
                (config, location) => config.Location = location);
    }
}
