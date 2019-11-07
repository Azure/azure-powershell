using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSVpnClientConnectionHealthDetail
    {
        [Ps1Xml(Label = "VpnConnectionId", Target = ViewControl.Table)]
        public string VpnConnectionId { get; set; }
        
        [Ps1Xml(Label = "VpnConnectionDurationInSeconds", Target = ViewControl.Table)]
        public long? VpnConnectionDuration { get; set; }
        
        [Ps1Xml(Label = "VpnConnectionTime", Target = ViewControl.Table)]
        public string VpnConnectionTime { get; set; }
        
        [Ps1Xml(Label = "PublicIpAddress", Target = ViewControl.Table)]
        public string PublicIpAddress { get; set; }
        
        [Ps1Xml(Label = "PrivateIpAddress", Target = ViewControl.Table)]
        public string PrivateIpAddress { get; set; }
        
        [Ps1Xml(Label = "VpnUserName", Target = ViewControl.Table)]
        public string VpnUserName { get; set; }
        
        [Ps1Xml(Label = "MaxBandwidth", Target = ViewControl.Table)]
        public long? MaxBandwidth { get; set; }
        
        [Ps1Xml(Label = "EgressPacketsTransferred", Target = ViewControl.Table)]
        public long? EgressPacketsTransferred { get; set; }
        
        [Ps1Xml(Label = "EgressBytesTransferred", Target = ViewControl.Table)]
        public long? EgressBytesTransferred { get; set; }
        
        [Ps1Xml(Label = "IngressPacketsTransferred", Target = ViewControl.Table)]
        public long? IngressPacketsTransferred { get; set; }
        
        [Ps1Xml(Label = "IngressBytesTransferred", Target = ViewControl.Table)]
        public long? IngressBytesTransferred { get; set; }
        
        [Ps1Xml(Label = "MaxPacketsPerSecond", Target = ViewControl.Table)]
        public long? MaxPacketsPerSecond { get; set; }
    }
}
