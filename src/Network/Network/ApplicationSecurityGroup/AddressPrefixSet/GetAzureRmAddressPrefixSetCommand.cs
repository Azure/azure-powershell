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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AddressPrefixSet",
        DefaultParameterSetName = ByApplicationSecurityGroupName,
        HelpUri = "https://learn.microsoft.com/powershell/module/az.network/get-azaddressprefixset"),
        OutputType(typeof(PSAddressPrefixSet))]
    public class GetAzureRmAddressPrefixSetCommand : AddressPrefixSetBaseCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = ByApplicationSecurityGroupName, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentName", "ParentResourceName")]
        [Parameter(Mandatory = true, ParameterSetName = ByApplicationSecurityGroupName, HelpMessage = "The application security group name.")]
        [ResourceNameCompleter("Microsoft.Network/applicationSecurityGroups", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ApplicationSecurityGroupName { get; set; }

        [Alias("ParentObject")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByApplicationSecurityGroupObject, HelpMessage = "The application security group.")]
        public PSApplicationSecurityGroup ApplicationSecurityGroup { get; set; }

        [Alias("ParentResourceId")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByApplicationSecurityGroupResourceId, HelpMessage = "The application security group resource ID.")]
        [ResourceIdCompleter("Microsoft.Network/applicationSecurityGroups")]
        public string ApplicationSecurityGroupResourceId { get; set; }

        [Alias("ResourceName", "AddressPrefixSetName")]
        [Parameter(Mandatory = false, HelpMessage = "The address prefix set name.")]
        [ResourceNameCompleter("Microsoft.Network/applicationSecurityGroups/addressPrefixSets", "ResourceGroupName", "ApplicationSecurityGroupName")]
        [SupportsWildcards]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();
            this.ResolveParent();
            if (this.ShouldGetByName(this.ResourceGroupName, this.Name))
            {
                this.WriteObject(this.GetAddressPrefixSet(this.ResourceGroupName, this.ApplicationSecurityGroupName, this.Name));
            }
            else
            {
                this.WriteObject(
                    this.SubResourceWildcardFilter(
                        this.Name,
                        this.ListAddressPrefixSets(this.ResourceGroupName, this.ApplicationSecurityGroupName)),
                    true);
            }
        }

        private void ResolveParent()
        {
            if (this.ParameterSetName.Equals(ByApplicationSecurityGroupObject, StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(this.ApplicationSecurityGroup.Id))
                {
                    throw new PSArgumentException("The application security group input object must contain a resource ID.");
                }

                var parentId = new ResourceIdentifier(this.ApplicationSecurityGroup.Id);
                this.ResourceGroupName = parentId.ResourceGroupName;
                this.ApplicationSecurityGroupName = parentId.ResourceName;
            }
            else if (this.ParameterSetName.Equals(ByApplicationSecurityGroupResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parentId = new ResourceIdentifier(this.ApplicationSecurityGroupResourceId);
                this.ResourceGroupName = parentId.ResourceGroupName;
                this.ApplicationSecurityGroupName = parentId.ResourceName;
            }
        }
    }
}
