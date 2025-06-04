using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVirtualNetworkGatewayMigrationStatus
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string State { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string Phase { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ErrorMessage { get; set; }
    }
}
