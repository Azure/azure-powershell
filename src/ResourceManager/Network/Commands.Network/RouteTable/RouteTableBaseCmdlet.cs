
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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Net;

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Management.Network.Models;

    public abstract class RouteTableBaseCmdlet : NetworkBaseCmdlet
    {
        public IRouteTablesOperations RouteTableClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.RouteTables;
            }
        }

        public bool IsRouteTablePresent(string resourceGroupName, string name)
        {
            try
            {
                this.GetRouteTable(resourceGroupName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSRouteTable GetRouteTable(string resourceGroupName, string name, string expandResource = null)
        {
            var routeTable = this.RouteTableClient.Get(resourceGroupName, name, expandResource);

            var psRouteTable = Mapper.Map<PSRouteTable>(routeTable);
            psRouteTable.ResourceGroupName = resourceGroupName;

            psRouteTable.Tag = TagsConversionHelper.CreateTagHashtable(routeTable.Tags);

            return psRouteTable;
        }

        public PSRouteTable ToPsRouteTable(RouteTable routeTable)
        {
            var psRouteTable = Mapper.Map<PSRouteTable>(routeTable);

            psRouteTable.Tag = TagsConversionHelper.CreateTagHashtable(routeTable.Tags);

            return psRouteTable;
        }
    }
}