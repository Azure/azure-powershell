using Microsoft.Azure.Management.Compute.Models;

namespace Azure.Experiments.Compute
{
    public struct ComputePolicy<T> : IInfoPolicy<T>
        where T : Resource
    {
        public string GetLocation(T value) 
            => value.Location;
    }
}
