using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MSM = Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.Sql;


namespace Microsoft.Azure.Commands.Network
{
    public class SqlProvider : IPrivateLinkProvider
    {
        #region Constructor
        public SqlProvider(NetworkBaseCmdlet baseCmdlet)
        {
            this.BaseCmdlet = baseCmdlet;
        }
        #endregion

        #region Interface Implementation

        public NetworkBaseCmdlet BaseCmdlet { get; set; }

        public PSPrivateEndpointConnection GetPrivateEndpointConnection(string resourceGroupName, string serviceName, string name)
        {
            var privateEndpointConnection = BaseCmdlet.NetworkClient.SqlManagementClient.PrivateEndpointConnections.Get(resourceGroupName, serviceName, name);
            PSPrivateEndpointConnection psPEC = ToPsPrivateEndpointConnection(privateEndpointConnection);
            return psPEC;
        }

        public List<PSPrivateEndpointConnection> ListPrivateEndpointConnections(string resourceGroupName, string serviceName)
        {
            var pecPage = BaseCmdlet.NetworkClient.SqlManagementClient.PrivateEndpointConnections.ListByServer(resourceGroupName, serviceName);
            var pecList = ListNextLink<MSM.PrivateEndpointConnection>.GetAllResourcesByPollingNextLink(pecPage,BaseCmdlet.NetworkClient.SqlManagementClient.PrivateEndpointConnections.ListByServerNext);
            var psPECs = new List<PSPrivateEndpointConnection>();
            foreach(var pec in pecList)
            {
                var psPec = ToPsPrivateEndpointConnection(pec);
                psPECs.Add(psPec);
            }

            return psPECs;
        }

        public PSPrivateEndpointConnection UpdatePrivateEndpointConnectionStatus(string resourceGroupName, string serviceName, string name, string status, string description = null)
        {
            var privateEndpointConnection = BaseCmdlet.NetworkClient.SqlManagementClient.PrivateEndpointConnections.Get(resourceGroupName, serviceName, name);

            privateEndpointConnection.PrivateLinkServiceConnectionState.Status = status;

            if (!string.IsNullOrEmpty(description))
            {
                privateEndpointConnection.PrivateLinkServiceConnectionState.Description = description;
            }
            BaseCmdlet.NetworkClient.SqlManagementClient.PrivateEndpointConnections.CreateOrUpdate(resourceGroupName, serviceName, name, privateEndpointConnection);

            var updatedPec = BaseCmdlet.NetworkClient.SqlManagementClient.PrivateEndpointConnections.Get(resourceGroupName, serviceName, name);
            PSPrivateEndpointConnection psPEC = ToPsPrivateEndpointConnection(updatedPec);

            return psPEC;
        }

        public void DeletePrivateEndpointConnection(string resourceGroupName, string serviceName, string name)
        {
            BaseCmdlet.NetworkClient.SqlManagementClient.PrivateEndpointConnections.Delete(resourceGroupName, serviceName, name);
        }

        public PSPrivateLinkResource GetPrivateLinkResource(string resourceGroupName, string serviceName, string name)
        {
            var privateLinkResource = BaseCmdlet.NetworkClient.SqlManagementClient.PrivateLinkResources.Get(resourceGroupName, serviceName, name);
            PSPrivateLinkResource psPlr = ToPsPrivateLinkResource(privateLinkResource);
            return psPlr;
        }

        public List<PSPrivateLinkResource> ListPrivateLinkResource(string resourceGroupName, string serviceName)
        {
            var plrPage = BaseCmdlet.NetworkClient.SqlManagementClient.PrivateLinkResources.ListByServer(resourceGroupName, serviceName);
            var plrList = ListNextLink<MSM.PrivateLinkResource>.GetAllResourcesByPollingNextLink(plrPage, BaseCmdlet.NetworkClient.SqlManagementClient.PrivateLinkResources.ListByServerNext);
            var psPLRs = new List<PSPrivateLinkResource>();
            foreach (var plr in plrList)
            {
                var psPlr = ToPsPrivateLinkResource(plr);
                psPLRs.Add(psPlr);
            }

            return psPLRs;
        }

        #endregion

        #region Private Methods

        private PSPrivateEndpointConnection ToPsPrivateEndpointConnection(Management.Sql.Models.PrivateEndpointConnection privateEndpointConnection)
        {
            PSPrivateEndpointConnection psPEC = new PSPrivateEndpointConnection
            {
                Name = privateEndpointConnection.Name,
                Id = privateEndpointConnection.Id,
                ProvisioningState = privateEndpointConnection.ProvisioningState,
            };
            psPEC.PrivateEndpoint = new PSPrivateEndpoint
            {
                Id = privateEndpointConnection.PrivateEndpoint.Id
            };
            psPEC.PrivateLinkServiceConnectionState = new PSPrivateLinkServiceConnectionState
            {
                Status = privateEndpointConnection.PrivateLinkServiceConnectionState.Status,
                Description = privateEndpointConnection.PrivateLinkServiceConnectionState.Description,
                ActionsRequired = privateEndpointConnection.PrivateLinkServiceConnectionState.ActionsRequired
            };

            return psPEC;
        }

        private PSPrivateLinkResource ToPsPrivateLinkResource(Management.Sql.Models.PrivateLinkResource privateLinkResource)
        {
            PSPrivateLinkResource psPLR = new PSPrivateLinkResource
            {
                Name = privateLinkResource.Name,
                Id = privateLinkResource.Id,
                Type = privateLinkResource.Type,
                GroupId = privateLinkResource.Properties.GroupId
            };

            psPLR.RequiredMembers = new List<string>(privateLinkResource.Properties.RequiredMembers);

            return psPLR;
        }

        #endregion
    }
}
