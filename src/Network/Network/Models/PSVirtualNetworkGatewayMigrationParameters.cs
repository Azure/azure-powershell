using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVirtualNetworkGatewayMigrationParameters
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string ResourceUrl { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string MigrationType { get; set; }
    }
}
