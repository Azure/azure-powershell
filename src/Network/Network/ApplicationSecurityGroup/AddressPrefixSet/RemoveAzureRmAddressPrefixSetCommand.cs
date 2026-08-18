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

    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AddressPrefixSet",
        DefaultParameterSetName = ByApplicationSecurityGroupName,
        SupportsShouldProcess = true,
        HelpUri = "https://learn.microsoft.com/powershell/module/az.network/remove-azaddressprefixset"),
        OutputType(typeof(bool))]
    public class RemoveAzureRmAddressPrefixSetCommand : AddressPrefixSetBaseCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = ByApplicationSecurityGroupName, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentName", "ParentResourceName")]
        [Parameter(Mandatory = true, ParameterSetName = ByApplicationSecurityGroupName, HelpMessage = "The application security group name.")]
        [ValidateNotNullOrEmpty]
        public string ApplicationSecurityGroupName { get; set; }

        [Alias("ResourceName", "AddressPrefixSetName")]
        [Parameter(Mandatory = true, ParameterSetName = ByApplicationSecurityGroupName, HelpMessage = "The address prefix set name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("AddressPrefixSet")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByAddressPrefixSetObject, HelpMessage = "The address prefix set to delete.")]
        public PSAddressPrefixSet InputObject { get; set; }

        [Alias("AddressPrefixSetId")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByAddressPrefixSetResourceId, HelpMessage = "The address prefix set resource ID.")]
        [ResourceIdCompleter("Microsoft.Network/applicationSecurityGroups/addressPrefixSets")]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return true when the operation completes.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            this.ResolveResource();
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, this.Name),
                Properties.Resources.RemoveResourceMessage,
                this.Name,
                () =>
                {
                    this.AddressPrefixSetClient.Delete(this.ResourceGroupName, this.ApplicationSecurityGroupName, this.Name);
                    if (this.PassThru.IsPresent)
                    {
                        this.WriteObject(true);
                    }
                });
        }

        private void ResolveResource()
        {
            if (this.ParameterSetName.Equals(ByAddressPrefixSetObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceId = this.InputObject.Id;
                if (string.IsNullOrWhiteSpace(this.ResourceId))
                {
                    throw new PSArgumentException("The address prefix set input object must contain a resource ID.");
                }
            }

            if (!string.IsNullOrWhiteSpace(this.ResourceId))
            {
                var resourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceId.ResourceGroupName;
                this.ApplicationSecurityGroupName = resourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = resourceId.ResourceName;
            }
        }
    }
}
