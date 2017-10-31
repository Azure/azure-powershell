using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments.Network
{
    public abstract class NetworkParameters<T> : ResourceParameters<T>
        where T : Resource
    {
        public NetworkParameters(
            string name,
            ResourceGroupParameters resourceGroup,
            IEnumerable<Parameters> dependencies) 
            : base(name, resourceGroup, dependencies)
        {
        }

        public sealed override string GetLocation(T value)
            => value.Location;
    }
}
