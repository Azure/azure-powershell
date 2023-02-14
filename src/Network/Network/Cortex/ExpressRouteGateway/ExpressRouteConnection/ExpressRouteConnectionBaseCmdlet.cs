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
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Management.Network;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class ExpressRouteConnectionBaseCmdlet : ExpressRouteGatewayBaseCmdlet
    {
        public IExpressRouteConnectionsOperations ExpressRouteConnectionClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.ExpressRouteConnections;
            }
        }

        public PSExpressRouteConnection ToPsExpressRouteConnection(Management.Network.Models.ExpressRouteConnection expressRouteConnection)
        {
            return NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteConnection>(expressRouteConnection);
        }

        public PSExpressRouteConnection GetExpressRouteConnection(string resourceGroupName, string expressRouteGatewayName, string name)
        {
            var expressRouteConnection = this.ExpressRouteConnectionClient.Get(resourceGroupName, expressRouteGatewayName, name);
            return this.ToPsExpressRouteConnection(expressRouteConnection);
        }

        public List<PSExpressRouteConnection> ListExpressRouteConnections(string resourceGroupName, string expressRouteGatewayName)
        {
            var expressRouteConnections = this.ExpressRouteConnectionClient.List(resourceGroupName, expressRouteGatewayName);

            List<PSExpressRouteConnection> connectionsToReturn = new List<PSExpressRouteConnection>();
            if (expressRouteConnections != null)
            {
                foreach (MNM.ExpressRouteConnection connection in expressRouteConnections.Value)
                {
                    connectionsToReturn.Add(ToPsExpressRouteConnection(connection));
                }
            }

            return connectionsToReturn;
        }

        public PSExpressRouteConnection CreateOrUpdateExpressRouteConnection(string resourceGroupName, string expressRouteGatewayName, PSExpressRouteConnection expressRouteConnection, Hashtable tags)
        {
            var expressRouteConnectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ExpressRouteConnection>(expressRouteConnection);

            this.ExpressRouteConnectionClient.CreateOrUpdate(resourceGroupName, expressRouteGatewayName, expressRouteConnection.Name, expressRouteConnectionModel);
            var connectionToReturn = this.GetExpressRouteConnection(resourceGroupName, expressRouteGatewayName, expressRouteConnection.Name);
            return connectionToReturn;
        }

        public bool IsExpressRouteConnectionPresent(string resourceGroupName, string expressRouteGatewayName, string name)
        {
            try
            {
                var connection = this.GetExpressRouteConnection(resourceGroupName, expressRouteGatewayName, name);
                if (connection == null)
                {
                    return false;
                }
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }
            }

            return true;
        }
    }
}
