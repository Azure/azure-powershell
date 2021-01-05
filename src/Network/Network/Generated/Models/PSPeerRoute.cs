using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSPeerRoute
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string LocalAddress { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string Network { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string NextHop { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string SourcePeer { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string Origin { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string AsPath { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public int? Weight { get; set; }
    }
}