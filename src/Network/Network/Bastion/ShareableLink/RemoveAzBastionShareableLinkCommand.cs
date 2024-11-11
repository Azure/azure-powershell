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

namespace Microsoft.Azure.Commands.Network.Bastion
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.Network.Models.Bastion;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;

    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + Constants.BastionResourceName + Constants.ShareableLink,
        DefaultParameterSetName = BastionParameterSetNames.ByResourceGroupName + BastionParameterSetNames.ByName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzBastionShareableLinkCommand : BastionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByResourceGroupName + BastionParameterSetNames.ByName,
            HelpMessage = "The resource group name where Bastion resource exists")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "BastionName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByResourceGroupName + BastionParameterSetNames.ByName,
            HelpMessage = "The Bastion resource name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Bastion", "ResourceGroupName")]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ParameterSetName = BastionParameterSetNames.ByResourceId,
           HelpMessage = "The Bastion Resource ID")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByBastionObject,
            HelpMessage = "Bastion Object")]
        [ValidateNotNullOrEmpty]
        public PSBastion InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "ID of the VMs for which Bastion shareable links should be deleted")]
        [ValidateNotNullOrEmpty]
        public List<string> TargetVmId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            ConfirmAction(Force.IsPresent,
                Properties.Resources.BastionShareableLinkConfirmRemove,
                Properties.Resources.BastionShareableLinkRemoving,
                Name, () =>
                {
                    if (ParameterSetName.Equals(BastionParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
                    {
                        var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                        this.Name = parsedResourceId.ResourceName;
                        this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    }
                    else if (ParameterSetName.Equals(BastionParameterSetNames.ByBastionObject, StringComparison.OrdinalIgnoreCase))
                    {
                        this.Name = this.InputObject.Name;
                        this.ResourceGroupName = this.InputObject.ResourceGroupName;
                    }

                    if (!this.TryGetBastion(this.ResourceGroupName, this.Name, out PSBastion bastion))
                    {
                        throw new ItemNotFoundException(string.Format(Properties.Resources.ResourceNotFound, this.Name));
                    }

                    if (!bastion.EnableShareableLink.Value)
                    {
                        throw new PropertyNotFoundException(Properties.Resources.BastionShareableLinkNotEnabled);
                    }

                    var psBslRequest = new PSBastionShareableLinkRequest(this.TargetVmId);
                    this.NetworkClient.NetworkManagementClient.DeleteBastionShareableLink(this.ResourceGroupName, this.Name, psBslRequest.ToSdkObject());
                    if (PassThru)
                    {
                        WriteVerbose($"Deleted Bastion shareable links for {this.TargetVmId.Count} VM IDs");
                        WriteObject(true);
                    }
                });
        }
    }
}
