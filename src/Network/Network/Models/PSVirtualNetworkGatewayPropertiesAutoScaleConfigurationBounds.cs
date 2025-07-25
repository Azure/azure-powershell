using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVirtualNetworkGatewayPropertiesAutoScaleConfigurationBounds
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public int Min { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public int Max { get; set; }
    }
}