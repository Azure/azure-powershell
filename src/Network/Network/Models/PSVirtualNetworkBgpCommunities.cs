using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVirtualNetworkBgpCommunities
    {
        public string VirtualNetworkCommunity { get; set; }

        public string RegionalCommunity { get; set; }

        public string VirtualNetworkCommunityText
        {
            get { return JsonConvert.SerializeObject(VirtualNetworkCommunity, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public string RegionalCommunityText
        {
            get { return JsonConvert.SerializeObject(RegionalCommunity, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
