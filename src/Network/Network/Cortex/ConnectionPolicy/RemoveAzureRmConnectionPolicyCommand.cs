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
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;

    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ConnectionPolicy",
        DefaultParameterSetName = CortexParameterSetNames.ByConnectionPolicyName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzureRmConnectionPolicyCommand : ConnectionPolicyBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByConnectionPolicyName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualHubName", "ParentVirtualHubName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByConnectionPolicyName,
            HelpMessage = "The parent resource name.")]
        public string ParentResourceName { get; set; }

        [Alias("ResourceName", "ConnectionPolicyName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByConnectionPolicyName,
            HelpMessage = "Name of the connection policy resource.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "Name of the connection policy resource.")]
        public string Name { get; set; }

        [Alias("VirtualHub", "ParentVirtualHub")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The parent virtual hub object.")]
        public PSVirtualHub ParentObject { get; set; }

        [Alias("ConnectionPolicy")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByConnectionPolicyObject,
            HelpMessage = "The connection policy resource to delete.")]
        public PSConnectionPolicy InputObject { get; set; }

        [Alias("ConnectionPolicyId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByConnectionPolicyResourceId,
            HelpMessage = "The resource id of the connection policy to delete.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs/connectionPolicies")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to delete a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ParameterSetName.Equals(CortexParameterSetNames.ByConnectionPolicyObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceId = this.InputObject.Id;
                if (string.IsNullOrWhiteSpace(this.ResourceId))
                {
                    throw new PSArgumentException(Properties.Resources.ConnectionPolicyNotFound);
                }

                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByConnectionPolicyResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    this.Name = parsedResourceId.ResourceName;
                }
                else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
                {
                    var parentResourceId = this.ParentObject.Id;
                    var parsedParentResourceId = new ResourceIdentifier(parentResourceId);
                    this.ResourceGroupName = parsedParentResourceId.ResourceGroupName;
                    this.ParentResourceName = parsedParentResourceId.ResourceName;
                }
            }

            ConfirmAction(
                this.Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, this.Name),
                Properties.Resources.RemoveResourceMessage,
                this.Name,
                () =>
                {
                    this.ConnectionPolicyClient.Delete(this.ResourceGroupName, this.ParentResourceName, this.Name);
                    if (this.PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
