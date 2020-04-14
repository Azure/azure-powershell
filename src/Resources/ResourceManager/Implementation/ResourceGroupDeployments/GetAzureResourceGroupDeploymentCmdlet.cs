﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Filters resource group deployments.
    /// </summary>
    [Cmdlet("Get", AzureRMConstants.AzureRMPrefix + "ResourceGroupDeployment", DefaultParameterSetName = GetAzureResourceGroupDeploymentCmdlet.DeploymentNameParameterSet), OutputType(typeof(PSResourceGroupDeployment))]
    public class GetAzureResourceGroupDeploymentCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// The deployment Id parameter set.
        /// </summary>
        internal const string DeploymentIdParameterSet = "GetByResourceGroupDeploymentId";

        /// <summary>
        /// The deployment name parameter set.
        /// </summary>
        internal const string DeploymentNameParameterSet = "GetByResourceGroupDeploymentName";

        [Parameter(Position = 0, ParameterSetName = GetAzureResourceGroupDeploymentCmdlet.DeploymentNameParameterSet, Mandatory = true, 
            ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("DeploymentName")]
        [Parameter(Position = 1, ParameterSetName = GetAzureResourceGroupDeploymentCmdlet.DeploymentNameParameterSet, Mandatory = false, 
            ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group deployment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("DeploymentId", "ResourceId")]
        [Parameter(ParameterSetName = GetAzureResourceGroupDeploymentCmdlet.DeploymentIdParameterSet, Mandatory = true, 
            HelpMessage = "The fully qualified resource Id of the deployment. example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/deployments/{deploymentName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        protected override void OnProcessRecord()
        {
            FilterDeploymentOptions options = new FilterDeploymentOptions(DeploymentScopeType.ResourceGroup)
            {
                ResourceGroupName = ResourceGroupName ?? ResourceIdUtility.GetResourceGroupName(Id),
                DeploymentName = Name ?? (string.IsNullOrEmpty(Id) ? null : ResourceIdUtility.GetResourceName(Id))
            };

            WriteObject(ResourceManagerSdkClient.FilterResourceGroupDeployments(options), true);
        }
    }
}
