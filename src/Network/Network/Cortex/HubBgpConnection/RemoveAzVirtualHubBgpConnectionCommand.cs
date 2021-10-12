//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;

    using System;
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "VirtualHubBgpConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzVirtualHubBgpConnectionCommand : HubBgpConnectionBaseCmdlet
    {
        [Parameter(Mandatory = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentResourceName", "ParentVirtualHubName")]
        [Parameter(Mandatory = true,
            HelpMessage = "The virtual hub name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName)]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VirtualHubName { get; set; }

        [Alias("ResourceName", "BgpConnectionName")]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName)]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject)]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs/bgpConnections", "ResourceGroupName", "VirtualHubName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("ParentObject", "ParentVirtualHub")]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual hub resource.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject)]
        [ValidateNotNull]
        public PSVirtualHub VirtualHub { get; set; }

        [Alias("VirtualHubBgpConnection")]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual hub bgp connection resource.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject)]
        [ValidateNotNull]
        public PSBgpConnection InputObject { get; set; }

        [Alias("BgpConnectionId")]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource id.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionResourceId)]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs/bgpConnections")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals(CortexParameterSetNames.ByHubBgpConnectionResourceId, StringComparison.OrdinalIgnoreCase))
            {
                this.PopulateResourceInfoFromId(this.ResourceId);
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByHubBgpConnectionObject, StringComparison.OrdinalIgnoreCase))
            {
                this.PopulateResourceInfoFromId(this.InputObject.Id);
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject))
            {
                this.ResourceGroupName = this.VirtualHub.ResourceGroupName;
                this.VirtualHubName = this.VirtualHub.Name;
            }

            this.ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, this.Name),
                Properties.Resources.RemoveResourceMessage,
                this.Name,
                () => 
                {
                    this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnection.Delete(this.ResourceGroupName, this.VirtualHubName, this.Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }

        private void PopulateResourceInfoFromId(string id)
        {
            var parsedResourceId = new ResourceIdentifier(id);
            this.ResourceGroupName = parsedResourceId.ResourceGroupName;
            this.VirtualHubName = parsedResourceId.ParentResource.Split('/').Last();
            this.Name = parsedResourceId.ResourceName;
        }
    }
}
