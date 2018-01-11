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

using System.Management.Automation;
using Microsoft.Azure.Management.MachineLearningCompute;
using Microsoft.Azure.Commands.MachineLearningCompute.Models;
using System;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.MachineLearningCompute.Cmdlets
{
    [Cmdlet(VerbsCommon.Remove, CmdletSuffix, SupportsShouldProcess = true, DefaultParameterSetName = CmdletParametersParameterSet)]
    [OutputType(typeof(void))]
    public class RemoveAzureRmMlOpCluster : MachineLearningComputeCmdletBase
    {
        protected const string CmdletParametersParameterSet = "RemoveByNameAndResourceGroup";

        protected const string ObjectParameterSet = "RemoveByInputObject";

        protected const string ResourceIdParameterSet = "RemoveByResourceId";

        [Parameter(ParameterSetName = CmdletParametersParameterSet,
            Mandatory = true, 
            HelpMessage = ResourceGroupParameterHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = CmdletParametersParameterSet,
            Mandatory = true, 
            HelpMessage = NameParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ObjectParameterSet,
            Mandatory = true, 
            ValueFromPipeline = true,
            HelpMessage = ClusterObjectParameterHelpMessage)]
        [Alias(ClusterInputObjectAlias)]
        public PSOperationalizationCluster InputObject { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = ResourceIdParameterHelpMessage)]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = IncludeAllResourcesParameterHelpMessage)]
        public SwitchParameter IncludeAllResources { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.Equals(this.ParameterSetName, ObjectParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;
            }
            else if (string.Equals(this.ParameterSetName, ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;
            }

            var shouldProcessMessage = @"Deleting operationalization cluster";

            if (IncludeAllResources.IsPresent)
            {
                var clusterToDelete = MachineLearningComputeManagementClient.OperationalizationClusters.Get(ResourceGroupName, Name);
                var managedByResourceGroup = new ResourceIdentifier(clusterToDelete.ContainerRegistry.ResourceId).ResourceGroupName;

                shouldProcessMessage += $" and supporting resource group {managedByResourceGroup}. All resources in resource group {managedByResourceGroup} will be deleted.";
            }

            if (ShouldProcess(this.Name, shouldProcessMessage))
            {
                try
                {
                    MachineLearningComputeManagementClient.OperationalizationClusters.Delete(ResourceGroupName, Name, IncludeAllResources.IsPresent);
                }
                catch (CloudException e)
                {
                    HandleNestedExceptionMessages(e);
                }
            }
        }
    }
}
