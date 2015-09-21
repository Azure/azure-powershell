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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes
{
    [Cmdlet(VerbsCommon.Get, "AzureSubnetRouteTable"), OutputType(typeof(IRouteTable))]
    public class GetAzureSubnetRouteTable : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the virtual network.")]
        public string VirtualNetworkName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the subnet that will have its route table removed.")]
        public string SubnetName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether the list of routes in the route table is inlcuded")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Detailed { get; set; }

        public override void ExecuteCmdlet()
        {
            var getForSubnetResponse = Client.GetRouteTableForSubnet(VirtualNetworkName, SubnetName);

            IRouteTable routeTable = Client.GetRouteTable(getForSubnetResponse.RouteTableName, Detailed);
            WriteObject(routeTable);
        }
    }
}
