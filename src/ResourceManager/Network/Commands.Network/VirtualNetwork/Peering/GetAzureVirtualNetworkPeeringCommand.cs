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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmVirtualNetworkPeering"), OutputType(typeof(PSVirtualNetworkPeering))]
    public class GetAzureVirtualNetworkPeeringCommand : VirtualNetworkPeeringBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The virtual network name.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }
        
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual network peering name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var vnet = this.GetVirtualNetworkPeering(this.ResourceGroupName, this.VirtualNetworkName, this.Name);

                WriteObject(vnet);
            }
            else
            {
                var vnetPeeringList = this.VirtualNetworkPeeringClient.List(this.ResourceGroupName, this.VirtualNetworkName);

                var psVnetPeerings = new List<PSVirtualNetworkPeering>();
                foreach (var virtualNetworkPeering in vnetPeeringList)
                {
                    var psVnetPeering = this.ToPsVirtualNetworkPeering(virtualNetworkPeering);
                    psVnetPeering.ResourceGroupName = this.ResourceGroupName;
                    psVnetPeering.VirtualNetworkName = this.VirtualNetworkName;
                    psVnetPeerings.Add(psVnetPeering);
                }

                WriteObject(psVnetPeerings, true);
            }
        }
    }
}
