using Microsoft.Azure.Commands.SignalR.Generated.Models;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    public class PSResourceSku
    {
        public int? Capacity { get; }

        public string Family { get; }

        public string Name { get; }

        public string Size { get; }

        public string Tier { get; }

        public PSResourceSku(ResourceSku resourceSku)
        {
            Capacity = resourceSku.Capacity;
            Family = resourceSku.Family;
            Name = resourceSku.Name;
            Size = resourceSku.Size;
            Tier = resourceSku.Tier;
        }
    }
}
