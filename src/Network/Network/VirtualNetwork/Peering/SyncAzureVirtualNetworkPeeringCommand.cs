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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Sync", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkPeering", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSetName), OutputType(typeof(PSVirtualNetworkPeering))]
    public class SyncAzureVirtualNetworkPeeringCommand : VirtualNetworkPeeringBase
    {
        private const string FieldsParameterSetName = "Fields";
        private const string ObjectParameterSetName = "Object";

        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The virtual network name.",
             ParameterSetName = FieldsParameterSetName)]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworks", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = FieldsParameterSetName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual network peering name.",
            ParameterSetName = FieldsParameterSetName)]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworks/virtualNetworkPeerings", "ResourceGroupName", "VirtualNetworkName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network peering",
            ParameterSetName = ObjectParameterSetName)]
        public PSVirtualNetworkPeering VirtualNetworkPeering { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSVirtualNetworkPeering existingPeering = null;

            if (this.ParameterSetName == FieldsParameterSetName)
            {
                existingPeering = this.GetVirtualNetworkPeering(this.ResourceGroupName, this.VirtualNetworkName, this.Name);
            }
            else
            {
                // Piping scenario
                existingPeering = this.VirtualNetworkPeering;
            }

            var updatedPeering = UpdateVirtualNetworkPeering(existingPeering);
            WriteObject(updatedPeering);
        }

        private PSVirtualNetworkPeering UpdateVirtualNetworkPeering(PSVirtualNetworkPeering existingPeering)
        {
            if (!this.IsVirtualNetworkPeeringPresent(existingPeering.ResourceGroupName, existingPeering.VirtualNetworkName, existingPeering.Name))
            {
                throw new AzPSArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, nameof(existingPeering.Name));
            }

            // Map to the sdk object
            var vnetPeeringModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkPeering>(existingPeering);

            //Get the remote VNet Id and then get the token for the resource Id if tis in a different tenant
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

            // Create/Update call with 'sync' param set to true
            this.VirtualNetworkPeeringClient.CreateOrUpdateWithHttpMessagesAsync(existingPeering.ResourceGroupName, existingPeering.VirtualNetworkName, existingPeering.Name, vnetPeeringModel, true.ToString(), auxAuthHeader).GetAwaiter().GetResult();

            var getVirtualNetworkPeering = this.GetVirtualNetworkPeering(existingPeering.ResourceGroupName, existingPeering.VirtualNetworkName, existingPeering.Name);

            return getVirtualNetworkPeering;
        }
    }
}
