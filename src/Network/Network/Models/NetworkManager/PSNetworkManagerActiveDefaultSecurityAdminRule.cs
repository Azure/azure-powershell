using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerActiveDefaultSecurityAdminRule : PSNetworkManagerActiveBaseSecurityAdminRule
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string Flag { get; set; }

        public string Protocol { get; set; }

        public IList<PSNetworkManagerAddressPrefixItem> Sources { get; set; }

        public IList<PSNetworkManagerAddressPrefixItem> Destinations { get; set; }

        public IList<string> SourcePortRanges { get; set; }

        public IList<string> DestinationPortRanges { get; set; }

        public string Access { get; set; }

        public int Priority { get; set; }

        public string Direction { get; set; }

        public string ProvisioningState { get; private set; }

        [JsonIgnore]
        public string SourcesText
        {
            get { return JsonConvert.SerializeObject(Sources, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DestinationsText
        {
            get { return JsonConvert.SerializeObject(Destinations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SourcePortRangesText
        {
            get { return JsonConvert.SerializeObject(SourcePortRanges, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DestinationPortRangesText
        {
            get { return JsonConvert.SerializeObject(DestinationPortRanges, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
