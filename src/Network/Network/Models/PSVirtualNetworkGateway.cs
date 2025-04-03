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

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;
    using Microsoft.Azure.Management.Network.Models;

    public class PSVirtualNetworkGateway : PSTopLevelResource
    {
        public List<PSVirtualNetworkGatewayIpConfiguration> IpConfigurations { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string GatewayType { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string VpnType { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool EnableBgp { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool DisableIPsecProtection { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool EnablePrivateIpAddress { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool ActiveActive { get; set; }

        public PSResourceId GatewayDefaultSite { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
        [Ps1Xml(Label = "Sku Name", Target = ViewControl.Table, ScriptBlock = "$_.Sku.Name")]
        public PSVirtualNetworkGatewaySku Sku { get; set; }

        public List<PSVirtualNetworkGatewayPolicyGroup> VirtualNetworkGatewayPolicyGroups { get; set; }

        public PSVpnClientConfiguration VpnClientConfiguration { get; set; }

        public PSBgpSettings BgpSettings { get; set; }

        public PSAddressSpace CustomRoutes { get; set; }

        public string VpnGatewayGeneration { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public PSExtendedLocation ExtendedLocation { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string VNetExtendedLocationResourceId { get; set; }

        public List<PSVirtualNetworkGatewayNatRule> NatRules { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool EnableBgpRouteTranslationForNat { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string AdminState { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
		public string ResiliencyModel { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]										   
        public bool AllowRemoteVnetTraffic { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool AllowVirtualWanTraffic { get; set; }

        [Ps1Xml(Label = "AutoScaleConfiguration", Target = ViewControl.Table)]
        public PSVirtualNetworkGatewayAutoscaleConfiguration AutoScaleConfiguration { get; set; }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ExtendedLocationText
        {
            get { return JsonConvert.SerializeObject(ExtendedLocation, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VNetExtendedLocationResourceIdText
        {
            get { return JsonConvert.SerializeObject(VNetExtendedLocationResourceId, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string GatewayDefaultSiteText
        {
            get { return JsonConvert.SerializeObject(GatewayDefaultSite, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SkuText
        {
            get { return JsonConvert.SerializeObject(Sku, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VpnClientConfigurationText
        {
            get { return JsonConvert.SerializeObject(VpnClientConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BgpSettingsText
        {
            get { return JsonConvert.SerializeObject(BgpSettings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string NatRulesText
        {
            get { return JsonConvert.SerializeObject(NatRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string CustomRoutesText
        {
            get { return JsonConvert.SerializeObject(CustomRoutes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AutoScaleConfigurationText
        {
            get { return JsonConvert.SerializeObject(AutoScaleConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
