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

using System;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Cancel a running deployment.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "AzureRmResourceGroupDeployment", SupportsShouldProcess = true, 
        DefaultParameterSetName = StopAzureResourceGroupDeploymentCmdlet.DeploymentNameParameterSet), OutputType(typeof(bool))]
    public class StopAzureResourceGroupDeploymentCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// The deployment Id parameter set.
        /// </summary>
        internal const string DeploymentIdParameterSet = "The deployment Id parameter set.";

        /// <summary>
        /// The deployment name parameter set.
        /// </summary>
        internal const string DeploymentNameParameterSet = "The deployment name parameter set.";

        [Parameter(Position = 0, ParameterSetName = StopAzureResourceGroupDeploymentCmdlet.DeploymentNameParameterSet, 
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("DeploymentName")]
        [Parameter(Position = 1, ParameterSetName = StopAzureResourceGroupDeploymentCmdlet.DeploymentNameParameterSet, 
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the deployment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("DeploymentId", "ResourceId")]
        [Parameter(ParameterSetName = StopAzureResourceGroupDeploymentCmdlet.DeploymentIdParameterSet, Mandatory = true, 
            HelpMessage = "The fully qualified resource Id of the deployment. example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/deployments/{deploymentName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(ResourceGroupName) && string.IsNullOrEmpty(Name))
            {
                ResourceGroupName = ResourceIdUtility.GetResourceGroupName(Id);
                Name = ResourceIdUtility.GetResourceName(Id);
            }
            ConfirmAction(
                ProjectResources.CancelResourceGroupDeploymentMessage,
                ResourceGroupName,
                () => ResourceManagerSdkClient.CancelDeployment(ResourceGroupName, Name));

            WriteObject(true);

        }
    }
}