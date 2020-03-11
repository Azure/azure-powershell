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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualHub",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualHub))]
    public class UpdateAzureRmVirtualHubCommand : VirtualHubBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VirtualHubName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VirtualHubId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId,
            HelpMessage = "The resource id of the Virtual hub to be modified.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("VirtualHub")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The Virtual hub object to be modified.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualHub InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The address space string for this virtual hub.")]
        public string AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The hub virtual network connections associated with this Virtual Hub.")]
        public PSHubVirtualNetworkConnection[] HubVnetConnection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The route table associated with this Virtual Hub.")]
        public PSVirtualHubRouteTable RouteTable { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The sku of the Virtual Hub.")]
        [PSArgumentCompleter("Basic", "Standard")]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            PSVirtualHub virtualHubToUpdate = null;
            Dictionary<string, List<string>> auxAuthHeader = null;

            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                virtualHubToUpdate = this.InputObject;
                this.ResourceGroupName = virtualHubToUpdate.ResourceGroupName;
                this.Name = virtualHubToUpdate.Name;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    this.Name = parsedResourceId.ResourceName;
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                virtualHubToUpdate = this.GetVirtualHub(this.ResourceGroupName, this.Name);
            }
            
            if (virtualHubToUpdate == null)
            {
                throw new PSArgumentException(Properties.Resources.VirtualHubToUpdateNotFound);
            }

            //// Update address prefix, if specified
            if (!string.IsNullOrWhiteSpace(this.AddressPrefix))
            {
                virtualHubToUpdate.AddressPrefix = this.AddressPrefix;
            }

            //// HubVirtualNetworkConnections
            if (this.HubVnetConnection != null)
            {
                virtualHubToUpdate.VirtualNetworkConnections = new List<PSHubVirtualNetworkConnection>();
                virtualHubToUpdate.VirtualNetworkConnections.AddRange(this.HubVnetConnection);

                // get auth headers for cross-tenant hubvnet conn
                List<string> resourceIds = new List<string>();
                foreach (var connection in this.HubVnetConnection)
                {
                    resourceIds.Add(connection.RemoteVirtualNetwork.Id);
                }

                var auxHeaderDictionary = GetAuxilaryAuthHeaderFromResourceIds(resourceIds);
                if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
                {
                    auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
                }
            }

            //// VirtualHubRouteTable
            if (this.RouteTable != null)
            {
                virtualHubToUpdate.RouteTable = this.RouteTable;
            }

            if (!string.IsNullOrWhiteSpace(this.Sku))
            {
                virtualHubToUpdate.Sku = this.Sku;
            }

            //// Update the virtual hub
            ConfirmAction(
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                        WriteObject(this.CreateOrUpdateVirtualHub(
                            this.ResourceGroupName,
                            this.Name,
                            virtualHubToUpdate,
                            this.Tag,
                            auxAuthHeader));
                    });
        }
    }
}
