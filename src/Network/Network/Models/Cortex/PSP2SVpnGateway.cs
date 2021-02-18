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
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    public class PSP2SVpnGateway : PSTopLevelResource
    {
        public List<PSP2SConnectionConfiguration> P2SConnectionConfigurations { get; set; }

        [Ps1Xml(Label = "Virtual Hub", Target = ViewControl.Table, ScriptBlock = "$_.VirtualHub.Id")]
        public PSResourceId VirtualHub { get; set; }

        [Ps1Xml(Label = "Vpn server configuration", Target = ViewControl.Table, ScriptBlock = "$_.VpnServerConfiguration.Id")]
        public PSResourceId VpnServerConfiguration { get; set; }

        [Ps1Xml(Label = "VpnServerConfiguration location", Target = ViewControl.Table)]
        public string VpnServerConfigurationLocation { get; set; }

        [Ps1Xml(Label = "Scale Unit", Target = ViewControl.Table)]
        public int VpnGatewayScaleUnit { get; set; }

        public PSVpnClientConnectionHealth VpnClientConnectionHealth { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        public List<string> CustomDnsServers { get; set; }

        [Ps1Xml(Label = "Enable RoutingPreferenceInternet", Target = ViewControl.Table)]
        public bool? IsRoutingPreferenceInternet { get; set; }

        [JsonIgnore]
        public string VpnClientConnectionHealthText
        {
            get { return JsonConvert.SerializeObject(VpnClientConnectionHealth, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string P2SConnectionConfigurationsText
        {
            get { return JsonConvert.SerializeObject(P2SConnectionConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string CustomDnsServersText
        {
            get { return JsonConvert.SerializeObject(CustomDnsServers, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}