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

using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes.Model
{
    public class RouteTableWithRoutes : SimpleRouteTable
    {
        private List<Route> routes = new List<Route>();

        public IEnumerable<Route> Routes
        {
            get { return this.routes; }
            set { this.routes = value.ToList(); }
        }

        public RouteTableWithRoutes(RouteTable routeTableFromGetResponse)
            : base(routeTableFromGetResponse)
        {
            Mapper.CreateMap<WindowsAzure.Management.Network.Models.Route, Route>();
            Mapper.CreateMap<WindowsAzure.Management.Network.Models.NextHop, NextHop>();
            if (routeTableFromGetResponse.RouteList != null)
            {
                routes.AddRange(routeTableFromGetResponse.RouteList.Select(Mapper.Map<Route>));
            }
        }
    }
}
