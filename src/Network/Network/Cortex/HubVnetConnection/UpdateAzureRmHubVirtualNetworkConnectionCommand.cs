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

    [Cmdlet("Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualHubVnetConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByHubVirtualNetworkConnectionName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSHubVirtualNetworkConnection))]
    public class UpdateAzureRmHubVirtualNetworkConnectionCommand : HubVnetConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByHubVirtualNetworkConnectionName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("VirtualHubName", "ParentVirtualHubName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByHubVirtualNetworkConnectionName,
            HelpMessage = "The parent resource name.")]
        [ResourceGroupCompleter]
        public string ParentResourceName { get; set; }

        [Alias("ResourceName", "HubVirtualNetworkConnectionName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByHubVirtualNetworkConnectionName,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Alias("HubVirtualNetworkConnection")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByHubVirtualNetworkConnectionObject,
            HelpMessage = "The hub virtual network connection resource to modify.")]
        public PSHubVirtualNetworkConnection InputObject { get; set; }

        [Alias("HubVirtualNetworkConnectionId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId,
            HelpMessage = "The resource id of the hub virtual network connection resource to modify.")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable internet security for this connection.")]
        public bool? EnableInternetSecurity { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The routing configuration for this HubVirtualNetwork connection")]
        public PSRoutingConfiguration RoutingConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            Dictionary<string, List<string>> auxAuthHeader = null;

            //// Resolve the VirtualHub
            if (ParameterSetName.Equals(CortexParameterSetNames.ByHubVirtualNetworkConnectionObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceId = this.InputObject.Id;

                if (string.IsNullOrWhiteSpace(this.ResourceId))
                {
                    throw new PSArgumentException(Properties.Resources.HubVnetConnectionNotFound);
                }

                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }

            var connectionToModify = this.HubVirtualNetworkConnectionsClient.Get(this.ResourceGroupName, this.ParentResourceName, this.Name);
            if (connectionToModify == null)
            {
                throw new PSArgumentException(Properties.Resources.HubVnetConnectionNotFound);
            }

            if (this.EnableInternetSecurity.HasValue)
            {
                connectionToModify.EnableInternetSecurity = this.EnableInternetSecurity.Value;
            }

            if (this.RoutingConfiguration != null)
            {
                connectionToModify.RoutingConfiguration = NetworkResourceManagerProfile.Mapper.Map<MNM.RoutingConfiguration>(RoutingConfiguration);
            }

            List<string> resourceIds = new List<string>();
            resourceIds.Add(connectionToModify.RemoteVirtualNetwork.Id);
            var auxHeaderDictionary = GetAuxilaryAuthHeaderFromResourceIds(resourceIds);
            if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
            {
                auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
            }

            ConfirmAction(
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteObject(this.CreateOrUpdateHubVirtualNetworkConnection(this.ResourceGroupName, this.ParentResourceName, this.Name, connectionToModify, auxAuthHeader));
                    });
        }
    }
}