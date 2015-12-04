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
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class PSFrontendIPConfiguration : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string PrivateIpAddress { get; set; }

        [JsonProperty(Order = 1)]
        public string PrivateIpAllocationMethod { get; set; }

        [JsonProperty(Order = 1)]
        public PSResourceId Subnet { get; set; }

        [JsonProperty(Order = 1)]
        public PSResourceId PublicIpAddress { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSResourceId> InboundNatRules { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSResourceId> LoadBalancingRules { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSResourceId> InboundNatPools { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string SubnetText
        {
            get { return JsonConvert.SerializeObject(Subnet, Formatting.Indented); }
        }

        [JsonIgnore]
        public string PublicIpAddressText
        {
            get { return JsonConvert.SerializeObject(PublicIpAddress, Formatting.Indented); }
        }

        [JsonIgnore]
        public string InboundNatRulesText
        {
            get { return JsonConvert.SerializeObject(InboundNatRules, Formatting.Indented); }
        }

        [JsonIgnore]
        public string LoadBalancingRulesText
        {
            get { return JsonConvert.SerializeObject(LoadBalancingRules, Formatting.Indented); }
        }

        [JsonIgnore]
        public string InboundNatPoolsText
        {
            get { return JsonConvert.SerializeObject(InboundNatPools, Formatting.Indented); }
        }

    }
}
