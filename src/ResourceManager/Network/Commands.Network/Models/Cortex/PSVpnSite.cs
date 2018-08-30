namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVpnSite : PSTopLevelResource
    {
        public PSAddressSpace AddressSpace { get; set; }

        public PSBgpSettings BgpSettings { get; set; }

        public PSVpnSiteDeviceProperties DeviceProperties { get; set; }

        public string IpAddress { get; set; }

        public PSResourceId VirtualWan { get; set; }

        public bool IsSecuritySite { get; set; }

        public string SiteKey { get; set; }

        public string ProvisioningState { get; set; }
    }
}
