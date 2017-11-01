using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public abstract class NetworkParameters<T> : ResourceParameters<T>
        where T : Resource
    {
        public sealed override string GetLocation(T value)
            => value.Location;
    }
}
