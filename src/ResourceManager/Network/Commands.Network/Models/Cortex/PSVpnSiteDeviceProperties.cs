namespace Microsoft.Azure.Commands.Network.Models
{
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSVpnSiteDeviceProperties
    {
        [Ps1Xml(Label = "Device Model", Target = ViewControl.Table)]
        public string DeviceModel { get; set; }

        [Ps1Xml(Label = "Device Vendor", Target = ViewControl.Table)]
        public string DeviceVendor { get; set; }

        [Ps1Xml(Label = "Link Speed in Mbps", Target = ViewControl.Table)]
        public int LinkSpeedInMbps { get; set; }
    }
}
