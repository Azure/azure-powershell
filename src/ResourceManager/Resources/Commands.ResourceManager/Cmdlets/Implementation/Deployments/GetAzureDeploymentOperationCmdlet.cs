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
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Gets the deployment operation.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmDeploymentOperation"), OutputType(typeof(PSDeploymentOperation))]
    public class GetAzureDeploymentOperationCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Gets or sets the deployment name parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment name.")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName { get; set; }

        /// <summary>
        /// Gets or sets the deployment operation Id.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment operation Id.")]
        public string OperationId { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(ResourceManagerSdkClient.GetDeploymentOperations(this.DeploymentName, this.OperationId), true);
        }
    }
}
