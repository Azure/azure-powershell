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

namespace Microsoft.Azure.Commands.Network.Routes
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using WindowsAzure.Management.Network.Models;

    [Cmdlet(VerbsCommon.Get, "AzureRouteTable"), OutputType(typeof(IEnumerable<RouteTable>))]
    public class GetAzureRouteTable : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, HelpMessage = "The new route table's name.")]
        public string Name { get; set; }

        [Parameter(Position = 0, Mandatory = false, HelpMessage = "The level of detail that will be returned about the route table(s). Valid values are: \"Routes\" or \"Full\".")]
        public string DetailLevel { get; set; }

        public override void ExecuteCmdlet()
        {
            IEnumerable<RouteTable> routeTables;
            if (string.IsNullOrEmpty(Name))
            {
                routeTables = Client.ListRouteTables();
            }
            else
            {
                RouteTable routeTable = Client.GetRouteTable(Name, DetailLevel);
                routeTables = new List<RouteTable>() { routeTable };
            }
            WriteObject(routeTables);
        }
    }
}
