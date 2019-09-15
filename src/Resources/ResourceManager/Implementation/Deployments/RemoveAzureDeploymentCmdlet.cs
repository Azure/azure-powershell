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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Deletes a deployment.
    /// </summary>
    [GenericBreakingChange("A new parameter \"ScopeType\" will be introduced to the cmdlet and will be mandatory when removing the deployment by name. ScopeType will be an enum with four values: ResourceGroup, Subscription, ManagementGroup, Tenant. Adding this parameter allows us to use one cmdlet for all Azure Resource Manager template deployments but still determine the intended level of scope.", "3.0")]
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Deployment", SupportsShouldProcess = true,
        DefaultParameterSetName = RemoveAzureDeploymentCmdlet.SubscriptionParameterSetWithDeploymentName), OutputType(typeof(bool))]
    public class RemoveAzureDeploymentCmdlet : ResourceManagerCmdletBase
    {
        internal const string ResourceGroupParameterSetWithDeploymentName = "ResourceGroupWithDeploymentName";
        internal const string SubscriptionParameterSetWithDeploymentName = "SubscriptionWithDeploymentName";
        internal const string ManagementGroupParameterSetWithDeploymentName = "ManagementGroupWithDeploymentName";
        internal const string TenantParameterSetWithDeploymentName = "TenantWithDeploymentName";

        internal const string DeploymentIdParameterSet = "RemoveByDeploymentId";

        internal const string InputObjectParameterSet = "RemoveByInputObject";

        [Parameter(Position = 0, ParameterSetName = RemoveAzureDeploymentCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(Position = 0, ParameterSetName = RemoveAzureDeploymentCmdlet.SubscriptionParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(Position = 0, ParameterSetName = RemoveAzureDeploymentCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(Position = 0, ParameterSetName = RemoveAzureDeploymentCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [ValidateNotNullOrEmpty]
        public DeploymentScopeType? ScopeType { get; set; }

        [Parameter(Position = 1, ParameterSetName = RemoveAzureDeploymentCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The management group id.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Position = 1, ParameterSetName = RemoveAzureDeploymentCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("DeploymentName")]
        [Parameter(Position = 1, ParameterSetName = RemoveAzureDeploymentCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 2, ParameterSetName = RemoveAzureDeploymentCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 1, ParameterSetName = RemoveAzureDeploymentCmdlet.SubscriptionParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 2, ParameterSetName = RemoveAzureDeploymentCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("DeploymentId", "ResourceId")]
        [Parameter(ParameterSetName = RemoveAzureDeploymentCmdlet.DeploymentIdParameterSet, Mandatory = true,
            HelpMessage = "The fully qualified resource Id of the deployment. example: /subscriptions/{subId}/providers/Microsoft.Resources/deployments/{deploymentName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(ParameterSetName = RemoveAzureDeploymentCmdlet.InputObjectParameterSet, Mandatory = true, 
            ValueFromPipeline = true, HelpMessage = "The deployment object.")]
        public PSDeployment InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ValidateScopeTypeMatches();
            var options = this.GetDeploymentFilterOptions();

            ConfirmAction(
                ProjectResources.DeleteDeploymentMessage,
                Name,
                () =>
                {
                    this.DeleteDeployment(options);

                    if (this.PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }

        private void DeleteDeployment(FilterDeploymentOptions options)
        {
            switch (options.ScopeType)
            {
                case DeploymentScopeType.Tenant:
                    this.ResourceManagerSdkClient.DeleteDeploymentAtTenantScope(options.DeploymentName);
                    break;

                case DeploymentScopeType.ManagementGroup:
                    this.ResourceManagerSdkClient.DeleteDeploymentAtManagementGroup(options.ManagementGroupId, options.DeploymentName);
                    break;

                case DeploymentScopeType.ResourceGroup:
                    this.ResourceManagerSdkClient.DeleteDeploymentAtResourceGroup(options.ResourceGroupName, options.DeploymentName);
                    break;

                case DeploymentScopeType.Subscription:
                default:
                    ResourceManagerSdkClient.DeleteDeploymentAtSubscriptionScope(options.DeploymentName);
                    break;
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
                    DeploymentName = this.Name
                };
            }
            else
            {
                var deploymentId = this.Id ?? this.InputObject.Id;

                var options = new FilterDeploymentOptions(DeploymentScopeType.Subscription);
                options.DeploymentName = ResourceIdUtility.GetDeploymentName(deploymentId);

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