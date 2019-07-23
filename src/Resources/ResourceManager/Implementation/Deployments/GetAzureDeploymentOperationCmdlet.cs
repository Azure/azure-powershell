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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;

    /// <summary>
    /// Gets the deployment operation.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeploymentOperation", DefaultParameterSetName = GetAzureDeploymentOperationCmdlet.SubscriptionParameterSetWithDeploymentName), OutputType(typeof(PSDeploymentOperation))]
    public class GetAzureDeploymentOperationCmdlet : ResourceManagerCmdletBase
    {
        internal const string ResourceGroupParameterSetWithDeploymentName = "ResourceGroupWithDeploymentName";
        internal const string SubscriptionParameterSetWithDeploymentName = "SubscriptionWithDeploymentName";
        internal const string ManagementGroupParameterSetWithDeploymentName = "ManagementGroupWithDeploymentName";
        internal const string TenantParameterSetWithDeploymentName = "TenantWithDeploymentName";

        internal const string DeploymentObjectParameterSet = "GetByDeploymentObject";

        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "Get deployment operation at tenant scope if specified.")]
        [Parameter(ParameterSetName = GetAzureDeploymentOperationCmdlet.DeploymentObjectParameterSet, Mandatory = false,
            HelpMessage = "Get deployment operation at tenant scope if specified.")]
        public SwitchParameter Tenant { get; set; }

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
            var deploymentName = this.GetDeploymetName();
            var resourceGroupName = this.GetResourceGroupName();
            var managementGroupId = this.GetManagementGroupId();

            var deploymentOperations = this.GetDeploymentOperations(this.Tenant, managementGroupId, resourceGroupName, deploymentName);

            WriteObject(deploymentOperations, true);
        }

        private List<PSDeploymentOperation> GetDeploymentOperations(bool isTenantDeployment, string managementGroupId, string resourceGroupName, string deploymentName)
        {
            if (isTenantDeployment)
            {
                return ResourceManagerSdkClient.ListDeploymentOperationsAtTenantScope(deploymentName, this.OperationId);
            }
            else if (!string.IsNullOrEmpty(managementGroupId))
            {
                return ResourceManagerSdkClient.ListDeploymentOperationsAtManagementGroup(managementGroupId, deploymentName, this.OperationId);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName))
            {
                return ResourceManagerSdkClient.ListDeploymentOperationsAtResourceGroup(resourceGroupName, deploymentName, this.OperationId);
            }
            else
            {
                return ResourceManagerSdkClient.ListDeploymentOperationsAtSubscriptionScope(deploymentName, this.OperationId);
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
