//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSAzureFirewallPolicyApplicationRule : PSAzureFirewallPolicyRule
    {

        [JsonProperty(Order = 3, PropertyName = "sourceAddresses")]
        public List<string> SourceAddresses { get; set; }

        [JsonProperty(Order = 4, PropertyName = "targetFqdns")]
        public List<string> TargetFqdns { get; set; }

        [JsonProperty(Order = 5, PropertyName = "fqdnTags")]
        public List<string> FqdnTags { get; set; }

        [JsonProperty(Order = 6, PropertyName = "protocols")]
        public List<PSAzureFirewallPolicyApplicationRuleProtocol> Protocols { get; set; }

        [JsonProperty(Order = 7, PropertyName = "sourceIpGroups")]
        public List<string> SourceIpGroups { get; set; }

        [JsonProperty(Order = 8, PropertyName = "webCategories")]
        public List<string> WebCategories { get; set; }

        [JsonIgnore]
        public string ProtocolsText
        {
            get { return JsonConvert.SerializeObject(Protocols, Formatting.Indented); }
        }

        [JsonIgnore]
        public string SourceAddressesText
        {
            get { return JsonConvert.SerializeObject(SourceAddresses, Formatting.Indented); }
        }

        [JsonIgnore]
        public string SourceIpGroupsText
        {
            get { return JsonConvert.SerializeObject(SourceIpGroups, Formatting.Indented); }
        }

            [JsonIgnore]
        public string TargetFqdnsText
        {
            get { return JsonConvert.SerializeObject(TargetFqdns, Formatting.Indented); }
        }

        [JsonIgnore]
        public string FqdnTagsText
        {
            get { return JsonConvert.SerializeObject(FqdnTags, Formatting.Indented); }
        }

        [JsonIgnore]
        public string WebCategoriesText
        {
            get { return JsonConvert.SerializeObject(WebCategories, Formatting.Indented); }
        }

        public void AddProtocol(string protocolType, uint port = 0)
        {
            var stringToMap = protocolType + (port == 0 ? string.Empty : ":" + port);

            var protocol = PSAzureFirewallPolicyApplicationRuleProtocol.MapUserInputToApplicationRuleProtocol(stringToMap);

            (this.Protocols ?? (this.Protocols = new List<PSAzureFirewallPolicyApplicationRuleProtocol>())).Add(protocol);
        }
    }
}
