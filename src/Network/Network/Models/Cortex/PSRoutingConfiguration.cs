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
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    public class PSRoutingConfiguration
    {
        [Ps1Xml(Label = "AssociatedRouteTable", Target = ViewControl.Table, ScriptBlock = "$_.AssociatedRouteTable.Id")]
        public PSResourceId AssociatedRouteTable { get; set; }

        public PSPropagatedRouteTable PropagatedRouteTables { get; set; }

        [Ps1Xml(Label = "VnetRoutes", Target = ViewControl.Table)]
        public PSVnetRoute VnetRoutes { get; set; }

        [JsonIgnore]
        public string PropagatedRouteTablesText
        {
            get { return JsonConvert.SerializeObject(PropagatedRouteTables, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VnetRoutesText
        {
            get { return JsonConvert.SerializeObject(VnetRoutes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
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
        public List<PSStaticRoute> StaticRoutes { get; set; }
        public PSStaticRoutesConfig StaticRoutesConfig { get; set; }
    }

    public class PSStaticRoute
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table)]
        public string Name { get; set; }

        [Ps1Xml(Label = "AddressPrefxes", Target = ViewControl.Table)]
        public List<string> AddressPrefixes { get; set; }

        [Ps1Xml(Label = "NextHopIpAddress", Target = ViewControl.Table)]
        public string NextHopIpAddress { get; set; }
    }

    public class PSStaticRoutesConfig
    {
        [Ps1Xml(Label = "PropagateStaticRoutes", Target = ViewControl.Table)]
        public bool PropagateStaticRoutes { get; } = true;

        [Ps1Xml(Label = "VnetLocalRouteOverrideCriteria", Target = ViewControl.Table)]
        public string VnetLocalRouteOverrideCriteria { get; set; }
    }
}
