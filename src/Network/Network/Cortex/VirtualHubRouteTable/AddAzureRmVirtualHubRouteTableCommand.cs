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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Add,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualHubRouteTable",
        SupportsShouldProcess = false),
        OutputType(typeof(PSVirtualHubRouteTable))]
    public class AddAzureRmVirtualHubRouteTableCommand : VirtualHubRouteTableBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the route table.")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of virtual hub routes.")]
        public PSVirtualHubRoute[] Route { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of connections this route table is attached to.")]
        public string[] Connection { get; set; }

        public override void Execute()
        {
            base.Execute();

            var virtualHubRouteTable = new PSVirtualHubRouteTable
            {
                Name = this.Name,
                Routes = this.Route == null ? new List<PSVirtualHubRoute>() : this.Route?.ToList(),
                Connections = this.Connection == null ? new List<string>() : this.Connection.ToList()
            };

            WriteObject(virtualHubRouteTable);
        }
    }
}
