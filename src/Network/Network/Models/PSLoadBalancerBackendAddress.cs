// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Management.Network.Models;

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSLoadBalancerBackendAddress : PSChildResource
    {
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public PSResourceId NetworkInterfaceIpConfiguration { get; set; }

        [JsonProperty(Order = 2)]
        public PSResourceId VirtualNetwork { get; set; }

        [JsonProperty(Order = 3)]
        public PSResourceId Subnet { get; set; }

        [JsonProperty(Order = 4)]
        public string IpAddress { get; set; }

        [JsonProperty(Order = 5)]
        public PSResourceId LoadBalancerFrontendIPConfiguration { get; set; }

        [JsonProperty(Order = 6)]
        public List<PSNatRulePortMapping> InboundNatRulesPortMapping { get; set; }

        [JsonProperty(Order = 7)]
        public string AdminState { get; set; }

        [JsonIgnore]
        public string NetworkInterfaceIpConfigurationIdText
        {
            get { return JsonConvert.SerializeObject(NetworkInterfaceIpConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string LoadBalancerFrontendIPConfigurationIdText
        {
            get { return JsonConvert.SerializeObject(LoadBalancerFrontendIPConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VirtualNetworkIdText
        {
            get
            {
                return JsonConvert.SerializeObject(VirtualNetwork, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
        }

        [JsonIgnore]
        public string SubnetIdText
        {
            get
            {
                return JsonConvert.SerializeObject(Subnet, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
        }

        [JsonIgnore]
        public string InboundNatRulesPortMappingText
        {
            get
            {
                return JsonConvert.SerializeObject(InboundNatRulesPortMapping, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}
