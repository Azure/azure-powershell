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
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    [CmdletDeprecation(ReplacementCmdletName = "Add-AzVirtualHubRouteTable")]
    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualHubRouteTable",
        SupportsShouldProcess = false),
        OutputType(typeof(PSVirtualHubRouteTable))]
    public class NewAzureRmVirtualHubRouteTableCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "List of virtual hub routes.")]
        public PSVirtualHubRoute[] Route { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Since this cmdlet and the VirtualHubRouteTable property of
            // hub will be deprecated, we will rename this route table to 
            // called defaultRouteTable and it will be attached to All_Branches
            var virtualHubRouteTable = new PSVirtualHubRouteTable { 
                Routes = this.Route == null ? new List<PSVirtualHubRoute>() : this.Route?.ToList(),
                Name = "defaultRouteTable",
                Connections = new List<string>() { "All_Branches" }
            };

            WriteObject(virtualHubRouteTable);
        }
    }
}