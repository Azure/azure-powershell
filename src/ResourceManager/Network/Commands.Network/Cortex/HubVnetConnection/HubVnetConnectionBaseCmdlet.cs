namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using System.Collections.Generic;
    using System.Net;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class HubVnetConnectionBaseCmdlet : VirtualHubBaseCmdlet
    {
        public IHubVirtualNetworkConnectionsOperations HubVirtualNetworkConnectionsClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.HubVirtualNetworkConnections;
            }
        }

        public PSHubVirtualNetworkConnection ToPsHubVirtualNetworkConnection(Management.Network.Models.HubVirtualNetworkConnection hubConnection)
        {
            var psVirtualHubVirtualNetworkConnection = NetworkResourceManagerProfile.Mapper.Map<PSHubVirtualNetworkConnection>(hubConnection);

            return psVirtualHubVirtualNetworkConnection;
        }

        public PSHubVirtualNetworkConnection GetHubVirtualNetworkConnection(string resourceGroupName, string virtualHubName, string name)
        {
            var virtualHubConnection = this.HubVirtualNetworkConnectionsClient.Get(resourceGroupName, virtualHubName, name);
            var psHubVirtualNetworkConnection = ToPsHubVirtualNetworkConnection(virtualHubConnection);

            return psHubVirtualNetworkConnection;
        }

        public List<PSHubVirtualNetworkConnection> ListHubVnetConnections(string resourceGroupName, string parentHubName)
        {
            var hubVnetConnections = this.HubVirtualNetworkConnectionsClient.List(resourceGroupName, parentHubName);

            List<PSHubVirtualNetworkConnection> connectionsToReturn = new List<PSHubVirtualNetworkConnection>();
            if (hubVnetConnections != null)
            {
                foreach (MNM.HubVirtualNetworkConnection connection in hubVnetConnections)
                {
                    connectionsToReturn.Add(ToPsHubVirtualNetworkConnection(connection));
                }
            }

            return connectionsToReturn;
        }
    }
}