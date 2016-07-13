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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Creates a new resource group deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmResourceGroupDeployment", SupportsShouldProcess = true,
        DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSResourceGroupDeployment))]
    public class NewAzureResourceGroupDeploymentCmdlet : ResourceWithParameterCmdletBase, IDynamicParameters
    {
        [Alias("DeploymentName")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the deployment it's going to create. Only valid when a template is used. When a template is used, if the user doesn't specify a deployment name, use the current time, like \"20131223140835\".")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment mode.")]
        public DeploymentMode Mode { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment debug log level.")]
        [ValidateSet("RequestContent", "ResponseContent", "All", "None", IgnoreCase = true)]
        public string DeploymentDebugLogLevel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public NewAzureResourceGroupDeploymentCmdlet()
        {
            this.Mode = DeploymentMode.Incremental;
        }

        public override void ExecuteCmdlet()
        {

            this.ConfirmAction(
                this.Force,
                string.Format(ProjectResources.ConfirmOnCompleteDeploymentMode, this.ResourceGroupName),
                ProjectResources.CreateDeployment,
                ResourceGroupName,
                () =>
                {
                    PSCreateResourceGroupDeploymentParameters parameters = new PSCreateResourceGroupDeploymentParameters()
                    {
                        ResourceGroupName = ResourceGroupName,
                        DeploymentName = Name,
                        DeploymentMode = Mode,
                        TemplateFile = TemplateUri ?? this.TryResolvePath(TemplateFile),
                        TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
                        ParameterUri = TemplateParameterUri,
                        DeploymentDebugLogLevel = GetDeploymentDebugLogLevel(DeploymentDebugLogLevel)
                    };

                    if (!string.IsNullOrEmpty(parameters.DeploymentDebugLogLevel))
                    {
                        WriteWarning(ProjectResources.WarnOnDeploymentDebugSetting);
                    }
                    WriteObject(ResourceManagerSdkClient.ExecuteDeployment(parameters));
                },
                () => this.Mode == DeploymentMode.Complete);
        }
    }
}
