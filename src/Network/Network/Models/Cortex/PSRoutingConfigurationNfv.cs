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

    public class PSRoutingConfigurationNfv
    {
        [Ps1Xml(Label = "AssociatedRouteTable", Target = ViewControl.Table, ScriptBlock = "$_.AssociatedRouteTable.resourceUri")]
        public PSResourceIdNfv AssociatedRouteTable { get; set; }

        public PSPropagatedRouteTableNfv PropagatedRouteTables { get; set; }

        [Ps1Xml(Label = "InboundRouteMap", Target = ViewControl.Table, ScriptBlock = "$_.InboundRouteMap.resourceUri")]
        public PSResourceIdNfv InboundRouteMap { get; set; }

        [Ps1Xml(Label = "OutboundRouteMap", Target = ViewControl.Table, ScriptBlock = "$_.OutboundRouteMap.resourceUri")]
        public PSResourceIdNfv OutboundRouteMap { get; set; }

        [JsonIgnore]
        public string PropagatedRouteTablesText
        {
            get { return JsonConvert.SerializeObject(PropagatedRouteTables, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

    }

    public class PSPropagatedRouteTableNfv
    {
        [Ps1Xml(Label = "labels", Target = ViewControl.Table)]
        public List<string> Labels { get; set; }

        [Ps1Xml(Label = "ids", Target = ViewControl.Table)]
        public List<PSResourceIdNfv> Ids { get; set; }
    }

}
