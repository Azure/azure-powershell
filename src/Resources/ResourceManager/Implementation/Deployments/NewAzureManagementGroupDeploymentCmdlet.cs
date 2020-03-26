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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Creates a new deployment at a management group.
    /// </summary>
    [Cmdlet(VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "ManagementGroupDeployment", SupportsShouldProcess = true,
        DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSDeployment))]
    public class NewAzureManagementGroupDeploymentCmdlet : ResourceWithParameterCmdletBase, IDynamicParameters
    {
        [Alias("DeploymentName")]
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the deployment it's going to create. Only valid when a template is used. When a template is used, if the user doesn't specify a deployment name, use the current time, like \"20131223140835\".")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The management group ID.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location to store deployment data.")]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The deployment debug log level.")]
        [PSArgumentCompleter("RequestContent", "ResponseContent", "All", "None")]
        public string DeploymentDebugLogLevel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        protected override void OnProcessRecord()
        {
            var parameters = new PSDeploymentCmdletParameters()
            {
                ScopeType = DeploymentScopeType.ManagementGroup,
                ManagementGroupId = this.ManagementGroupId,
                Location = this.Location,
                DeploymentName = this.Name,
                DeploymentMode = DeploymentMode.Incremental,
                TemplateFile = TemplateUri ?? this.TryResolvePath(TemplateFile),
                TemplateObject = TemplateObject,
                TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
                ParameterUri = TemplateParameterUri,
                DeploymentDebugLogLevel = GetDeploymentDebugLogLevel(DeploymentDebugLogLevel)
            };

            if (!string.IsNullOrEmpty(parameters.DeploymentDebugLogLevel))
            {
                WriteWarning(ProjectResources.WarnOnDeploymentDebugSetting);
            }
            WriteObject(ResourceManagerSdkClient.ExecuteDeployment(parameters));
        }
    }
}
