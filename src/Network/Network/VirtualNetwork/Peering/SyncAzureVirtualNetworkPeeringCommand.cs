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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Sync", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkPeering"), OutputType(typeof(PSVirtualNetworkPeering))]
    public class SyncAzureVirtualNetworkPeeringCommand : VirtualNetworkPeeringBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The virtual network name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworks", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual network peering name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworks/virtualNetworkPeerings", "ResourceGroupName", "VirtualNetworkName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network peering")]
        public PSVirtualNetworkPeering VirtualNetworkPeering { get; set; }

        public override void Execute()
        {
            base.Execute();
            var existingPeering = this.VirtualNetworkPeering;
            
            if(existingPeering == null)
            {
                existingPeering = this.GetVirtualNetworkPeering(this.ResourceGroupName, this.VirtualNetworkName, this.Name);
            }
            
            var updatedPeering = UpdateVirtualNetworkPeering(existingPeering);
            WriteObject(updatedPeering);
        }

        private PSVirtualNetworkPeering UpdateVirtualNetworkPeering(PSVirtualNetworkPeering existingPeering)
        {
            if (!this.IsVirtualNetworkPeeringPresent(existingPeering.ResourceGroupName, existingPeering.VirtualNetworkName, existingPeering.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var vnetPeeringModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkPeering>(existingPeering);

            //Get the remote VNet Id nad ge then get th etoke for the resource Id if tis in a different tenant
            var remoteVirtualNetworkId = existingPeering.RemoteVirtualNetwork.Id;
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

            // Create/Update call with 'sync' param set tot true
            this.VirtualNetworkPeeringClient.CreateOrUpdateWithHttpMessagesAsync(existingPeering.ResourceGroupName, existingPeering.VirtualNetworkName, existingPeering.Name, vnetPeeringModel, true.ToString(), auxAuthHeader).GetAwaiter().GetResult();

            var getVirtualNetworkPeering = this.GetVirtualNetworkPeering(existingPeering.ResourceGroupName, existingPeering.VirtualNetworkName, existingPeering.Name);

            return getVirtualNetworkPeering;
        }
    }
}
