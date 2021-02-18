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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.Azure.Commands.ResourceManager.Common;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Deletes a deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, AzureRMConstants.AzureRMPrefix + "TenantDeployment", SupportsShouldProcess = true,
        DefaultParameterSetName = RemoveAzureTenantDeploymentCmdlet.DeploymentNameParameterSet), OutputType(typeof(bool))]
    public class RemoveAzureTenantDeploymentCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// The deployment Id parameter set.
        /// </summary>
        internal const string DeploymentIdParameterSet = "RemoveByDeploymentId";

        /// <summary>
        /// The deployment name parameter set.
        /// </summary>
        internal const string DeploymentNameParameterSet = "RemoveByDeploymentName";

        /// <summary>
        /// The input object parameter set.
        /// </summary>
        internal const string InputObjectParameterSet = "RemoveByInputObject";

        [Alias("DeploymentName")]
        [Parameter(Position = 0, ParameterSetName = RemoveAzureTenantDeploymentCmdlet.DeploymentNameParameterSet,
            Mandatory = true, HelpMessage = "The name of the deployment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("DeploymentId", "ResourceId")]
        [Parameter(ParameterSetName = RemoveAzureTenantDeploymentCmdlet.DeploymentIdParameterSet,
            Mandatory = true, HelpMessage = "The fully qualified resource Id of the deployment. example: /providers/Microsoft.Resources/deployments/{deploymentName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(ParameterSetName = RemoveAzureTenantDeploymentCmdlet.InputObjectParameterSet,
            Mandatory = true, ValueFromPipeline = true, HelpMessage = "The deployment object.")]
        public PSDeployment InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        protected override void OnProcessRecord()
        {
            ConfirmAction(
                ProjectResources.DeleteDeploymentMessage,
                Name,
                () =>
                {
                    var options = new FilterDeploymentOptions(DeploymentScopeType.Tenant)
                    {
                        DeploymentName = !string.IsNullOrEmpty(this.Name)
                            ? this.Name
                            : !string.IsNullOrEmpty(this.Id) ? ResourceIdUtility.GetDeploymentName(this.Id) : this.InputObject.DeploymentName
                    };

                    this.ResourceManagerSdkClient.DeleteDeploymentAtTenantScope(options.DeploymentName);

                    if (this.PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}