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
    public partial class PSLoadBalancer : PSTopLevelResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
        [Ps1Xml(Label = "Sku Name", Target = ViewControl.Table, ScriptBlock = "$_.Sku.Name")]
        public PSLoadBalancerSku Sku { get; set; }
        public List<PSFrontendIPConfiguration> FrontendIpConfigurations { get; set; }
        public List<PSBackendAddressPool> BackendAddressPools { get; set; }
        public List<PSLoadBalancingRule> LoadBalancingRules { get; set; }
        public List<PSProbe> Probes { get; set; }
        public List<PSInboundNatRule> InboundNatRules { get; set; }
        public List<PSInboundNatPool> InboundNatPools { get; set; }
        public List<PSOutboundRule> OutboundRules { get; set; }
        public PSExtendedLocation ExtendedLocation { get; set; }

        [JsonIgnore]
        public string SkuText
        {
            get { return JsonConvert.SerializeObject(Sku, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

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

        [JsonIgnore]
        public string OutboundRulesText
        {
            get { return JsonConvert.SerializeObject(OutboundRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ExtendedLocationText
        {
            get { return JsonConvert.SerializeObject(ExtendedLocation, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
