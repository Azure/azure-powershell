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
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using MNM = Microsoft.Azure.Management.Network.Models;

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

        public List<PSVpnConnection> ListVpnConnections(string resourceGroupName, string parentVpnGatewayName)
        {
            var vpnConnections = this.VpnConnectionClient.ListByVpnGateway(resourceGroupName, parentVpnGatewayName);

            List<PSVpnConnection> connectionsToReturn = new List<PSVpnConnection>();
            if (vpnConnections != null)
            {
                foreach (MNM.VpnConnection connection in vpnConnections)
                {
                    connectionsToReturn.Add(ToPsVpnConnection(connection));
                }
            }

            return connectionsToReturn;
        }

        public bool IsVpnConnectionPresent(string resourceGroupName, string parentVpnGatewayName, string name)
        {
            return NetworkBaseCmdlet.IsResourcePresent(() => { GetVpnConnection(resourceGroupName, parentVpnGatewayName, name); });
        }
    }
}
