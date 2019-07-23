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
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Cancel a running deployment.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Deployment", SupportsShouldProcess = true,
        DefaultParameterSetName = StopAzureDeploymentCmdlet.SubscriptionParameterSetWithDeploymentName), OutputType(typeof(bool))]
    public class StopAzureDeploymentCmdlet : ResourceManagerCmdletBase
    {
        internal const string ResourceGroupParameterSetWithDeploymentName = "ResourceGroupWithDeploymentName";
        internal const string SubscriptionParameterSetWithDeploymentName = "SubscriptionWithDeploymentName";
        internal const string ManagementGroupParameterSetWithDeploymentName = "ManagementGroupWithDeploymentName";
        internal const string TenantParameterSetWithDeploymentName = "TenantWithDeploymentName";

        internal const string DeploymentIdParameterSet = "StopByDeploymentId";

        internal const string InputObjectParameterSet = "StopByInputObject";

        [Parameter(Position = 0, ParameterSetName = StopAzureDeploymentCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "Stop deployment at tenant scope if specified.")]
        [Parameter(Position = 0, ParameterSetName = StopAzureDeploymentCmdlet.InputObjectParameterSet, Mandatory = false,
            HelpMessage = "Stop deployment at tenant scope if specified.")]
        public SwitchParameter Tenant { get; set; }

        [Parameter(Position = 0, ParameterSetName = StopAzureDeploymentCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The management group id.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Position = 0, ParameterSetName = StopAzureDeploymentCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("DeploymentName")]
        [Parameter(Position = 1, ParameterSetName = StopAzureDeploymentCmdlet.TenantParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 1, ParameterSetName = StopAzureDeploymentCmdlet.ManagementGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 0, ParameterSetName = StopAzureDeploymentCmdlet.SubscriptionParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [Parameter(Position = 1, ParameterSetName = StopAzureDeploymentCmdlet.ResourceGroupParameterSetWithDeploymentName, Mandatory = true,
            HelpMessage = "The name of deployment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("DeploymentId", "ResourceId")]
        [Parameter(ParameterSetName = StopAzureDeploymentCmdlet.DeploymentIdParameterSet, Mandatory = true,
            HelpMessage = "The fully qualified resource Id of the deployment. example: /subscriptions/{subId}/providers/Microsoft.Resources/deployments/{deploymentName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(ParameterSetName = StopAzureDeploymentCmdlet.InputObjectParameterSet, Mandatory = true,
            ValueFromPipeline = true, HelpMessage = "The deployment object.")]
        public PSDeployment InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            FilterDeploymentOptions options = new FilterDeploymentOptions()
            {
                IsTenantScope = this.Tenant, // (tiano): get it for Id parameter too.
                ManagementGroupId = this.GetManagementGroupId(),
                ResourceGroupName = this.GetResourceGroupName(),
                DeploymentName = this.GetDeploymetName(),
            };

            ConfirmAction(
                ProjectResources.CancelDeploymentMessage,
                this.Name,
                () => ResourceManagerSdkClient.CancelDeployment(options));

            if (this.PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }

        private string GetDeploymetName()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return this.Name;
            }
            else if (!string.IsNullOrEmpty(this.Id))
            {
                return ResourceIdUtility.GetResourceName(this.Id);
            }
            else
            {
                return this.InputObject.DeploymentName;
            }
        }

        private string GetManagementGroupId()
        {
            if (!string.IsNullOrEmpty(this.ManagementGroupId))
            {
                return this.ManagementGroupId;
            }
            else if (!string.IsNullOrEmpty(this.Id))
            {
                return ResourceIdUtility.GetManagementGroupId(this.Id);
            }
            else if (this.InputObject != null)
            {
                return this.InputObject.ManagementGroupId;
            }

            return null;
        }

        private string GetResourceGroupName()
        {
            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                return this.ResourceGroupName;
            }
            else if (!string.IsNullOrEmpty(this.Id))
            {
                return ResourceIdUtility.GetResourceGroupName(this.Id);
            }
            else if (this.InputObject != null)
            {
                return this.InputObject.ResourceGroupName;
            }

            return null;
        }
    }
}