using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerCrossTenantScopes
    {
        public string TenantId { get; set; }

        public List<string> ManagementGroups { get; set; }

        public List<string> Subscriptions { get; set; }

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
    }
}
