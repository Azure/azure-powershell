using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerEffectiveConnectivityConfiguration
    {
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string ConnectivityTopology { get; set; }

        public IList<PSNetworkManagerHub> Hubs { get; set; }

        public string IsGlobal { get; set; }

        public IList<PSNetworkManagerConnectivityGroupItem> AppliesToGroups { get; set; }

        public string ProvisioningState { get; private set; }

        public string DeleteExistingPeering { get; set; }

        public IList<PSNetworkManagerConfigurationGroup> ConfigurationGroups { get; set; }

        [JsonIgnore]
        public string AppliesToGroupsText
        {
            get { return JsonConvert.SerializeObject(AppliesToGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string HubsText
        {
            get { return JsonConvert.SerializeObject(Hubs, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ConfigurationGroupsText
        {
            get { return JsonConvert.SerializeObject(ConfigurationGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
