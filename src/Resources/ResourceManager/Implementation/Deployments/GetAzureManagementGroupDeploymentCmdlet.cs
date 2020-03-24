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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Get deployments.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "ManagementGroupDeployment", DefaultParameterSetName = GetAzureManagementGroupDeploymentCmdlet.DeploymentNameParameterSet), OutputType(typeof(PSDeployment))]
    public class GetAzureManagementGroupDeploymentCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// The deployment Id parameter set.
        /// </summary>
        internal const string DeploymentIdParameterSet = "GetByDeploymentId";

        /// <summary>
        /// The deployment name parameter set.
        /// </summary>
        internal const string DeploymentNameParameterSet = "GetByDeploymentName";

        [Parameter(Position = 0, ParameterSetName = GetAzureManagementGroupDeploymentCmdlet.DeploymentNameParameterSet, Mandatory = true,
            HelpMessage = "The management group id.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Alias("DeploymentName")]
        [Parameter(Position = 1, ParameterSetName = GetAzureManagementGroupDeploymentCmdlet.DeploymentNameParameterSet, Mandatory = false,
            HelpMessage = "The name of deployment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("DeploymentId", "ResourceId")]
        [Parameter(ParameterSetName = GetAzureManagementGroupDeploymentCmdlet.DeploymentIdParameterSet, Mandatory = true,
            HelpMessage = "The fully qualified resource Id of the deployment. example: /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Resources/deployments/{deploymentName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        protected override void OnProcessRecord()
        {
            FilterDeploymentOptions options = new FilterDeploymentOptions(DeploymentScopeType.ManagementGroup)
            {
                ManagementGroupId = this.ManagementGroupId ?? ResourceIdUtility.GetManagementGroupId(this.Id),
                DeploymentName = this.Name ?? (string.IsNullOrEmpty(this.Id) ? null : ResourceIdUtility.GetDeploymentName(this.Id))
            };

            WriteObject(ResourceManagerSdkClient.FilterDeployments(options), true);
        }
    }
}