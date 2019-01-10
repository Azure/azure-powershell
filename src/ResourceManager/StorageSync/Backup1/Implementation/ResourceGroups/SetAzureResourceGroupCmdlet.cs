﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Updates an existing resource group.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceGroup", DefaultParameterSetName = ResourceGroupNameParameterSet), OutputType(typeof(PSResourceGroup))]
    public class SetAzureResourceGroupCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// List resources group by name parameter set.
        /// </summary>
        internal const string ResourceGroupNameParameterSet = "SetByResourceGroupName";

        /// <summary>
        /// List resources group by Id parameter set.
        /// </summary>
        internal const string ResourceGroupIdParameterSet = "SetByResourceGroupId";

        [Alias("ResourceGroupName")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceGroupNameParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("Tags")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Alias("ResourceGroupId", "ResourceId")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceGroupIdParameterSet, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource group Id.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            PSUpdateResourceGroupParameters parameters = new PSUpdateResourceGroupParameters
            {
                ResourceGroupName = Name ?? ResourceIdentifier.FromResourceGroupIdentifier(this.Id).ResourceGroupName,
                Tag = Tag,
            };

            var resourceGroup = ResourceManagerSdkClient.UpdatePSResourceGroup(parameters);
            if (resourceGroup != null)
            {
                WriteObject(resourceGroup);
            }
        }
    }
}
