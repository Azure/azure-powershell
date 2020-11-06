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
    using Common.ArgumentCompleters;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;

    /// <summary>
    /// Gets the deployment operation.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentOperation"), OutputType(typeof(PSDeploymentOperation))]
    public class GetAzureResourceGroupDeploymentOperationCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Gets or sets the deployment name parameter.
        /// </summary>
        [Alias("Name")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment name.")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName { get; set; }

        /// <summary>
        /// Gets or sets the resource group name parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            var deploymentOperations = ResourceManagerSdkClient.ListDeploymentOperationsAtResourceGroup(
                ResourceGroupName, DeploymentName);
            base.OnProcessRecord();

            WriteObject(deploymentOperations, true);
        }

    }
}
