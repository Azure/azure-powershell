namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using System;
    using System.Management.Automation;
    using System.Net;

    public class VpnConnectionBaseCmdlet : VpnGatewayBaseCmdlet
    {
        public IVpnConnectionsOperations VpnConnectionClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VpnConnections;
            }
        }

        public PSVpnConnection ToPsVpnConnection(Management.Network.Models.VpnConnection vpnConnection)
        {
            return NetworkResourceManagerProfile.Mapper.Map<PSVpnConnection>(vpnConnection);
        }

        public PSVpnConnection GetVpnConnection(string resourceGroupName, string parentVpnGatewayName, string name)
        {
            var vpnConnection = this.VpnConnectionClient.Get(resourceGroupName, parentVpnGatewayName, name);
            return this.ToPsVpnConnection(vpnConnection);
        }
    }
}
