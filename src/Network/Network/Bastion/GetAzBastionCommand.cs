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
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network.Models;

    [Cmdlet(VerbsCommon.Get,
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + Constants.BastionResourceName,
         DefaultParameterSetName = BastionParameterSetNames.ListBySubscription,
         SupportsShouldProcess = true),
         OutputType(typeof(PSBastion), typeof(IEnumerable<PSBastion>))]
    public class GetAzBastionCommand : BastionBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = BastionParameterSetNames.ListByResourceGroup,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByResourceGroupName + BastionParameterSetNames.ByName,
            HelpMessage = "The resource group name where bastion resource exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ParameterSetName = BastionParameterSetNames.ByResourceId,
           HelpMessage = "The bastion Azure resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("ResourceName", "BastionName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByResourceGroupName + BastionParameterSetNames.ByName,
            HelpMessage = "The bastion resource name.")]
        [ResourceNameCompleter(Constants.BastionResourceType, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ShouldGetByName(ResourceGroupName, Name))
            {
                WriteObject(this.GetBastion(this.ResourceGroupName, this.Name));
            }
            else if (ParameterSetName.Equals(BastionParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.Name = parsedResourceId.ResourceName;
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                WriteObject(this.GetBastion(this.ResourceGroupName, this.Name));
            }
            else
            {
                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, this.ListBastions(this.ResourceGroupName)), true);
            }
        }
    }
}
