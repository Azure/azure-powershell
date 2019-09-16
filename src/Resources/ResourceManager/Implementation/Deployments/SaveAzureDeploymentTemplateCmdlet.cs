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
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

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

        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.SubscriptionParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(ParameterSetName = SaveAzureDeploymentTemplateCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [ValidateNotNullOrEmpty]
        public DeploymentScopeType? ScopeType { get; set; }

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

            this.ValidateScopeTypeMatches();
            var deploymentFilterOptions = this.GetDeploymentFilterOptions();

            if (ShouldProcess(deploymentFilterOptions.DeploymentName, VerbsData.Save))
            {
                var template = this.GetDeploymentTemplate(deploymentFilterOptions);

                string path = FileUtility.SaveTemplateFile(
                    templateName: deploymentFilterOptions.DeploymentName,
                    contents: template,
                    outputPath:
                        string.IsNullOrEmpty(this.Path)
                            ? System.IO.Path.Combine(CurrentPath(), deploymentFilterOptions.DeploymentName)
                            : this.TryResolvePath(this.Path),
                    overwrite: this.Force,
                    shouldContinue: ShouldContinue);

                WriteObject(new PSTemplatePath() { Path = path });
            }
        }

        private string GetDeploymentTemplate(FilterDeploymentOptions options)
        {
            switch (options.ScopeType)
            {
                case DeploymentScopeType.Tenant:
                    return ResourceManagerSdkClient.GetDeploymentTemplateAtTenantScope(options.DeploymentName);

                case DeploymentScopeType.ManagementGroup:
                    return ResourceManagerSdkClient.GetDeploymentTemplateAtManagementGroup(options.ManagementGroupId, options.DeploymentName);

                case DeploymentScopeType.ResourceGroup:
                    return ResourceManagerSdkClient.GetDeploymentTemplateAtResourceGroup(options.ResourceGroupName, options.DeploymentName);

                case DeploymentScopeType.Subscription:
                default:
                    return ResourceManagerSdkClient.GetDeploymentTemplateAtSubscrpitionScope(options.DeploymentName);
            }
        }

        private void ValidateScopeTypeMatches()
        {
            if (this.ScopeType.HasValue)
            {
                if (this.ScopeType == DeploymentScopeType.ResourceGroup && string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    WriteExceptionError(new ArgumentException(ProjectResources.InvalidParameterForResourceGroupScope));
                }

                if (this.ScopeType == DeploymentScopeType.ManagementGroup && string.IsNullOrEmpty(this.ManagementGroupId))
                {
                    WriteExceptionError(new ArgumentException(ProjectResources.InvalidParameterForManagementGroupScope));
                }

                if ((this.ScopeType == DeploymentScopeType.Subscription || this.ScopeType == DeploymentScopeType.Tenant)
                    && (!string.IsNullOrEmpty(this.ResourceGroupName) || !string.IsNullOrEmpty(this.ManagementGroupId)))
                {
                    WriteExceptionError(new ArgumentException(string.Format(ProjectResources.InvalidParameterForTenantAndSubscriptionScope, this.ScopeType.ToString())));
                }
            }
        }

        private FilterDeploymentOptions GetDeploymentFilterOptions()
        {
            if (this.ScopeType.HasValue)
            {
                return new FilterDeploymentOptions(this.ScopeType.Value)
                {
                    ManagementGroupId = this.ManagementGroupId,
                    ResourceGroupName = this.ResourceGroupName,
                    DeploymentName = this.DeploymentName
                };
            }
            else
            {
                var options = new FilterDeploymentOptions(DeploymentScopeType.Subscription);
                options.DeploymentName = ResourceIdUtility.GetDeploymentName(this.DeploymentObject.Id);

                var deploymentId = this.DeploymentObject.Id;
                var subscriptionId = ResourceIdUtility.GetSubscriptionId(deploymentId);

                if (!string.IsNullOrEmpty(subscriptionId))
                {
                    var resourceGroupName = ResourceIdUtility.GetResourceGroupName(deploymentId);

                    if (!string.IsNullOrEmpty(resourceGroupName))
                    {
                        options.ScopeType = DeploymentScopeType.ResourceGroup;
                        options.ResourceGroupName = resourceGroupName;
                    }
                }
                else
                {
                    var managementGroupId = ResourceIdUtility.GetManagementGroupId(deploymentId);

                    if (!string.IsNullOrEmpty(managementGroupId))
                    {
                        options.ScopeType = DeploymentScopeType.ManagementGroup;
                        options.ManagementGroupId = managementGroupId;
                    }
                    else
                    {
                        options.ScopeType = DeploymentScopeType.Tenant;
                    }
                }

                return options;
            }
        }
    }
}
