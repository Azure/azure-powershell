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

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;

    public class PSPeering : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string PeeringType { get; set; }

        [JsonProperty(Order = 1)]
        public string State { get; set; }

        [JsonProperty(Order = 1)]
        public string PeerASN { get; set; }

        [JsonProperty(Order = 1)]
        public string PrimaryPeerSubnet { get; set; }

        [JsonProperty(Order = 1)]
        public string SecondaryPeerSubnet { get; set; }

        [JsonProperty(Order = 1)]
        public string PrimaryAzurePort { get; set; }

        [JsonProperty(Order = 1)]
        public string SecondaryAzurePort { get; set; }

        [JsonProperty(Order = 1)]
        public string SharedKey { get; set; }

        [JsonProperty(Order = 1)]
        public string VlanId { get; set; }

        [JsonProperty(Order = 1)]
        public PSPeeringConfig MicrosoftPeeringConfig { get; set; }

        [JsonProperty(Order = 1)]
        public PSPeeringStats Stats { get; set; }

        [JsonProperty(Order = 1)]
        public string AuthorizationKey { get; set; }

        [JsonProperty(Order = 1)]
        public string AuthorizationUseStatus { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string MicrosoftPeeringConfigText
        {
            get { return JsonConvert.SerializeObject(MicrosoftPeeringConfig, Formatting.Indented); }
        }

        [JsonIgnore]
        public string StatsText
        {
            get { return JsonConvert.SerializeObject(Stats, Formatting.Indented); }
        }
    }
}
