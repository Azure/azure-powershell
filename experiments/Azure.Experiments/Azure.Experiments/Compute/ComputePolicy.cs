using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Experiments.Compute
{
    public abstract class ComputePolicy<Info, Operations>
        : ResourcePolicy<Info, IComputeManagementClient, Operations>
        where Info : Resource
    {
        public sealed override string GetLocation(Info info)
            => info.Location;

        public sealed override void SetLocation(Info info, string location)
            => info.Location = location;
    }

    /*
    public static class ComputePolicy
    {
        public static ResourcePolicy<Info> Create<Operations, Info>(
            Func<IComputeManagementClient, Operations> getOperations,
            Func<Operations, ResourceName, Task<Info>> getAsync,
            Func<Operations, ResourceName, Info, Task<Info>> createOrUpdateAsync)
            where Info : Management.Compute.Models.Resource
            => OperationsPolicy
                .Create(getAsync, createOrUpdateAsync)
                .Transform(getOperations)
                .CreateResourcePolicy(i => i.Location, (i, location) => i.Location = location);
    }
    */
}
