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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

    /// <summary>
    /// Gets the deployment operation.
    /// </summary>
    [GenericBreakingChange("A new parameter \"ScopeType\" will be introduced to the cmdlet and will be mandatory when getting deployment opeartions by deployment name. ScopeType will be an enum with four values: ResourceGroup, Subscription, ManagementGroup, Tenant. Adding this parameter allows us to use one cmdlet for all Azure Resource Manager template deployments but still determine the intended level of scope.", "3.0")]
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeploymentOperation", DefaultParameterSetName = GetAzureDeploymentOperationCmdlet.SubscriptionParameterSetWithDeploymentName), OutputType(typeof(PSDeploymentOperation))]
    public class GetAzureDeploymentOperationCmdlet : ResourceManagerCmdletBase
    {
        internal const string ResourceGroupParameterSetWithDeploymentName = "ResourceGroupWithDeploymentName";
        internal const string SubscriptionParameterSetWithDeploymentName = "SubscriptionWithDeploymentName";
        internal const string ManagementGroupParameterSetWithDeploymentName = "ManagementGroupWithDeploymentName";
        internal const string TenantParameterSetWithDeploymentName = "TenantWithDeploymentName";

        internal const string DeploymentObjectParameterSet = "GetByDeploymentObject";

        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.SubscriptionParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The scope type of the deployment.")]
        [ValidateNotNullOrEmpty]
        public DeploymentScopeType? ScopeType { get; set; }

        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The management group id.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the deployment name parameter.
        /// </summary>
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.SubscriptionParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName { get; set; }

        /// <summary>
        /// Gets or sets the deployment operation Id.
        /// </summary>
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.TenantParameterSetWithDeploymentName, Mandatory = false,
            HelpMessage = "The deployment operation id.")]
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = false,
            HelpMessage = "The deployment operation id.")]
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.SubscriptionParameterSetWithDeploymentName, Mandatory = false,
            HelpMessage = "The deployment operation id.")]
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = false,
            HelpMessage = "The deployment operation id.")]
        public string OperationId { get; set; }

        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.DeploymentObjectParameterSet, Mandatory = true,
            ValueFromPipeline = true, HelpMessage = "The deployment object.")]
        public PSDeployment DeploymentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ValidateScopeTypeMatches();

            var deploymentFilterOptions = this.GetDeploymentFilterOptions();
            var deploymentOperations = this.GetDeploymentOperations(deploymentFilterOptions, this.OperationId);

            WriteObject(deploymentOperations, true);
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

        private List<PSDeploymentOperation> GetDeploymentOperations(FilterDeploymentOptions options, string operationId)
        {
            switch (options.ScopeType)
            {
                case DeploymentScopeType.Tenant:
                    return ResourceManagerSdkClient.ListDeploymentOperationsAtTenantScope(options.DeploymentName, operationId);

                case DeploymentScopeType.ManagementGroup:
                    return ResourceManagerSdkClient.ListDeploymentOperationsAtManagementGroup(options.ManagementGroupId, options.DeploymentName, operationId);

                case DeploymentScopeType.ResourceGroup:
                    return ResourceManagerSdkClient.ListDeploymentOperationsAtResourceGroup(options.ResourceGroupName, options.DeploymentName, operationId);

                case DeploymentScopeType.Subscription:
                default:
                    return ResourceManagerSdkClient.ListDeploymentOperationsAtSubscriptionScope(options.DeploymentName, operationId);
            }
        }
    }
}
