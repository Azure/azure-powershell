using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerScopes
    {
        public List<string> ManagementGroups { get; set; }

        public List<string> Subscriptions { get; set; }

        [JsonProperty(Order = 1)]
        public IList<PSNetworkManagerCrossTenantScopes> CrossTenantScopes { get; set; }

        [JsonIgnore]
        public string ManagementGroupsText
        {
            get { return JsonConvert.SerializeObject(ManagementGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SubscriptionsText
        {
            get { return JsonConvert.SerializeObject(Subscriptions, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string CrossTenantScopesText
        {
            get { return JsonConvert.SerializeObject(CrossTenantScopes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
