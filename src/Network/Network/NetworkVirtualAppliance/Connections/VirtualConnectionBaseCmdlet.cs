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
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class VirtualConnectionBaseCmdlet : NetworkVirtualApplianceBaseCmdlet
    {
        public INetworkVirtualApplianceConnectionsOperations NetworkVirtualApplianceConnectionClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.NetworkVirtualApplianceConnections;
            }
        }

        public PSNetworkVirtualApplianceConnection ToPsNvaConnection(Management.Network.Models.NetworkVirtualApplianceConnection nvaConnection)
        {
            return NetworkResourceManagerProfile.Mapper.Map<PSNetworkVirtualApplianceConnection>(nvaConnection);
        }

        public PSNetworkVirtualApplianceConnection GetNvaConnection(string resourceGroupName, string parentNvaName, string connectionName)
        {
            var nvaConnection = this.NetworkVirtualApplianceConnectionClient.Get(resourceGroupName, parentNvaName, connectionName);
            return this.ToPsNvaConnection(nvaConnection);
        }

        public List<PSNetworkVirtualApplianceConnection> ListNvaConnections(string resourceGroupName, string parentNvaName)
        {
            var nvaConnections = this.NetworkVirtualApplianceConnectionClient.List(resourceGroupName, parentNvaName);

            List<PSNetworkVirtualApplianceConnection> connectionsToReturn = new List<PSNetworkVirtualApplianceConnection>();
            if (nvaConnections != null)
            {
                foreach (MNM.NetworkVirtualApplianceConnection connection in nvaConnections)
                {
                    connectionsToReturn.Add(ToPsNvaConnection(connection));
                }
            }

            return connectionsToReturn;
        }

        public bool IsNvaConnectionPresent(string resourceGroupName, string parentNvaGatewayName, string name)
        {
            return NetworkBaseCmdlet.IsResourcePresent(() => { GetNvaConnection(resourceGroupName, parentNvaGatewayName, name); });
        }
    }
}
