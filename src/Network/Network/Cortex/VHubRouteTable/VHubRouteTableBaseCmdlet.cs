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
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class VHubRouteTableBaseCmdlet : NetworkBaseCmdlet
    {
        public IHubRouteTablesOperations VHubRouteTableClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.HubRouteTables;
            }
        }

        public PSVHubRouteTable ToPsVHubRouteTable(MNM.HubRouteTable routeTable)
        {
            var psVHubRouteTable = NetworkResourceManagerProfile.Mapper.Map<PSVHubRouteTable>(routeTable);

            return psVHubRouteTable;
        }

        public PSVHubRouteTable GetVHubRouteTable(string resourceGroupName, string virtualHubName, string name)
        {
            var routeTable = VHubRouteTableClient.Get(resourceGroupName, virtualHubName, name);
            var psVHubRouteTable = ToPsVHubRouteTable(routeTable);

            return psVHubRouteTable;
        }

        public List<PSVHubRouteTable> ListVHubRouteTables(string resourceGroupName, string virtualHubName)
        {
            var routeTables = VHubRouteTableClient.List(resourceGroupName, virtualHubName);

            List<PSVHubRouteTable> routeTablesToReturn = new List<PSVHubRouteTable>();
            if (routeTables != null)
            {
                foreach (MNM.HubRouteTable routeTable in routeTables)
                {
                    routeTablesToReturn.Add(ToPsVHubRouteTable(routeTable));
                }
            }

            return routeTablesToReturn;
        }

        public PSVHubRouteTable CreateOrUpdateVHubRouteTable(string resourceGroupName, string virtualHubName, string routeTableName, PSVHubRouteTable hubRouteTable)
        {
            var hubRouteTableModel = NetworkResourceManagerProfile.Mapper.Map<MNM.HubRouteTable>(hubRouteTable);
            var routeTableCreated = VHubRouteTableClient.CreateOrUpdate(resourceGroupName, virtualHubName, routeTableName, hubRouteTableModel);
            return ToPsVHubRouteTable(routeTableCreated);
        }

        public bool IsVHubRouteTablePresent(string resourceGroupName, string parentHubName, string name)
        {
            return IsResourcePresent(() => { GetVHubRouteTable(resourceGroupName, parentHubName, name); });
        }

        public void IsParentVirtualHubPresent(string resourceGroupName, string parentHubName)
        {
            // Get the virtual hub - this will throw not found if the resource does not exist
            PSVirtualHub resolvedVirtualHub = new VirtualHubBaseCmdlet().GetVirtualHub(resourceGroupName, parentHubName);
            if (resolvedVirtualHub == null)
            {
                throw new PSArgumentException(Properties.Resources.ParentVirtualHubNotFound);
            }
        }
    }
}