using System.Collections.Generic;
using Microsoft.Azure.Management.Network.Models;

namespace Azure.Experiments.Network
{
    public abstract class NetworkObject<T> : ResourceObject<T, NetworkPolicy<T>>
        where T : Resource
    {
        protected NetworkObject(ResourceGroupObject rg)
            : base(rg)
        {
        }

        protected NetworkObject(
            ResourceGroupObject rg,
            IEnumerable<AzureObject> dependencies) : base(rg, dependencies)
        {
        }
    }
}
