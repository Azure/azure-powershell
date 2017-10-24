using Microsoft.Azure.Management.Network.Models;

namespace Azure.Experiments.Network
{
    public struct NetworkPolicy<T> : IInfoPolicy<T>
        where T : Resource
    {
        public string GetLocation(T value)
            => value.Location;
    }
}
