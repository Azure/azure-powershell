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
    public class PSAzureFirewallPolicyNetworkRule : PSAzureFirewallPolicyRule
    {
        [JsonProperty("ipProtocols")]
        public List<string> protocols { get; set; }

        [JsonProperty("sourceAddresses")]
        public List<string> SourceAddresses { get; set; }

        [JsonProperty("destinationAddresses")]
        public List<string> DestinationAddresses { get; set; }

        [JsonProperty("sourceIpGroups")]
        public List<string> SourceIpGroups { get; set; }

        [JsonProperty("destinationIpGroups")]
        public List<string> DestinationIpGroups { get; set; }

        [JsonProperty("destinationPorts")]
        public List<string> DestinationPorts { get; set; }

        [JsonProperty("destinationFqdns")]
        public List<string> DestinationFqdns { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonIgnore]
        public string ProtocolsText
        {
            get { return JsonConvert.SerializeObject(protocols, Formatting.Indented); }
        }

        [JsonIgnore]
        public string SourceAddressesText
        {
            get { return JsonConvert.SerializeObject(SourceAddresses, Formatting.Indented); }
        }

        [JsonIgnore]
        public string DestinationAddressesText
        {
            get { return JsonConvert.SerializeObject(DestinationAddresses, Formatting.Indented); }
        }

        [JsonIgnore]
        public string SourceIpGroupsText
        {
            get { return JsonConvert.SerializeObject(SourceIpGroups, Formatting.Indented); }
        }

        [JsonIgnore]
        public string DestinationIpGroupsText
        {
            get { return JsonConvert.SerializeObject(DestinationIpGroups, Formatting.Indented); }
        }

        [JsonIgnore]
        public string DestinationPortsText
        {
            get { return JsonConvert.SerializeObject(DestinationPorts, Formatting.Indented); }
        }

        [JsonIgnore]
        public string DestinationFqdnsText
        {
            get { return JsonConvert.SerializeObject(DestinationFqdns, Formatting.Indented); }
        }

        public void AddProtocol(string protocolType)
        {
            (protocols ?? (protocols = new List<string>())).Add(AzureFirewallNetworkRuleProtocolHelper.MapUserInputToNetworkRuleProtocol(protocolType));
        }
    }
}
