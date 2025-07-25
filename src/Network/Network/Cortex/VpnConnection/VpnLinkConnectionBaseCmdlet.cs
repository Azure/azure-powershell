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
    }
}
