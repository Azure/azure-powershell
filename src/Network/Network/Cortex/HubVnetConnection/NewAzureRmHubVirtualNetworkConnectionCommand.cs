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
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualHubVnetConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByRemoteVirtualNetworkObject,
        SupportsShouldProcess = true),
        OutputType(typeof(PSHubVirtualNetworkConnection))]
    public class NewHubVirtualNetworkConnectionCommand : HubVnetConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByRemoteVirtualNetworkResourceId,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByRemoteVirtualNetworkObject,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualHubName", "ParentVirtualHubName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByRemoteVirtualNetworkResourceId,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByRemoteVirtualNetworkObject,
            HelpMessage = "The resource group name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs", "ResourceGroupName")]
        public string ParentResourceName { get; set; }

        [Alias("VirtualHub", "ParentVirtualHub")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByRemoteVirtualNetworkObject,
            HelpMessage = "The parent resource.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByRemoteVirtualNetworkResourceId,
            HelpMessage = "The parent resource.")]
        public PSVirtualHub ParentObject { get; set; }

        [Alias("VirtualHubId", "ParentVirtualHubId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByRemoteVirtualNetworkObject,
            HelpMessage = "The parent resource.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByRemoteVirtualNetworkResourceId,
            HelpMessage = "The parent resource.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        public string ParentResourceId { get; set; }

        [Alias("ResourceName", "HubVirtualNetworkConnectionName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByRemoteVirtualNetworkObject,
            HelpMessage = "The remote virtual network to which this hub virtual network connection is connected.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByRemoteVirtualNetworkObject,
            HelpMessage = "The remote virtual network to which this hub virtual network connection is connected.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByRemoteVirtualNetworkObject,
            HelpMessage = "The remote virtual network to which this hub virtual network connection is connected.")]
        [ResourceGroupCompleter]
        public PSVirtualNetwork RemoteVirtualNetwork { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByRemoteVirtualNetworkResourceId,
            HelpMessage = "The remote virtual network to which this hub virtual network connection is connected.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByRemoteVirtualNetworkResourceId,
            HelpMessage = "The remote virtual network to which this hub virtual network connection is connected.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByRemoteVirtualNetworkResourceId,
            HelpMessage = "The remote virtual network to which this hub virtual network connection is connected.")]
        [ResourceIdCompleter("Microsoft.Network/virtualNetworks")]
        public string RemoteVirtualNetworkId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable internet security for this connection")]
        public SwitchParameter EnableInternetSecurity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            Dictionary<string, List<string>> auxAuthHeader = null;

            if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualHubObject))
            {
                this.ResourceGroupName = this.ParentObject.ResourceGroupName;
                this.ParentResourceName = this.ParentObject.Name;
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualHubResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ResourceName;
            }

            if (this.IsHubVnetConnectionPresent(this.ResourceGroupName, this.ParentResourceName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ChildResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName, this.ParentResourceName));
            }

            //// Get the virtual hub - this will throw not found if the resource does not exist
            PSVirtualHub parentVirtualHub = this.GetVirtualHub(this.ResourceGroupName, this.ParentResourceName);
            if (parentVirtualHub == null)
            {
                throw new PSArgumentException(Properties.Resources.ParentVirtualHubNotFound);
            }

            PSHubVirtualNetworkConnection hubVnetConnection = new PSHubVirtualNetworkConnection();
            hubVnetConnection.Name = this.Name;
            hubVnetConnection.EnableInternetSecurity = this.EnableInternetSecurity.IsPresent;

            //// Resolve the remote virtual network
            //// Let's not try to resolve this since this can be in other RG/Sub/Location
            if (ParameterSetName.Contains(CortexParameterSetNames.ByRemoteVirtualNetworkObject))
            {
                hubVnetConnection.RemoteVirtualNetwork = new PSResourceId() { Id = this.RemoteVirtualNetwork.Id };
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByRemoteVirtualNetworkResourceId))
            {
                hubVnetConnection.RemoteVirtualNetwork = new PSResourceId() { Id = this.RemoteVirtualNetworkId };
            }
            
            if (parentVirtualHub.VirtualNetworkConnections == null)
            {
                parentVirtualHub.VirtualNetworkConnections = new List<PSHubVirtualNetworkConnection>();
            }

            List<string> resourceIds = new List<string>();
            resourceIds.Add(hubVnetConnection.RemoteVirtualNetwork.Id);
            var auxHeaderDictionary = GetAuxilaryAuthHeaderFromResourceIds(resourceIds);
            if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
            {
                auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
            }

            parentVirtualHub.VirtualNetworkConnections.Add(hubVnetConnection);
            
            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    this.CreateOrUpdateVirtualHub(this.ResourceGroupName, this.ParentResourceName, parentVirtualHub, parentVirtualHub.Tag, auxAuthHeader);
                    var createdVirtualHub = this.GetVirtualHub(this.ResourceGroupName, this.ParentResourceName);

                    WriteObject(createdVirtualHub.VirtualNetworkConnections.FirstOrDefault(hubConnection => hubConnection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)));
                });
        }
    }
}
