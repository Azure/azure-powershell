using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSP2SVpnServerConfiguration : PSChildResource
    {
        public List<string> VpnProtocols { get; set; }

        [Ps1Xml(Label = "VpnClientRootCertificates", Target = ViewControl.Table)]
        public List<PSP2SVpnServerConfigVpnClientRootCertificate> P2SVpnServerConfigVpnClientRootCertificates { get; set; }

        [Ps1Xml(Label = "VpnClientRevokedCertificates", Target = ViewControl.Table)]
        public List<PSP2SVpnServerConfigVpnClientRevokedCertificate> P2SVpnServerConfigVpnClientRevokedCertificates { get; set; }

        [Ps1Xml(Label = "VpnClientIpsecPolicies", Target = ViewControl.Table)]
        public List<PSIpsecPolicy> VpnClientIpsecPolicies { get; set; }

        [Ps1Xml(Label = "RadiusServerAddress", Target = ViewControl.Table)]
        public string RadiusServerAddress;

        [Ps1Xml(Label = "RadiusServerSecret", Target = ViewControl.Table)]
        public string RadiusServerSecret;

        [Ps1Xml(Label = "RadiusServerRootCertificates", Target = ViewControl.Table)]
        public List<PSP2SVpnServerConfigRadiusServerRootCertificate> P2SVpnServerConfigRadiusServerRootCertificates { get; set; }

        [Ps1Xml(Label = "RadiusClientRootCertificates", Target = ViewControl.Table)]
        public List<PSP2SVpnServerConfigRadiusClientRootCertificate> P2SVpnServerConfigRadiusClientRootCertificates { get; set; }

        [Ps1Xml(Label = "ProvisioningState", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string VpnProtocolsText
        {
            get { return JsonConvert.SerializeObject(VpnProtocols, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VpnClientRootCertificatesText
        {
            get { return JsonConvert.SerializeObject(P2SVpnServerConfigVpnClientRootCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VpnClientRevokedCertificatesText
        {
            get { return JsonConvert.SerializeObject(P2SVpnServerConfigVpnClientRevokedCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RadiusServerRootCertificatesText
        {
            get { return JsonConvert.SerializeObject(P2SVpnServerConfigRadiusServerRootCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RadiusClientRootCertificatesText
        {
            get { return JsonConvert.SerializeObject(P2SVpnServerConfigRadiusClientRootCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VpnClientIpsecPoliciesText
        {
            get { return JsonConvert.SerializeObject(VpnClientIpsecPolicies, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
