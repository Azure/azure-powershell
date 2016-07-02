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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmVirtualNetworkPeering"), OutputType(typeof(PSVirtualNetworkPeering))]
    public class SetAzureVirtualNetworkPeeringCommand : VirtualNetworkPeeringBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network peering")]
        public PSVirtualNetworkPeering VirtualNetworkPeering { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsVirtualNetworkPeeringPresent(this.VirtualNetworkPeering.ResourceGroupName, this.VirtualNetworkPeering.VirtualNetworkName, this.VirtualNetworkPeering.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var vnetPeeringModel = Mapper.Map<MNM.VirtualNetworkPeering>(this.VirtualNetworkPeering);

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkPeeringClient.CreateOrUpdate(this.VirtualNetworkPeering.ResourceGroupName, this.VirtualNetworkPeering.VirtualNetworkName, this.VirtualNetworkPeering.Name, vnetPeeringModel);

            var getVirtualNetworkPeering = this.GetVirtualNetworkPeering(this.VirtualNetworkPeering.ResourceGroupName, this.VirtualNetworkPeering.VirtualNetworkName, this.VirtualNetworkPeering.Name);

            WriteObject(getVirtualNetworkPeering);
        }
    }
}
