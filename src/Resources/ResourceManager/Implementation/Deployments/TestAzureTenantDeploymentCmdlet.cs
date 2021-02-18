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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Validate a template to see whether it's using the right syntax, resource providers, resource types, etc.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, AzureRMConstants.AzureRMPrefix + "TenantDeployment",
        DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSResourceManagerError))]
    public class TestAzureTenantDeploymentCmdlet : TestDeploymentCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The location to store deployment data.")]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        protected override void OnProcessRecord()
        {
            var parameters = new PSDeploymentCmdletParameters()
            {
                ScopeType = DeploymentScopeType.Tenant,
                Location = this.Location,
                TemplateFile = this.TemplateUri ?? this.TryResolvePath(this.TemplateFile),
                TemplateObject = this.TemplateObject,
                QueryString = QueryString,
                TemplateParameterObject = this.GetTemplateParameterObject(this.TemplateParameterObject),
                ParameterUri = this.TemplateParameterUri
            };

            WriteObject(ResourceManagerSdkClient.ValidateDeployment(parameters));
        }
    }
}
