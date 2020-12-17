namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    public class PSVpnSiteLinkConnection : PSChildResource
    {
        [Ps1Xml(Label = "Vpn Site Link", Target = ViewControl.Table, ScriptBlock = "$_.VpnSiteLink.Id")]
        public PSResourceId VpnSiteLink { get; set; }

        public string SharedKey { get; set; }

        [Ps1Xml(Label = "VpnConnectionProtocolType", Target = ViewControl.Table)]
        public string VpnConnectionProtocolType { get; set; }

        [Ps1Xml(Label = "ConnectionStatus", Target = ViewControl.Table)]
        public string ConnectionStatus { get; set; }

        [Ps1Xml(Label = "EgressBytesTransferred", Target = ViewControl.Table)]
        public long? EgressBytesTransferred { get; set; }

        [Ps1Xml(Label = "IngressBytesTransferred", Target = ViewControl.Table)]
        public long? IngressBytesTransferred { get; set; }

        public List<PSIpsecPolicy> IpsecPolicies { get; set; }

        [Ps1Xml(Label = "Connection Bandwidth", Target = ViewControl.Table)]
        public int ConnectionBandwidth { get; set; }

        [Ps1Xml(Label = "Routing Weight", Target = ViewControl.Table)]
        public int RoutingWeight { get; set; }

        [Ps1Xml(Label = "BGP Enabled", Target = ViewControl.Table)]
        public bool EnableBgp { get; set; }

        [Ps1Xml(Label = "UsePolicyBasedTrafficSelectors", Target = ViewControl.Table)]
        public bool UsePolicyBasedTrafficSelectors { get; set; }

        [Ps1Xml(Label = "UseLocalAzureIpAddress", Target = ViewControl.Table)]
        public bool UseLocalAzureIpAddress { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Label = "IngressNatRules", Target = ViewControl.Table)]
        public List<PSResourceId> IngressNatRules { get; set; }

        [Ps1Xml(Label = "EgressNatRules", Target = ViewControl.Table)]
        public List<PSResourceId> EgressNatRules { get; set; }

        [JsonIgnore]
        public string IngressNatRulesText
        {
            get { return JsonConvert.SerializeObject(IngressNatRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string EgressNatRulesText
        {
            get { return JsonConvert.SerializeObject(EgressNatRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
