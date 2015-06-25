﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class PSNetworkInterfaceIpConfiguration : PSChildResource
    {
        public string PrivateIpAddress { get; set; }

        public string PrivateIpAllocationMethod { get; set; }

        public PSResourceId Subnet { get; set; }

        public PSResourceId PublicIpAddress { get; set; }

        public List<PSResourceId> LoadBalancerBackendAddressPools { get; set; }

        public List<PSResourceId> LoadBalancerInboundNatRules { get; set; }

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
        public string LoadBalancerBackendAddressPoolsText
        {
            get { return JsonConvert.SerializeObject(LoadBalancerBackendAddressPools, Formatting.Indented); }
        }

        [JsonIgnore]
        public string LoadBalancerInboundNatRulesText
        {
            get { return JsonConvert.SerializeObject(LoadBalancerInboundNatRules, Formatting.Indented); }
        }
    }
}
