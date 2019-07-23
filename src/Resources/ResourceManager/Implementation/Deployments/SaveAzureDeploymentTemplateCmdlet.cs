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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Saves the deployment template to a file on disk.
    /// </summary>
    [Cmdlet(VerbsData.Save, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeploymentTemplate", SupportsShouldProcess = true,
        DefaultParameterSetName = SaveAzureDeploymentTemplateCmdlet.SubscriptionParameterSetWithDeploymentName), OutputType(typeof(PSTemplatePath))]
    public class SaveAzureDeploymentTemplateCmdlet : ResourceManagerCmdletBase
    {
        internal const string ResourceGroupParameterSetWithDeploymentName = "ResourceGroupWithDeploymentName";
        internal const string SubscriptionParameterSetWithDeploymentName = "SubscriptionWithDeploymentName";
        internal const string ManagementGroupParameterSetWithDeploymentName = "ManagementGroupWithDeploymentName";
        internal const string TenantParameterSetWithDeploymentName = "TenantWithDeploymentName";

        internal const string DeploymentObjectParameterSet = "SaveByDeploymentObject";

        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "Get deployment at tenant scope if specified.")]
        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.DeploymentObjectParameterSet, Mandatory = false,
            HelpMessage = "Get deployment at tenant scope if specified.")]
        public SwitchParameter Tenant { get; set; }

        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The management group id.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the deployment name parameter.
        /// </summary>
        [Alias("Name")]
        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.SubscriptionParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName { get; set; }

        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.DeploymentObjectParameterSet, Mandatory = true,
            ValueFromPipeline = true, HelpMessage = "The deployment object.")]
        public PSDeployment DeploymentObject { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The output path of the template file.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the force parameter.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();

            var deploymentName = this.GetDeploymetName();
            var managementGroupId = this.GetManagementGroupId();
            var resourceGroupName = this.GetResourceGroupName();

            if (ShouldProcess(deploymentName, VerbsData.Save))
            {
                var template = this.GetDeploymentTemplate(this.Tenant, managementGroupId, resourceGroupName, deploymentName);

                string path = FileUtility.SaveTemplateFile(
                    templateName: deploymentName,
                    contents: template,
                    outputPath:
                        string.IsNullOrEmpty(this.Path)
                            ? System.IO.Path.Combine(CurrentPath(), deploymentName)
                            : this.TryResolvePath(this.Path),
                    overwrite: this.Force,
                    shouldContinue: ShouldContinue);

                WriteObject(new PSTemplatePath() { Path = path });
            }
        }

        private string GetDeploymentTemplate(bool isTenantDeployment, string managementGroupId, string resourceGroupName, string deploymentName)
        {
            if (isTenantDeployment)
            {
                return ResourceManagerSdkClient.GetDeploymentTemplateAtTenantScope(deploymentName);
            }
            else if (!string.IsNullOrEmpty(managementGroupId))
            {
                return ResourceManagerSdkClient.GetDeploymentTemplateAtManagementGroup(managementGroupId, deploymentName);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName))
            {
                return ResourceManagerSdkClient.GetDeploymentTemplateAtResourceGroup(resourceGroupName, deploymentName);
            }
            else
            {
                return ResourceManagerSdkClient.GetDeploymentTemplateAtSubscrpitionScope(deploymentName);
            }
        }

        private string GetDeploymetName()
        {
            if (!string.IsNullOrEmpty(this.DeploymentName))
            {
                return this.DeploymentName;
            }
            else
            {
                return this.DeploymentObject.DeploymentName;
            }
        }

        private string GetManagementGroupId()
        {
            if (!string.IsNullOrEmpty(this.ManagementGroupId))
            {
                return this.ManagementGroupId;
            }
            else if (this.DeploymentObject != null)
            {
                return this.DeploymentObject.ManagementGroupId;
            }

            return null;
        }

        private string GetResourceGroupName()
        {
            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                return this.ResourceGroupName;
            }
            else if (this.DeploymentObject != null)
            {
                return this.DeploymentObject.ResourceGroupName;
            }

            return null;
        }
    }
}
