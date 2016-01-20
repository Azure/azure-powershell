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
using Microsoft.Azure.Commands.Resources.Models;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources.ResourceGroups
{
    /// <summary>
    /// Deletes a deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmResourceGroupDeployment", DefaultParameterSetName = RemoveAzureResourceGroupDeploymentCommand.DeploymentNameParameterSet), OutputType(typeof(bool))]
    [CliCommandAlias("resource group deployment rm")]
    public class RemoveAzureResourceGroupDeploymentCommand : ResourcesBaseCmdlet
    {
        /// <summary>
        /// The deployment Id parameter set.
        /// </summary>
        internal const string DeploymentIdParameterSet = "The deployment Id parameter set.";

        /// <summary>
        /// The deployment name parameter set.
        /// </summary>
        internal const string DeploymentNameParameterSet = "The deployment name parameter set.";

        [Parameter(Position = 0, ParameterSetName = RemoveAzureResourceGroupDeploymentCommand.DeploymentNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        [Alias("group", "g")]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = RemoveAzureResourceGroupDeploymentCommand.DeploymentNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the deployment.")]
        [ValidateNotNullOrEmpty]
        [Alias("DeploymentName","n")]
        public string Name { get; set; }

        [Alias("DeploymentId", "ResourceId")]
        [Parameter(ParameterSetName = RemoveAzureResourceGroupDeploymentCommand.DeploymentIdParameterSet, Mandatory = true, HelpMessage = "The fully qualified resource Id of the deployment. example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/deployments/{deploymentName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not confirm the remove.")]
        [Alias("f")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            if(string.IsNullOrEmpty(ResourceGroupName) && string.IsNullOrEmpty(Name))
            {
                ResourceGroupName = ResourceIdUtility.GetResourceGroupName(Id);
                Name = ResourceIdUtility.GetResourceName(Id);
            }
            ConfirmAction(
                Force.IsPresent,
                string.Format(ProjectResources.DeleteResourceGroupDeployment, Name),
                ProjectResources.DeleteResourceGroupDeploymentMessage,
                ResourceGroupName,
                () => ResourcesClient.DeleteDeployment(ResourceGroupName, Name));

            WriteObject(true);

        }
    }
}
