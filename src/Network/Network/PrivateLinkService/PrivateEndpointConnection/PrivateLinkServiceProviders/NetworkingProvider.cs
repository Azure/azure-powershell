using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network
{
    public class NetworkingProvider : IPrivateLinkProvider
    {
        #region Constructor

        public NetworkingProvider(NetworkBaseCmdlet baseCmdlet)
        {
            BaseCmdlet = baseCmdlet;
        }

        #endregion

        #region Interface Implementation

        public NetworkBaseCmdlet BaseCmdlet { get; set; }

        public void DeletePrivateEndpointConnection(string resourceGroupName, string serviceName, string name)
        {
            BaseCmdlet.NetworkClient.NetworkManagementClient.PrivateLinkServices.DeletePrivateEndpointConnection(resourceGroupName, serviceName, name);
        }

        public PSPrivateEndpointConnection UpdatePrivateEndpointConnectionStatus(string resourceGroupName, string serviceName, string name, string status, string description = null)
        {
            var privateEndpointConnection = BaseCmdlet.NetworkClient.NetworkManagementClient.PrivateLinkServices.GetPrivateEndpointConnection(resourceGroupName, serviceName, name);

            privateEndpointConnection.PrivateLinkServiceConnectionState.Status = status;

            if (!string.IsNullOrEmpty(description))
            {
                privateEndpointConnection.PrivateLinkServiceConnectionState.Description = description;
            }
            BaseCmdlet.NetworkClient.NetworkManagementClient.PrivateLinkServices.UpdatePrivateEndpointConnection(resourceGroupName, serviceName, name, privateEndpointConnection);

            var updatedPec = BaseCmdlet.NetworkClient.NetworkManagementClient.PrivateLinkServices.GetPrivateEndpointConnection(resourceGroupName, serviceName, name);
            PSPrivateEndpointConnection psPEC = ToPsPrivateEndpointConnection(updatedPec);

            return psPEC;
        }

        public PSPrivateEndpointConnection GetPrivateEndpointConnection(string resourceGroupName, string serviceName, string name)
        {
            var privateEndpointConnection = BaseCmdlet.NetworkClient.NetworkManagementClient.PrivateLinkServices.GetPrivateEndpointConnection(resourceGroupName, serviceName, name);
            var psPrivateEndpointConnection = ToPsPrivateEndpointConnection(privateEndpointConnection);
            return psPrivateEndpointConnection;
        }

        public List<PSPrivateEndpointConnection> ListPrivateEndpointConnections(string resourceGroupName, string serviceName)
        {
            var pecPage = BaseCmdlet.NetworkClient.NetworkManagementClient.PrivateLinkServices.ListPrivateEndpointConnections(resourceGroupName, serviceName);
            var pecList = ListNextLink<MNM.PrivateEndpointConnection>.GetAllResourcesByPollingNextLink(pecPage, BaseCmdlet.NetworkClient.NetworkManagementClient.PrivateLinkServices.ListPrivateEndpointConnectionsNext);
            var psPECs = new List<PSPrivateEndpointConnection>();
            foreach(var pec in pecList)
            {
                var psPec = this.ToPsPrivateEndpointConnection(pec);
                psPECs.Add(psPec);
            }
            return psPECs;
        }

        public PSPrivateLinkResource GetPrivateLinkResource(string resourceGroupName, string serviceName, string name)
        {
            throw new NotImplementedException();
        }

        public List<PSPrivateLinkResource> ListPrivateLinkResource(string resourceGroupName, string serviceName)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        private PSPrivateEndpointConnection ToPsPrivateEndpointConnection(MNM.PrivateEndpointConnection privateEndpointConnection)
        {
            var psPrivateEndpointConnection = NetworkResourceManagerProfile.Mapper.Map<PSPrivateEndpointConnection>(privateEndpointConnection);
            return psPrivateEndpointConnection;
        }

        #endregion
    }
}
