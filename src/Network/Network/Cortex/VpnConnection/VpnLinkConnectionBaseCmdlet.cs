using Microsoft.Azure.Management.Network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Cortex.VpnConnection
{
    public class VpnLinkConnectionBaseCmdlet : VpnConnectionBaseCmdlet
    {
        public IVpnLinkConnectionsOperations VpnLinkConnectionClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VpnLinkConnections;
            }
        }

        // TODO: Check if Get operation available for VpnLinkConnections
        //public bool IsVpnLinkConnectionPresent(string resourceGroupName, string vpnGatewayName, string vpnConnectionName, string vpnLinkConnectionName)
        //{
        //    return NetworkBaseCmdlet.IsResourcePresent(() => { GetVpnLinkConnection(resourceGroupName, vpnGatewayName, vpnConnectionName, vpnLinkConnectionName); });
        //}
    }
}
