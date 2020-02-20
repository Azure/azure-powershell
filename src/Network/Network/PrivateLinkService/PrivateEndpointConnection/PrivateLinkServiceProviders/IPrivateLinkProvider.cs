using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network
{
    public interface IPrivateLinkProvider
    {
        #region Interface for general usage
        NetworkBaseCmdlet BaseCmdlet { get; set; }
        #endregion

        #region Interface for Private Endpoint Connection
        PSPrivateEndpointConnection GetPrivateEndpointConnection(string resourceGroupName, string serviceName, string name);
        List<PSPrivateEndpointConnection> ListPrivateEndpointConnections(string resourceGroupName, string serviceName);
        PSPrivateEndpointConnection UpdatePrivateEndpointConnectionStatus(string resourceGroupName, string serviceName, string name, string status, string description = null);
        void DeletePrivateEndpointConnection(string resourceGroupName, string serviceName, string name);
        #endregion

        #region Interface for Private Link Resource
        PSPrivateLinkResource GetPrivateLinkResource(string resourceGroupName, string serviceName, string name);
        List<PSPrivateLinkResource> ListPrivateLinkResource(string resourceGroupName, string serviceName);
        #endregion

    }
}
