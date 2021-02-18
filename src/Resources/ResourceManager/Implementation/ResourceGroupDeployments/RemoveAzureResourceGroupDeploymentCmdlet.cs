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

<<<<<<< HEAD
using System;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
=======
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Deletes a deployment.
    /// </summary>
<<<<<<< HEAD
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeployment", SupportsShouldProcess = true,DefaultParameterSetName = RemoveAzureResourceGroupDeploymentCmdlet.DeploymentNameParameterSet), OutputType(typeof(bool))]
=======
    [Cmdlet("Remove", AzureRMConstants.AzureRMPrefix + "ResourceGroupDeployment", SupportsShouldProcess = true,DefaultParameterSetName = RemoveAzureResourceGroupDeploymentCmdlet.DeploymentNameParameterSet), OutputType(typeof(bool))]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    public class RemoveAzureResourceGroupDeploymentCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// The deployment Id parameter set.
        /// </summary>
        internal const string DeploymentIdParameterSet = "RemoveByResourceGroupDeploymentId";

        /// <summary>
        /// The deployment name parameter set.
        /// </summary>
        internal const string DeploymentNameParameterSet = "RemoveByResourceGroupName";

        [Parameter(Position = 0, ParameterSetName = RemoveAzureResourceGroupDeploymentCmdlet.DeploymentNameParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("DeploymentName")]
        [Parameter(Position = 1, ParameterSetName = RemoveAzureResourceGroupDeploymentCmdlet.DeploymentNameParameterSet, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the deployment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("DeploymentId", "ResourceId")]
        [Parameter(ParameterSetName = RemoveAzureResourceGroupDeploymentCmdlet.DeploymentIdParameterSet, Mandatory = true,
            HelpMessage = "The fully qualified resource Id of the deployment. example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/deployments/{deploymentName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

<<<<<<< HEAD
        public override void ExecuteCmdlet()
=======
        protected override void OnProcessRecord()
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            ConfirmAction(
                ProjectResources.DeleteDeploymentMessage,
                ResourceGroupName,
                () =>
                {
<<<<<<< HEAD
                    if (string.IsNullOrEmpty(ResourceGroupName) && string.IsNullOrEmpty(Name))
                    {
                        ResourceGroupName = ResourceIdUtility.GetResourceGroupName(Id);
                        Name = ResourceIdUtility.GetResourceName(Id);
                    }

                    ResourceManagerSdkClient.DeleteDeployment(ResourceGroupName, Name);
=======
                    var resourceGroupName = !string.IsNullOrEmpty(this.ResourceGroupName) ? this.ResourceGroupName : ResourceIdUtility.GetResourceGroupName(Id);
                    var deploymentName = !string.IsNullOrEmpty(this.Name) ? this.Name : ResourceIdUtility.GetResourceName(Id);

                    ResourceManagerSdkClient.DeleteDeploymentAtResourceGroup(resourceGroupName, deploymentName);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    WriteObject(true);
                });
        }
    }
}
