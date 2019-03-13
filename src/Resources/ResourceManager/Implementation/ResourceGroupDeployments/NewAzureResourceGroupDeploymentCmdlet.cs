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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Creates a new resource group deployment.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeployment", SupportsShouldProcess = true,DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSResourceGroupDeployment))]
    public class NewAzureResourceGroupDeploymentCmdlet : ResourceWithParameterCmdletBase, IDynamicParameters
    {
        [Alias("DeploymentName")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the deployment it's going to create. Only valid when a template is used. When a template is used, if the user doesn't specify a deployment name, use the current time, like \"20131223140835\".")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment mode.")]
        public DeploymentMode Mode { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment debug log level.")]
        [ValidateSet("RequestContent", "ResponseContent", "All", "None", IgnoreCase = true)]
        public string DeploymentDebugLogLevel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Rollback to the last successful deployment in the resource group, should not be present if -RollBackDeploymentName is used.")]
        public SwitchParameter RollbackToLastDeployment { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Rollback to the successful deployment with the given name in the resource group, should not be used if -RollbackToLastDeployment is used.")]
        public string RollBackDeploymentName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

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
                    if (RollbackToLastDeployment && !string.IsNullOrEmpty(RollBackDeploymentName))
                    {
                        WriteExceptionError(new ArgumentException(ProjectResources.InvalidRollbackParameters));
                    }

                    var parameters = new PSDeploymentCmdletParameters()
                    {
                        ResourceGroupName = ResourceGroupName,
                        DeploymentName = Name,
                        DeploymentMode = Mode,
                        TemplateFile = TemplateUri ?? this.TryResolvePath(TemplateFile),
                        TemplateObject = TemplateObject,
                        TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
                        ParameterUri = TemplateParameterUri,
                        DeploymentDebugLogLevel = GetDeploymentDebugLogLevel(DeploymentDebugLogLevel),
                        OnErrorDeployment = RollbackToLastDeployment || !string.IsNullOrEmpty(RollBackDeploymentName)
                            ? new OnErrorDeployment
                            {
                                Type = RollbackToLastDeployment ? OnErrorDeploymentType.LastSuccessful : OnErrorDeploymentType.SpecificDeployment,
                                DeploymentName = RollbackToLastDeployment ? null : RollBackDeploymentName
                            }
                            : null
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
