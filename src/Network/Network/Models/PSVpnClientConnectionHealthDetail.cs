using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSVpnClientConnectionHealthDetail
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string VpnConnectionId { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public long? VpnConnectionDuration { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string VpnConnectionTime { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string PublicIpAddress { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string PrivateIpAddress { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string VpnUserName { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public long? MaxBandwidth { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public long? EgressPacketsTransferred { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public long? EgressBytesTransferred { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public long? IngressPacketsTransferred { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public long? IngressBytesTransferred { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public long? MaxPacketsPerSecond { get; set; }
    }
}
