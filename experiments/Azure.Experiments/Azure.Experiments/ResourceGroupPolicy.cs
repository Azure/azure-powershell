using Microsoft.Azure.Management.ResourceManager.Models;

namespace Azure.Experiments
{
    public struct ResourceGroupPolicy : IInfoPolicy<ResourceGroup>
    {
        public string GetLocation(ResourceGroup value)
            => value.Location;
    }
}
