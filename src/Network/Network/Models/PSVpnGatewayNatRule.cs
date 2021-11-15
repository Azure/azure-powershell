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

    public class PSVpnGatewayNatRule : PSChildResource
    {
        [Ps1Xml(Label = "VpnGatewayNatRuleType", Target = ViewControl.Table)]
        public string VpnGatewayNatRulePropertiesType { get; set; }

        [Ps1Xml(Label = "Mode", Target = ViewControl.Table)]
        public string Mode { get; set; }

        public List<PSVpnNatRuleMapping> InternalMappings { get; set; }

        public List<PSVpnNatRuleMapping> ExternalMappings { get; set; }

        [Ps1Xml(Label = "IpConfigurationId", Target = ViewControl.Table)]
        public string IpConfigurationId { get; set; }

        [Ps1Xml(Label = "IngressVpnSiteLinkConnections", Target = ViewControl.Table)]
        public List<PSResourceId> IngressVpnSiteLinkConnections { get; set; }

        [Ps1Xml(Label = "EgressVpnSiteLinkConnections", Target = ViewControl.Table)]
        public List<PSResourceId> EgressVpnSiteLinkConnections { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string InternalMappingsText
        {
            get { return JsonConvert.SerializeObject(InternalMappings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ExternalMappingsText
        {
            get { return JsonConvert.SerializeObject(ExternalMappings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IngressVpnSiteLinkConnectionsText
        {
            get { return JsonConvert.SerializeObject(IngressVpnSiteLinkConnections, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string EgressVpnSiteLinkConnectionsText
        {
            get { return JsonConvert.SerializeObject(EgressVpnSiteLinkConnections, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
