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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using Microsoft.Azure.Commands.ResourceManager.Common;

    /// <summary>
    /// Gets the deployment operation.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "TenantDeploymentOperation",
        DefaultParameterSetName = GetAzureTenantDeploymentOperationCmdlet.DeploymentNameParameterSet), OutputType(typeof(PSDeploymentOperation))]
    public class GetAzureTenantDeploymentOperationCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// The deployment name parameter set.
        /// </summary>
        internal const string DeploymentNameParameterSet = "GetByDeploymentName";

        /// <summary>
        /// The deployment object parameter set.
        /// </summary>
        internal const string DeploymentObjectParameterSet = "GetByDeploymentObject";

        /// <summary>
        /// Gets or sets the deployment name parameter.
        /// </summary>
        [Parameter(ParameterSetName = GetAzureTenantDeploymentOperationCmdlet.DeploymentNameParameterSet,
            Mandatory = true, HelpMessage = "The deployment name.")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName { get; set; }

        /// <summary>
        /// Gets or sets the deployment operation Id.
        /// </summary>
        [Parameter(ParameterSetName = GetAzureTenantDeploymentOperationCmdlet.DeploymentNameParameterSet,
            Mandatory = false, HelpMessage = "The deployment operation Id.")]
        public string OperationId { get; set; }

        [Parameter(ParameterSetName = GetAzureTenantDeploymentOperationCmdlet.DeploymentObjectParameterSet,
            Mandatory = true, ValueFromPipeline = true, HelpMessage = "The deployment object.")]
        public PSDeployment DeploymentObject { get; set; }

        protected override void OnProcessRecord()
        {
            var options = new FilterDeploymentOptions(DeploymentScopeType.Tenant)
            {
                DeploymentName = !string.IsNullOrEmpty(this.DeploymentName) ? this.DeploymentName : this.DeploymentObject.DeploymentName
            };

            var deploymentOperations = ResourceManagerSdkClient.ListDeploymentOperationsAtTenantScope(
                options.DeploymentName, this.OperationId);

            WriteObject(deploymentOperations, true);
        }
    }
}
