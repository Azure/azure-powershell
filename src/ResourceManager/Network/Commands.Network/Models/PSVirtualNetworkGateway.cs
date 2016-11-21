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

    public class PSVirtualNetworkGateway : PSTopLevelResource
    {
        public List<PSVirtualNetworkGatewayIpConfiguration> IpConfigurations { get; set; }

        public string GatewayType { get; set; }

        public string VpnType { get; set; }

        public bool EnableBgp { get; set; }

        public bool ActiveActive { get; set; }

        public PSResourceId GatewayDefaultSite { get; set; }

        public string ProvisioningState { get; set; }
        public PSVirtualNetworkGatewaySku Sku { get; set; }

        public PSVpnClientConfiguration VpnClientConfiguration { get; set; }

        public PSBgpSettings BgpSettings { get; set; }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
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
    }
}
