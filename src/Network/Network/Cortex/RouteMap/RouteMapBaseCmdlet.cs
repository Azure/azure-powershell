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

    public class RouteMapBaseCmdlet : NetworkBaseCmdlet
    {
        public IRouteMapsOperations RouteMapClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.RouteMaps;
            }
        }

        public PSRouteMap ToPsRouteMap(MNM.RouteMap routeMap)
        {
            var psRouteMap = NetworkResourceManagerProfile.Mapper.Map<PSRouteMap>(routeMap);
            return psRouteMap;
        }

        public PSRouteMap GetRouteMap(string resourceGroupName, string virtualHubName, string name)
        {
            var routeMap = RouteMapClient.Get(resourceGroupName, virtualHubName, name);
            var psRouteMap = ToPsRouteMap(routeMap);

            return psRouteMap;
        }

        public List<PSRouteMap> ListRouteMaps(string resourceGroupName, string virtualHubName)
        {
            var routeMaps = RouteMapClient.List(resourceGroupName, virtualHubName);

            List<PSRouteMap> routeMapsToReturn = new List<PSRouteMap>();
            if (routeMaps != null)
            {
                foreach (MNM.RouteMap routeMap in routeMaps)
                {
                    routeMapsToReturn.Add(ToPsRouteMap(routeMap));
                }
            }

            return routeMapsToReturn;
        }

        public PSRouteMap CreateOrUpdateRouteMap(string resourceGroupName, string virtualHubName, string routeMapName, PSRouteMap routeMap)
        {
            var routeMapModel = NetworkResourceManagerProfile.Mapper.Map<MNM.RouteMap>(routeMap);
            var routeMapCreated = RouteMapClient.CreateOrUpdate(resourceGroupName, virtualHubName, routeMapName, routeMapModel);
            return ToPsRouteMap(routeMapCreated);
        }

        public bool IsRouteMapPresent(string resourceGroupName, string parentHubName)
        {
            return ListRouteMaps(resourceGroupName, parentHubName).Count > 0;
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