using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSP2SVpnServerConfiguration : PSChildResource
    {
        [Ps1Xml(Label = "VpnProtocols", Target = ViewControl.Table)]
        public List<string> VpnProtocols { get; set; }

        public List<PSP2SVpnServerConfigVpnClientRootCertificate> P2SVpnServerConfigVpnClientRootCertificates { get; set; }

        public List<PSP2SVpnServerConfigVpnClientRevokedCertificate> P2SVpnServerConfigVpnClientRevokedCertificates { get; set; }

        public List<PSIpsecPolicy> VpnClientIpsecPolicies { get; set; }

        public string RadiusServerAddress;

        public string RadiusServerSecret;

        public List<PSP2SVpnServerConfigRadiusServerRootCertificate> P2SVpnServerConfigRadiusServerRootCertificates { get; set; }

        public List<PSP2SVpnServerConfigRadiusClientRootCertificate> P2SVpnServerConfigRadiusClientRootCertificates { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

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
