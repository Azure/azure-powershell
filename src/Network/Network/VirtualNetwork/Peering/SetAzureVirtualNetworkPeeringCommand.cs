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
using Microsoft.Azure.Management.Network;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkPeering"), OutputType(typeof(PSVirtualNetworkPeering))]
    public class SetAzureVirtualNetworkPeeringCommand : VirtualNetworkPeeringBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network peering")]
        public PSVirtualNetworkPeering VirtualNetworkPeering { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsVirtualNetworkPeeringPresent(this.VirtualNetworkPeering.ResourceGroupName, this.VirtualNetworkPeering.VirtualNetworkName, this.VirtualNetworkPeering.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var vnetPeeringModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkPeering>(this.VirtualNetworkPeering);

            //Get the remote VNet Id nad ge then get th etoke for the resource Id if tis in a different tenant
            var remoteVirtualNetworkId = this.VirtualNetworkPeering.RemoteVirtualNetwork.Id;
            Dictionary<string, List<string>> auxAuthHeader = null;
            if (remoteVirtualNetworkId != null)
            {
                List<string> resourceIds = new List<string>();
                resourceIds.Add(remoteVirtualNetworkId);
                var auxHeaderDictionary = GetAuxilaryAuthHeaderFromResourceIds(resourceIds);
                if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
                {
                    auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
                }
            }

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkPeeringClient.CreateOrUpdateWithHttpMessagesAsync(this.VirtualNetworkPeering.ResourceGroupName, this.VirtualNetworkPeering.VirtualNetworkName, this.VirtualNetworkPeering.Name, vnetPeeringModel, null, auxAuthHeader).GetAwaiter().GetResult();

            var getVirtualNetworkPeering = this.GetVirtualNetworkPeering(this.VirtualNetworkPeering.ResourceGroupName, this.VirtualNetworkPeering.VirtualNetworkName, this.VirtualNetworkPeering.Name);

            WriteObject(getVirtualNetworkPeering);
        }
    }
}
