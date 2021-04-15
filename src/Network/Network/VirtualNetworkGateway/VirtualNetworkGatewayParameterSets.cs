using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    public class VirtualNetworkGatewayParameterSets
    {
        public const string Default = @"Default";
        public const string UpdateResourceWithTags = @"UpdateResourceWithTags";

        internal const string ByVirtualNetworkGatewayName = "ByVirtualNetworkGatewayName";
        internal const string ByVirtualNetworkGatewayObject = "ByVirtualNetworkGatewayObject";
        internal const string ByVirtualNetworkGatewayResourceId = "ByVirtualNetworkGatewayResourceId";
        internal const string ByVirtualNetworkGatewayNatRuleObject = "ByVirtualNetworkGatewayNatRuleObject";
        internal const string ByVirtualNetworkGatewayNatRuleResourceId = "ByVirtualNetworkGatewayNatRuleResourceId";
        internal const string ByVirtualNetworkGatewayNatRuleName = "ByVirtualNetworkGatewayNatRuleName";
    }
}
