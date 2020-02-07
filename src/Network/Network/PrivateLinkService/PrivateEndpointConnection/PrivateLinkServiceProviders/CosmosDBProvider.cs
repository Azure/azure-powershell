using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MSM = Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB;

namespace Microsoft.Azure.Commands.Network
{
    public class CosmosDBProvider : IPrivateLinkProvider
    {
        #region Constructor
        public CosmosDBProvider(NetworkBaseCmdlet baseCmdlet)
        {
            this.BaseCmdlet = baseCmdlet;
        }
        #endregion

        public NetworkBaseCmdlet BaseCmdlet { get; set; }

        public PSPrivateEndpointConnection GetPrivateEndpointConnection(string resourceGroupName, string serviceName, string name)
        {
            var privateEndpointConnection = BaseCmdlet.NetworkClient.CosmosDBManagementClient.PrivateEndpointConnections.Get(resourceGroupName, serviceName, name);
            PSPrivateEndpointConnection psPEC = ToPsPrivateEndpointConnection(privateEndpointConnection);
            return psPEC;
        }

        public List<PSPrivateEndpointConnection> ListPrivateEndpointConnections(string resourceGroupName, string serviceName)
        {
            var pecPage = BaseCmdlet.NetworkClient.CosmosDBManagementClient.PrivateEndpointConnections.ListByDatabaseAccount(resourceGroupName, serviceName);
            var psPECs = new List<PSPrivateEndpointConnection>();
            foreach (var pec in pecPage)
            {
                var psPec = ToPsPrivateEndpointConnection(pec);
                psPECs.Add(psPec);
            }

            return psPECs;
        }
        public PSPrivateEndpointConnection UpdatePrivateEndpointConnectionStatus(string resourceGroupName, string serviceName, string name, string status, string description = null)
        {
            var privateEndpointConnection = BaseCmdlet.NetworkClient.CosmosDBManagementClient.PrivateEndpointConnections.Get(resourceGroupName, serviceName, name);

            privateEndpointConnection.PrivateLinkServiceConnectionState.Status = status;

            if (!string.IsNullOrEmpty(description))
            {
                privateEndpointConnection.PrivateLinkServiceConnectionState.Description = description;
            }
            BaseCmdlet.NetworkClient.CosmosDBManagementClient.PrivateEndpointConnections.CreateOrUpdate(resourceGroupName, serviceName, name, privateEndpointConnection);

            var updatedPec = BaseCmdlet.NetworkClient.CosmosDBManagementClient.PrivateEndpointConnections.Get(resourceGroupName, serviceName, name);
            PSPrivateEndpointConnection psPEC = ToPsPrivateEndpointConnection(updatedPec);

            return psPEC;
        }

        public void DeletePrivateEndpointConnection(string resourceGroupName, string serviceName, string name)
        {
            BaseCmdlet.NetworkClient.CosmosDBManagementClient.PrivateEndpointConnections.Delete(resourceGroupName, serviceName, name);
        }

        public PSPrivateLinkResource GetPrivateLinkResource(string resourceGroupName, string serviceName, string name)
        {
            var privateLinkResource = BaseCmdlet.NetworkClient.CosmosDBManagementClient.PrivateLinkResources.Get(resourceGroupName, serviceName, name);
            PSPrivateLinkResource psPlr = ToPsPrivateLinkResource(privateLinkResource);
            return psPlr;
        }

        public List<PSPrivateLinkResource> ListPrivateLinkResource(string resourceGroupName, string serviceName)
        {
            var plrPage = BaseCmdlet.NetworkClient.CosmosDBManagementClient.PrivateLinkResources.ListByDatabaseAccount(resourceGroupName, serviceName);
            var psPLRs = new List<PSPrivateLinkResource>();
            foreach (var plr in plrPage)
            {
                var psPlr = ToPsPrivateLinkResource(plr);
                psPLRs.Add(psPlr);
            }

            return psPLRs;
        }

        #region Private Methods

        private PSPrivateEndpointConnection ToPsPrivateEndpointConnection(Management.CosmosDB.Models.PrivateEndpointConnection privateEndpointConnection)
        {
            PSPrivateEndpointConnection psPEC = new PSPrivateEndpointConnection
            {
                Name = privateEndpointConnection.Name,
                Id = privateEndpointConnection.Id,
                ProvisioningState = "null"
            };
            psPEC.PrivateEndpoint = new PSPrivateEndpoint
            {
                Id = privateEndpointConnection.PrivateEndpoint.Id
            };
            psPEC.PrivateLinkServiceConnectionState = new PSPrivateLinkServiceConnectionState
            {
                Status = privateEndpointConnection.PrivateLinkServiceConnectionState.Status,
                Description = privateEndpointConnection.PrivateLinkServiceConnectionState.Description,
                ActionRequired = privateEndpointConnection.PrivateLinkServiceConnectionState.ActionsRequired
            };

            return psPEC;
        }

        private PSPrivateLinkResource ToPsPrivateLinkResource(Management.CosmosDB.Models.PrivateLinkResource privateLinkResource)
        {
            PSPrivateLinkResource psPLR = new PSPrivateLinkResource
            {
                Name = privateLinkResource.Name,
                Id = privateLinkResource.Id,
                Type = privateLinkResource.Type,
                GroupId = privateLinkResource.GroupId
            };

            psPLR.RequiredMembers = new List<string>(privateLinkResource.RequiredMembers);

            return psPLR;
        }

        #endregion
    }
}
