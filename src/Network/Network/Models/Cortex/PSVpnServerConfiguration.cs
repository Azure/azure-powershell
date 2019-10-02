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

        public List<PSVpnServerConfigVpnClientRootCertificate> VpnServerConfigVpnClientRootCertificates { get; set; }

        public List<PSVpnServerConfigVpnClientRevokedCertificate> VpnServerConfigVpnClientRevokedCertificates { get; set; }

        public List<PSVpnServerConfigRadiusServerRootCertificate> VpnServerConfigRadiusServerRootCertificates { get; set; }

        public List<PSVpnServerConfigRadiusClientRootCertificate> VpnServerConfigRadiusClientRootCertificates { get; set; }

        public List<PSIpsecPolicy> VpnClientIpsecPolicies { get; set; }

        public string RadiusServerAddress;

        public string RadiusServerSecret;

        public PSAadAuthenticationParameters AadAuthenticationParameters { get; set; }

        [Ps1Xml(Label = "P2SVpnGateway ids", Target = ViewControl.Table)]
        public List<PSResourceId> P2sVpnGateways { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string VpnServerConfigVpnClientRootCertificatesText
        {
            get { return JsonConvert.SerializeObject(VpnServerConfigVpnClientRootCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VpnServerConfigVpnClientRevokedCertificatesText
        {
            get { return JsonConvert.SerializeObject(VpnServerConfigVpnClientRevokedCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VpnServerConfigRadiusServerRootCertificatesText
        {
            get { return JsonConvert.SerializeObject(VpnServerConfigRadiusServerRootCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VpnServerConfigRadiusClientRootCertificatesText
        {
            get { return JsonConvert.SerializeObject(VpnServerConfigRadiusClientRootCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
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
    }
}
