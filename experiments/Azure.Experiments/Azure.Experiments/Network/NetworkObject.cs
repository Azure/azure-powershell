using System.Collections.Generic;
using Microsoft.Azure.Management.Network.Models;

namespace Azure.Experiments.Network
{
    public abstract class NetworkObject<T> : ResourceObject<T, NetworkPolicy<T>>
        where T : Resource
    {
        protected NetworkObject(string name, ResourceGroupObject rg) : base(name, rg)
        {
        }

        protected NetworkObject(
            string name,
            ResourceGroupObject rg,
            IEnumerable<AzureObject> dependencies) : base(name, rg, dependencies)
        {
        }
    }
}
