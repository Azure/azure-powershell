namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSVpnConnection : PSChildResource
    {
        [Ps1Xml(Label = "Remote VpnSite Id", Target = ViewControl.Table, ScriptBlock = "$_.RemoteVpnSite.Id")]
        public PSResourceId RemoteVpnSite { get; set; }

        public string SharedKey { get; set; }

        [Ps1Xml(Label = "ConnectionStatus", Target = ViewControl.Table)]
        public string ConnectionStatus { get; set; }

        [Ps1Xml(Label = "EgressBytesTransferred", Target = ViewControl.Table)]
        public long? EgressBytesTransferred { get; set; }

        [Ps1Xml(Label = "IngressBytesTransferred", Target = ViewControl.Table)]
        public long? IngressBytesTransferred { get; set; }

        public List<PSIpsecPolicy> IpsecPolicies { get; set; }

        [Ps1Xml(Label = "Connection Bandwidth", Target = ViewControl.Table)]
        public int ConnectionBandwidth { get; set; }

        [Ps1Xml(Label = "BGP Enabled", Target = ViewControl.Table)]
        public bool EnableBgp { get; set; }

        [Ps1Xml(Label = "RateLimiting Enabled", Target = ViewControl.Table)]
        public bool EnableRateLimiting { get; set; }

        [Ps1Xml(Label = "Internet Security Enabled", Target = ViewControl.Table)]
        public bool EnableInternetSecurity { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
    }
}
