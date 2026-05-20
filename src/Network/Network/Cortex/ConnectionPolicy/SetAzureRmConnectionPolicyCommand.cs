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

    [Cmdlet("Set",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ConnectionPolicy",
        DefaultParameterSetName = CortexParameterSetNames.ByConnectionPolicyName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSConnectionPolicy))]
    public class SetAzureRmConnectionPolicyCommand : ConnectionPolicyBaseCmdlet
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
            HelpMessage = "The connection policy resource to modify.")]
        public PSConnectionPolicy InputObject { get; set; }

        [Alias("ConnectionPolicyId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByConnectionPolicyResourceId,
            HelpMessage = "The resource id of the connection policy to modify.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs/connectionPolicies")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable internet security for this connection policy.")]
        public SwitchParameter EnableInternetSecurity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The routing configuration for this connection policy.")]
        public PSRoutingConfiguration RoutingConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            PSConnectionPolicy connectionPolicyToUpdate = null;
            if (ParameterSetName.Equals(CortexParameterSetNames.ByConnectionPolicyObject, StringComparison.OrdinalIgnoreCase))
            {
                connectionPolicyToUpdate = this.InputObject;
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

                connectionPolicyToUpdate = this.GetConnectionPolicy(this.ResourceGroupName, this.ParentResourceName, this.Name);
            }

            if (this.EnableInternetSecurity.IsPresent)
            {
                connectionPolicyToUpdate.EnableInternetSecurity = true;
            }

            if (this.RoutingConfiguration != null)
            {
                connectionPolicyToUpdate.RoutingConfiguration = this.RoutingConfiguration;
            }

            ConfirmAction(
                Properties.Resources.SettingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(this.CreateOrUpdateConnectionPolicy(this.ResourceGroupName, this.ParentResourceName, this.Name, connectionPolicyToUpdate));
                });
        }
    }
}
