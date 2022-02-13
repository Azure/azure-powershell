using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSRouteServerPeer : PSChildResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public uint PeerAsn { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string PeerIp { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
    }
}