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
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCrossConnectionRouteTable"), OutputType(typeof(PSExpressRouteCircuitRoutesTable))]
    public class GetAzureRMExpressRouteCrossConnectionRouteTableCommand : ExpressRouteCrossConnectionBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The resource group name.",
            ParameterSetName = "SpecifyByParameterValues")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("Name", "ResourceName")]
        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The Name of Express Route Cross Connection",
            ParameterSetName = "SpecifyByParameterValues")]
        [ResourceNameCompleter("Microsoft.Network/expressRouteCrossConnections", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string CrossConnectionName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Express Route Cross Connection",
            ParameterSetName = "SpecifyByReference")]
        [ValidateNotNullOrEmpty]
        public PSExpressRouteCrossConnection ExpressRouteCrossConnection { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PeeringType")]
        [ValidateSet(
           MNM.ExpressRoutePeeringType.AzurePrivatePeering,
           MNM.ExpressRoutePeeringType.AzurePublicPeering,
           MNM.ExpressRoutePeeringType.MicrosoftPeering,
           IgnoreCase = true)]
        public string PeeringType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The DevicePath, can be either Primary or Secondary")]
        [ValidateSet(
            "Primary",
            "Secondary",
            IgnoreCase = true)]
        public DevicePathEnum DevicePath { get; set; }

        public override void Execute()
        {
            base.Execute();
            List<object> routeTables = null;
            if (!string.IsNullOrWhiteSpace(CrossConnectionName))
            {
                routeTables = this.ExpressRouteCrossConnectionClient
                    .ListRoutesTable(ResourceGroupName, CrossConnectionName, PeeringType, DevicePath.ToString()).Value
                    .Cast<object>().ToList();
            }
            else
            {
                routeTables = this.ExpressRouteCrossConnectionClient
                    .ListRoutesTable(ExpressRouteCrossConnection.ResourceGroupName, ExpressRouteCrossConnection.Name, PeeringType, DevicePath.ToString()).Value
                    .Cast<object>().ToList();
            }

            var psRoutes = new List<PSExpressRouteCircuitRoutesTable>();
            foreach (var routeTable in routeTables)
            {
                var psRoute = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteCircuitRoutesTable>(routeTable);
                psRoutes.Add(psRoute);
            }
            WriteObject(psRoutes, true);
        }
    }

}
