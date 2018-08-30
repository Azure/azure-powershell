namespace Microsoft.Azure.Commands.Network.Models
{
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSVpnSite : PSTopLevelResource
    {
        [Ps1Xml(Label = "Address Space", Target = ViewControl.Table, ScriptBlock = "$_.AddressSpace.AddressPrefixes")]
        public PSAddressSpace AddressSpace { get; set; }

        public PSBgpSettings BgpSettings { get; set; }

        public PSVpnSiteDeviceProperties DeviceProperties { get; set; }

        [Ps1Xml(Label = "Ip Address", Target = ViewControl.Table)]
        public string IpAddress { get; set; }

        [Ps1Xml(Label = "Address Space", Target = ViewControl.Table, ScriptBlock = "$_.VirtualWan.Id")]
        public PSResourceId VirtualWan { get; set; }

        [Ps1Xml(Label = "IsSecuritySite", Target = ViewControl.Table)]
        public bool IsSecuritySite { get; set; }

        public string SiteKey { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
    }
}
