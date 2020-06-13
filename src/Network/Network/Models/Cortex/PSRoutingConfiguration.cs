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

namespace Microsoft.Azure.Commands.Network.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSRoutingConfiguration
    {
        [Ps1Xml(Label = "Associated Route Table", Target = ViewControl.Table)]
        public PSResourceId AssociatedRouteTable { get; set; }

        [Ps1Xml(Label = "Propagated Route Tables", Target = ViewControl.Table)]
        public PSPropagatedRouteTable PropagatedRouteTables { get; set; }

        [Ps1Xml(Label = "Vnet Routes", Target = ViewControl.Table)]
        public PSVnetRoute VnetRoutes { get; set; }
    }

    public class PSPropagatedRouteTable
    {
        [Ps1Xml(Label = "Labels", Target = ViewControl.Table)]
        public List<string> Labels { get; set; }

        [Ps1Xml(Label = "Ids", Target = ViewControl.Table)]
        public List<PSResourceId> Ids { get; set; }
    }

    public class PSVnetRoute
    {
        [Ps1Xml(Label = "Static Routes", Target = ViewControl.Table)]
        public List<PSStaticRoute> StaticRoutes { get; set; }
    }

    public class PSStaticRoute
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table)]
        public string Name { get; set; }

        [Ps1Xml(Label = "Address Prefxes", Target = ViewControl.Table)]
        public List<string> AddressPrefixes { get; set; }

        [Ps1Xml(Label = "Next Hop IpAddress", Target = ViewControl.Table)]
        public string NextHopIpAddress { get; set; }
    }
}
