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

namespace Microsoft.Azure.Commands.MachineLearningCompute.Cmdlets
{
    [Cmdlet(VerbsCommon.Remove, CmdletSuffix, SupportsShouldProcess = true)]
    [OutputType(typeof(void))]
    public class RemoveAzureRmMlOpCluster : MachineLearningComputeCmdletBase
    {
        protected const string CmdletParametersParameterSet =
            "Remove an operationalization cluster from cmdlet input parameters.";

        protected const string ObjectParameterSet =
            "Remove an operationalization cluster from an OperationalizationCluster instance definition.";

        protected const string ResourceIdParameterSet =
            "Remove an operationalization cluster from an Azure resouce id.";

        [Parameter(ParameterSetName = CmdletParametersParameterSet,
            Mandatory = true, 
            HelpMessage = ResourceGroupParameterHelpMessage)]
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

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Name, @"Deleting operationalization cluster..."))
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

                try
                {
                    MachineLearningComputeManagementClient.OperationalizationClusters.Delete(ResourceGroupName, Name);
                }
                catch (CloudException e)
                {
                    HandleNestedExceptionMessages(e);
                }
            }
        }
    }
}
