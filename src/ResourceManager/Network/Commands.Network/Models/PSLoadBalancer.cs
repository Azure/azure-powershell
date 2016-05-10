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
    using System.Collections.Generic;

    public class PSLoadBalancer : PSTopLevelResource
    {
        public List<PSFrontendIPConfiguration> FrontendIpConfigurations { get; set; }

        public List<PSBackendAddressPool> BackendAddressPools { get; set; }

        public List<PSLoadBalancingRule> LoadBalancingRules { get; set; }

        public List<PSProbe> Probes { get; set; }

        public List<PSInboundNatRule> InboundNatRules { get; set; }

        public List<PSInboundNatPool> InboundNatPools { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string FrontendIpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(FrontendIpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BackendAddressPoolsText
        {
            get { return JsonConvert.SerializeObject(BackendAddressPools, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string LoadBalancingRulesText
        {
            get { return JsonConvert.SerializeObject(LoadBalancingRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ProbesText
        {
            get { return JsonConvert.SerializeObject(Probes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string InboundNatRulesText
        {
            get { return JsonConvert.SerializeObject(InboundNatRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string InboundNatPoolsText
        {
            get { return JsonConvert.SerializeObject(InboundNatPools, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
