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
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + Constants.BastionResourceName,
        DefaultParameterSetName = BastionParameterSetNames.ByResourceGroupName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]

    public class RemoveAzBastionCommand : BastionBaseCmdlet
    {
        [Parameter(
            ParameterSetName = BastionParameterSetNames.ByResourceGroupName,
            Mandatory = true,
            HelpMessage = "The resource group name where bastion exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "BastionName")]
        [Parameter(
            ParameterSetName = BastionParameterSetNames.ByResourceGroupName,
            Mandatory = true,
            HelpMessage = "The bastion resource name to be deleted.")]
        [ResourceNameCompleter(Constants.BastionResourceType, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("Bastion", "BastionObject")]
        [Parameter(
            ParameterSetName = BastionParameterSetNames.ByBastionObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Bastion object to be deleted.")]
        [ValidateNotNullOrEmpty]
        public PSBastion InputObject { get; set; }

        [Alias("BastionId")]
        [Parameter(
            ParameterSetName = BastionParameterSetNames.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the Bastion to be deleted.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter(Constants.BastionResourceType)]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(BastionParameterSetNames.ByBastionObject, StringComparison.OrdinalIgnoreCase))
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(BastionParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            base.Execute();

            ConfirmAction(
                    this.Force.IsPresent,
                    string.Empty,
                    Properties.Resources.RemoveResourceMessage,
                    this.Name,
                    () =>
                    {
                        this.BastionClient.Delete(this.ResourceGroupName, this.Name);

                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
        }
    }
}
