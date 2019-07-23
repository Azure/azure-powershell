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

        [Parameter(Position = 0, ParameterSetName = GetAzureDeploymentCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "Get deployment at tenant scope if specified.")]
        public SwitchParameter Tenant { get; set; }

        [Parameter(Position = 0, ParameterSetName = GetAzureDeploymentCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The management group id.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Position = 0, ParameterSetName = GetAzureDeploymentCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("DeploymentName")]
        [Parameter(Position = 1, ParameterSetName = GetAzureDeploymentCmdlet.TenantParameterSetWithDeploymentName, Mandatory = false,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 1, ParameterSetName = GetAzureDeploymentCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = false,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 0, ParameterSetName = GetAzureDeploymentCmdlet.SubscriptionParameterSetWithDeploymentName, Mandatory = false,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 1, ParameterSetName = GetAzureDeploymentCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = false,
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
            FilterDeploymentOptions options = new FilterDeploymentOptions()
            {
                IsTenantScope = this.Tenant, // (tiano): get it for Id parameter too.
                ManagementGroupId = ManagementGroupId ?? (string.IsNullOrEmpty(Id) ? null : ResourceIdUtility.GetManagementGroupId(Id)),
                ResourceGroupName = ResourceGroupName ?? (string.IsNullOrEmpty(Id) ? null : ResourceIdUtility.GetResourceGroupName(Id)),
                DeploymentName = Name ?? (string.IsNullOrEmpty(Id) ? null : ResourceIdUtility.GetDeploymentName(Id)),
            };

            var deployments = ResourceManagerSdkClient.FilterDeployments(options);

            WriteObject(deployments, true);
        }
    }
}