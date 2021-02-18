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
    using Microsoft.Azure.Management.Network;
    using System.Collections.Generic;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class VirtualHubRouteTableBaseCmdlet : VirtualHubBaseCmdlet
    {
        public IVirtualHubRouteTableV2sOperations VirtualHubRouteTablesClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualHubRouteTableV2s;
            }
        }

        public PSVirtualHubRouteTable ToPsVirtualHubRouteTable(Management.Network.Models.VirtualHubRouteTableV2 routeTable)
        {
            var psVirtualHubRouteTable = NetworkResourceManagerProfile.Mapper.Map<PSVirtualHubRouteTable>(routeTable);

            return psVirtualHubRouteTable;
        }

        public PSVirtualHubRouteTable GetVirtualHubRouteTable(string resourceGroupName, string virtualHubName, string name)
        {
            var routeTable = this.VirtualHubRouteTablesClient.Get(resourceGroupName, virtualHubName, name);
            var psVirtualHubRouteTable = ToPsVirtualHubRouteTable(routeTable);

            return psVirtualHubRouteTable;
        }

        public List<PSVirtualHubRouteTable> ListVirtualHubRouteTables(string resourceGroupName, string parentHubName)
        {
            var routeTables = this.VirtualHubRouteTablesClient.List(resourceGroupName, parentHubName);

            List<PSVirtualHubRouteTable> routeTablesToReturn = new List<PSVirtualHubRouteTable>();
            if (routeTables != null)
            {
                foreach (MNM.VirtualHubRouteTableV2 routeTable in routeTables)
                {
                    routeTablesToReturn.Add(ToPsVirtualHubRouteTable(routeTable));
                }
            }

            return routeTablesToReturn;
        }

        public bool IsVirtualHubRouteTablePresent(string resourceGroupName, string parentHubName, string name)
        {
            return NetworkBaseCmdlet.IsResourcePresent(() => { GetVirtualHubRouteTable(resourceGroupName, parentHubName, name); });
        }
    }
}