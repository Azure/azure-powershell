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

        public List<string> sourceAddresses { get; set; }

        public List<string> destinationAddresses { get; set; }
        
        public List<string> destinationPorts { get; set; }

        [JsonIgnore]
        public string ProtocolsText
        {
            get { return JsonConvert.SerializeObject(protocols, Formatting.Indented); }
        }

        [JsonIgnore]
        public string SourceAddressesText
        {
            get { return JsonConvert.SerializeObject(sourceAddresses, Formatting.Indented); }
        }

        [JsonIgnore]
        public string DestinationAddressesText
        {
            get { return JsonConvert.SerializeObject(destinationAddresses, Formatting.Indented); }
        }
        
        [JsonIgnore]
        public string DestinationPortsText
        {
            get { return JsonConvert.SerializeObject(destinationPorts, Formatting.Indented); }
        }

        public void AddProtocol(string protocolType)
        {
            (protocols ?? (protocols = new List<string>())).Add(AzureFirewallNetworkRuleProtocolHelper.MapUserInputToNetworkRuleProtocol(protocolType));
        }
    }
}
