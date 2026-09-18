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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Removes a resource group.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceGroup", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupNameParameterSet), OutputType(typeof(bool))]
    public class RemoveAzureResourceGroupCmdlet : ResourceManagerCmdletBaseWithApiVersion
    {
        /// <summary>
        /// List resources group by name parameter set.
        /// </summary>
        internal const string ResourceGroupNameParameterSet = "RemoveByResourceGroupName";

        /// <summary>
        /// List resources group by Id parameter set.
        /// </summary>
        internal const string ResourceGroupIdParameterSet = "RemoveByResourceGroupId";

        [Alias("ResourceGroupName")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceGroupNameParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("ResourceGroupId", "ResourceId")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceGroupIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group Id.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource types you want to force delete.Currently, only the following is supported: forceDeletionTypes=Microsoft.Compute/virtualMachineScaleSets,Microsoft.Compute/virtualMachines,Microsoft.Databricks/workspaces")]
        public string ForceDeletionType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        protected override void OnProcessRecord()
        {
            Name = Name ?? ResourceIdentifier.FromResourceGroupIdentifier(this.Id).ResourceGroupName;

            if (string.IsNullOrWhiteSpace(ForceDeletionType))
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(ProjectResources.RemovingResourceGroup, Name),
                    ProjectResources.RemoveResourceGroupMessage,
                    Name,
                    () => ResourceManagerSdkClient.DeleteResourceGroup(Name));
            }
            else
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(ProjectResources.RemovingResourceGroup, Name),
                    ProjectResources.RemoveResourceGroupMessage,
                    Name,
                    () => NewResourceManagerSdkClient.DeleteResourceGroup(Name, ForceDeletionType));
            }

            WriteObject(true);
        }
    }
}
