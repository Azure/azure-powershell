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
    public class PSAzureFirewallPolicyApplicationRuleCondition : PSAzureFirewallPolicyRuleCondition
    {

        [JsonProperty(Order = 3)]
        public List<string> SourceAddress { get; set; }

        [JsonProperty(Order = 4)]
        public List<string> TargetFqdn { get; set; }

        [JsonProperty(Order = 5)]
        public List<string> FqdnTag { get; set; }

        [JsonProperty(Order = 6)]
        public List<PSAzureFirewallPolicyApplicationRuleProtocol> Protocol { get; set; }

        [JsonIgnore]
        public string ProtocolsText
        {
            get { return JsonConvert.SerializeObject(Protocol, Formatting.Indented); }
        }

        [JsonIgnore]
        public string SourceAddressesText
        {
            get { return JsonConvert.SerializeObject(SourceAddress, Formatting.Indented); }
        }

        [JsonIgnore]
        public string TargetFqdnsText
        {
            get { return JsonConvert.SerializeObject(TargetFqdn, Formatting.Indented); }
        }

        [JsonIgnore]
        public string FqdnTagsText
        {
            get { return JsonConvert.SerializeObject(FqdnTag, Formatting.Indented); }
        }

        public void AddProtocol(string protocolType, uint port = 0)
        {
            var stringToMap = protocolType + (port == 0 ? string.Empty : ":" + port);

            var protocol = PSAzureFirewallPolicyApplicationRuleProtocol.MapUserInputToApplicationRuleProtocol(stringToMap);

            (this.Protocol ?? (this.Protocol = new List<PSAzureFirewallPolicyApplicationRuleProtocol>())).Add(protocol);
        }
    }
}
