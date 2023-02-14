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
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSVpnServerConfiguration : PSTopLevelResource
    {
        [Ps1Xml(Label = "VpnProtocols", Target = ViewControl.Table)]
        public List<string> VpnProtocols { get; set; }

        [Ps1Xml(Label = "VpnAuthenticationTypes", Target = ViewControl.Table)]
        public List<string> VpnAuthenticationTypes { get; set; }

        public List<PSClientRootCertificate> VpnClientRootCertificates { get; set; }

        public List<PSClientCertificate> VpnClientRevokedCertificates { get; set; }

        public List<PSClientRootCertificate> RadiusServerRootCertificates { get; set; }

        public List<PSClientCertificate> RadiusClientRootCertificates { get; set; }

        public List<PSIpsecPolicy> VpnClientIpsecPolicies { get; set; }

        [Ps1Xml(Label = "Radius server address", Target = ViewControl.Table)]
        public string RadiusServerAddress { get; set; }

        public string RadiusServerSecret { get; set; }

        public List<PSRadiusServer> RadiusServers { get; set; }

        public PSAadAuthenticationParameters AadAuthenticationParameters { get; set; }

        [Ps1Xml(Label = "P2SVpnGateway ids", Target = ViewControl.Table)]
        public List<PSResourceId> P2SVpnGateways { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        public List<PSVpnServerConfigurationPolicyGroup> ConfigurationPolicyGroups { get; set; }

        [JsonIgnore]
        public string VpnClientRootCertificatesText
        {
            get { return JsonConvert.SerializeObject(VpnClientRootCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VpnClientRevokedCertificatesText
        {
            get { return JsonConvert.SerializeObject(VpnClientRevokedCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RadiusServersText
        {
            get { return JsonConvert.SerializeObject(RadiusServers, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RadiusServerRootCertificatesText
        {
            get { return JsonConvert.SerializeObject(RadiusServerRootCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RadiusClientRootCertificatesText
        {
            get { return JsonConvert.SerializeObject(RadiusClientRootCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VpnClientIpsecPoliciesText
        {
            get { return JsonConvert.SerializeObject(VpnClientIpsecPolicies, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AadAuthenticationParametersText
        {
            get { return JsonConvert.SerializeObject(AadAuthenticationParameters, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string P2SVpnGatewaysText
        {
            get { return JsonConvert.SerializeObject(P2SVpnGateways, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ConfigurationPolicyGroupsText
        {
            get { return JsonConvert.SerializeObject(ConfigurationPolicyGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
