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
    public class PSAzureFirewallApplicationRule
    {
        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        [JsonProperty(Order = 2)]
        public string Description { get; set; }

        [JsonProperty(Order = 3)]
        public List<string> SourceAddresses { get; set; }

        [JsonProperty(Order = 4)]
        public List<string> TargetFqdns { get; set; }

        [JsonProperty(Order = 5)]
        public List<string> FqdnTags { get; set; }

        [JsonProperty(Order = 6)]
        public List<PSAzureFirewallApplicationRuleProtocol> Protocols { get; set; }

        [JsonProperty(Order = 7)]
        public List<string> SourceIpGroups { get; set; }

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

        public void AddProtocol(string protocolType, uint port = 0)
        {
            var stringToMap = protocolType + (port == 0 ? string.Empty : ":" + port);

            var protocol = PSAzureFirewallApplicationRuleProtocol.MapUserInputToApplicationRuleProtocol(stringToMap);

            (this.Protocols ?? (this.Protocols = new List<PSAzureFirewallApplicationRuleProtocol>())).Add(protocol);
        }
    }
}
