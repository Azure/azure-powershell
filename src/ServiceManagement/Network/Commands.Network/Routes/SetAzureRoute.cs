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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes.Utilities;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes
{
    [Cmdlet(VerbsCommon.Set, "AzureRoute"), OutputType(typeof(IRouteTable))]
    public class SetAzureRoute : RouteTableConfigurationBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The new route's name.")]
        public string RouteName { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The new route's address prefix (such as \"0.0.0.0/0\").")]
        public string AddressPrefix { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The new route's next hop type. Valid values are \"VPNGateway\".")]
        public string NextHopType { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The new route's next hop ip address." +
                                                                 " This parameter can only be specifide for \"VirtualAppliance\" next hops.")]
        public string NextHopIpAddress { get; set; }

        public override void ExecuteCmdlet()
        {
            string routeTableName = this.RouteTable.GetInstance().Name;

            Client.SetRoute(routeTableName, RouteName, AddressPrefix, NextHopType, NextHopIpAddress);
            WriteObject(Client.GetRouteTable(routeTableName, true));
        }
    }
}
