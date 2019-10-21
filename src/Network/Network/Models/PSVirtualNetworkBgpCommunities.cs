using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVirtualNetworkBgpCommunities
    {
        public string VirtualNetworkCommunity { get; set; }

        public string RegionalCommunity { get; set; }

        public bool ShouldSerializeRegionalCommunity()
        {
            return !string.IsNullOrWhiteSpace(this.RegionalCommunity);
        }
    }
}
