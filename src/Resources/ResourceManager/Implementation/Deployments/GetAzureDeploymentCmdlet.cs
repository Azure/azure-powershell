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
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Get deployments.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Deployment", DefaultParameterSetName = GetAzureDeploymentCmdlet.SubscriptionParameterSetWithDeploymentName), OutputType(typeof(PSDeployment))]
    public class GetAzureDeploymentCmdlet : ResourceManagerCmdletBase
    {
        internal const string ResourceGroupParameterSetWithDeploymentName = "ResourceGroupWithDeploymentName";
        internal const string SubscriptionParameterSetWithDeploymentName = "SubscriptionWithDeploymentName";
        internal const string ManagementGroupParameterSetWithDeploymentName = "ManagementGroupWithDeploymentName";
        internal const string TenantParameterSetWithDeploymentName = "TenantWithDeploymentName";

        internal const string DeploymentIdParameterSet = "GetByDeploymentId";

        [Parameter(Position = 0, ParameterSetName = GetAzureDeploymentCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(Position = 0, ParameterSetName = GetAzureDeploymentCmdlet.SubscriptionParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(Position = 0, ParameterSetName = GetAzureDeploymentCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(Position = 0, ParameterSetName = GetAzureDeploymentCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [ValidateNotNullOrEmpty]
        public DeploymentScopeType? ScopeType { get; set; }

        [Parameter(Position = 1, ParameterSetName = GetAzureDeploymentCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The management group id.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Position = 1, ParameterSetName = GetAzureDeploymentCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("DeploymentName")]
        [Parameter(Position = 1, ParameterSetName = GetAzureDeploymentCmdlet.TenantParameterSetWithDeploymentName, Mandatory = false,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 2, ParameterSetName = GetAzureDeploymentCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = false,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 1, ParameterSetName = GetAzureDeploymentCmdlet.SubscriptionParameterSetWithDeploymentName, Mandatory = false,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 2, ParameterSetName = GetAzureDeploymentCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = false,
            HelpMessage = "The name of deployment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("DeploymentId", "ResourceId")]
        [Parameter(ParameterSetName = GetAzureDeploymentCmdlet.DeploymentIdParameterSet, Mandatory = true,
            HelpMessage = "The fully qualified resource Id of the deployment. example: /subscriptions/{subId}/providers/Microsoft.Resources/deployments/{deploymentName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ValidateScopeTypeMatches();

            var filterOptions = this.GetDeploymentFilterOptions();
            var deployments = ResourceManagerSdkClient.FilterDeployments(filterOptions);

            WriteObject(deployments, true);
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
                var options = new FilterDeploymentOptions(DeploymentScopeType.Subscription);
                options.DeploymentName = ResourceIdUtility.GetDeploymentName(this.Id);

                var subscriptionId = ResourceIdUtility.GetSubscriptionId(this.Id);

                if (!string.IsNullOrEmpty(subscriptionId))
                {
                    var resourceGroupName = ResourceIdUtility.GetResourceGroupName(this.Id);

                    if (!string.IsNullOrEmpty(resourceGroupName))
                    {
                        options.ScopeType = DeploymentScopeType.ResourceGroup;
                        options.ResourceGroupName = resourceGroupName;
                    }
                }
                else
                {
                    var managementGroupId = ResourceIdUtility.GetManagementGroupId(this.Id);

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