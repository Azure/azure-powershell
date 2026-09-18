using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerEffectiveBaseSecurityAdminRule
    {
        public string Id { get; set; }

        public string ConfigurationDisplayName { get; set; }

        public string ConfigurationDescription { get; set; }

        public string RuleCollectionDisplayName { get; set; }

        public string RuleCollectionDescription { get; set; }

        public List<string> ApplyOnNetworkIntentPolicyBasedServices { get; set; }

        public string NetworkGroupAddressSpaceAggregationOption { get; set; }

        public IList<PSNetworkManagerSecurityGroupItem> RuleCollectionAppliesToGroups { get; set; }

        public IList<PSNetworkManagerConfigurationGroup> RuleGroups { get; set; }

        [JsonIgnore]
        public string RuleCollectionAppliesToGroupsText
        {
            get { return JsonConvert.SerializeObject(RuleCollectionAppliesToGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RuleGroupsText
        {
            get { return JsonConvert.SerializeObject(RuleGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ApplyOnNetworkIntentPolicyBasedServicesText
        {
            get { return JsonConvert.SerializeObject(ApplyOnNetworkIntentPolicyBasedServices, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
