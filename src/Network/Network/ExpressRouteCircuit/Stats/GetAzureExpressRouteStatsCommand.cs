//---------------------------------------------------------------------------------
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
//---------------------------------------------------------------------------------
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network		
{
    [GenericBreakingChange("Get-AzExpressRouteCircuitStats alias will be removed in an upcoming breaking change release", "2.0.0")]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCircuitStat"), OutputType(typeof(PSExpressRouteCircuitStats))]
    [Alias("Get-AzExpressRouteCircuitStats")]
    public class GetAzureExpressRouteCircuitStatsCommand : NetworkBaseCmdlet		
    {	
        [Parameter(		
            Mandatory = true,		
            ValueFromPipelineByPropertyName = true,		
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]		
        public virtual string ResourceGroupName { get; set; }

        [Alias("Name", "ResourceName")]
        [Parameter(		
            Mandatory = true,		
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Name of ExpressRoute Circuit")]
        [ResourceNameCompleter("Microsoft.Network/expressRouteCircuits", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]		
        public string ExpressRouteCircuitName { get; set; }		
		
        [Parameter(		
            Mandatory = false,		
            HelpMessage = "The PeeringType")]		
        [ValidateSet(		
           MNM.ExpressRoutePeeringType.AzurePrivatePeering,		
           MNM.ExpressRoutePeeringType.AzurePublicPeering,		
           MNM.ExpressRoutePeeringType.MicrosoftPeering,		
           IgnoreCase = true)]		
        public string PeeringType { get; set; }		
		
        public override void Execute()		
        {
            base.Execute();
            if (string.IsNullOrEmpty(PeeringType))		
            {		
                var stats = this.NetworkClient.NetworkManagementClient.ExpressRouteCircuits.GetStats(		
                    ResourceGroupName,		
                    ExpressRouteCircuitName);		
                var psStats = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteCircuitStats>(stats);		
                WriteObject(psStats, true);		
            }		
            else		
            {		
                var stats = this.NetworkClient.NetworkManagementClient.ExpressRouteCircuits.GetPeeringStats(		
                    ResourceGroupName,		
                    ExpressRouteCircuitName,		
                    PeeringType);		
                var psStats = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteCircuitStats>(stats);		
                WriteObject(psStats, true);		
            }		
        }		
    }		
}
