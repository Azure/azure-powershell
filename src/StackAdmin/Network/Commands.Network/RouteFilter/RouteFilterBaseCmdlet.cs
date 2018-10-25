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
    using System.Net;
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;

    public abstract class RouteFilterBaseCmdlet : NetworkBaseCmdlet
    {
        public IRouteFiltersOperations RouteFilterClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.RouteFilters;
            }
        }

        public bool IsRouteFilterPresent(string resourceGroupName, string name)
        {
            try
            {
                this.GetRouteFilter(resourceGroupName, name);
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

        public PSRouteFilter GetRouteFilter(string resourceGroupName, string name, string expandResource = null)
        {
            var routeFilter = this.RouteFilterClient.Get(resourceGroupName, name, expandResource);

            var psRouteFilter = NetworkResourceManagerProfile.Mapper.Map<PSRouteFilter>(routeFilter);
            psRouteFilter.ResourceGroupName = resourceGroupName;
            psRouteFilter.Tag = TagsConversionHelper.CreateTagHashtable(routeFilter.Tags);

            return psRouteFilter;
        }

        public PSRouteFilter ToPsRouteFilter(RouteFilter routeFilter)
        {
            var psRouteFilter = NetworkResourceManagerProfile.Mapper.Map<PSRouteFilter>(routeFilter);

            psRouteFilter.Tag = TagsConversionHelper.CreateTagHashtable(routeFilter.Tags);

            return psRouteFilter;
        }
    }
}
