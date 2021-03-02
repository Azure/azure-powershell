// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network
{
    internal static class CortexParameterSetNames
    {
        internal const string ByVirtualWanObject = "ByVirtualWanObject";
        internal const string ByVirtualWanResourceId = "ByVirtualWanResourceId";
        internal const string ByVirtualWanName = "ByVirtualWanName";

        internal const string ByVirtualHubObject = "ByVirtualHubObject";
        internal const string ByVirtualHubResourceId = "ByVirtualHubResourceId";
        internal const string ByVirtualHubName = "ByVirtualHubName";
        internal const string NoVirtualWanUpdate = "NoVirtualWanUpdate";
        
        internal const string ByVpnGatewayObject = "ByVpnGatewayObject";
        internal const string ByVpnGatewayResourceId = "ByVpnGatewayResourceId";
        internal const string ByVpnGatewayName = "ByVpnGatewayName";

        internal const string ByP2SVpnGatewayObject = "ByP2SVpnGatewayObject";
        internal const string ByP2SVpnGatewayResourceId = "ByP2SVpnGatewayResourceId";
        internal const string ByP2SVpnGatewayName = "ByP2SVpnGatewayName";

        internal const string ByExpressRouteGatewayObject = "ByExpressRouteGatewayObject";
        internal const string ByExpressRouteGatewayResourceId = "ByExpressRouteGatewayResourceId";
        internal const string ByExpressRouteGatewayName = "ByExpressRouteGatewayName";

        internal const string ByVpnSiteObject = "ByVpnSiteObject";
        internal const string ByVpnSiteResourceId = "ByVpnSiteResourceId";
        internal const string ByVpnSiteName = "ByVpnSiteName";
        internal const string ByVpnSiteIpAddress = "ByVpnSiteIpAddress";
        internal const string ByVpnSiteLinkObject = "ByVpnSiteLinkObject";

        internal const string ByVpnSiteLinkIpAddress = "ByVpnSiteLinkIpAddress";
        internal const string ByVpnSiteLinkFqdn = "ByVpnSiteLinkFqdn";
        
        internal const string ByVpnConnectionObject = "ByVpnConnectionObject";
        internal const string ByVpnConnectionResourceId = "ByVpnConnectionResourceId";
        internal const string ByVpnConnectionName = "ByVpnConnectionName";

        internal const string NoVpnServerConfigurationUpdate = "NoVpnServerConfigurationUpdate";
        internal const string ByVpnServerConfigurationObject = "ByVpnServerConfigurationObject";
        internal const string ByVpnServerConfigurationResourceId = "ByVpnServerConfigurationResourceId";
        internal const string ByVpnServerConfigurationName = "ByVpnServerConfigurationName";
        internal const string ByCertificateAuthentication = "ByCertificateAuthentication";
        internal const string ByRadiusAuthentication = "ByRadiusAuthentication";
        internal const string ByAadAuthentication = "ByAadAuthentication";

        internal const string ByExpressRouteConnectionObject = "ByExpressRouteConnectionObject";
        internal const string ByExpressRouteConnectionResourceId = "ByExpressRouteConnectionResourceId";
        internal const string ByExpressRouteConnectionName = "ByExpressRouteConnectionName";

        internal const string ByHubVirtualNetworkConnectionObject = "ByHubVirtualNetworkConnectionObject";
        internal const string ByHubVirtualNetworkConnectionResourceId = "ByHubVirtualNetworkConnectionResourceId";
        internal const string ByHubVirtualNetworkConnectionName = "ByHubVirtualNetworkConnectionName";

        internal const string ByRemoteVirtualNetworkObject = "ByRemoteVirtualNetworkObject";
        internal const string ByRemoteVirtualNetworkResourceId = "ByRemoteVirtualNetworkResourceId";

        internal const string ByVirtualHubRouteTableObject = "ByVirtualHubRouteTableObject";
        internal const string ByVirtualHubRouteTableResourceId = "ByVirtualHubRouteTableResourceId";
        internal const string ByVirtualHubRouteTableName = "ByVirtualHubRouteTableName";
        
        internal const string ByVHubRouteTableObject = "ByVHubRouteTableObject";
        internal const string ByVHubRouteTableResourceId = "ByVHubRouteTableResourceId";
        internal const string ByVHubRouteTableName = "ByVHubRouteTableName";

        internal const string ByVpnGatewayNatRuleObject = "ByVpnGatewayNatRuleObject";
        internal const string ByVpnGatewayNatRuleResourceId = "ByVpnGatewayNatRuleResourceId";
        internal const string ByVpnGatewayNatRuleName = "ByVpnGatewayNatRuleName";
    }
}