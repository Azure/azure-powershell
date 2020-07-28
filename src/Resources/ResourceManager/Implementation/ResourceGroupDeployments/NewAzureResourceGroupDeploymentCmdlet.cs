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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Attributes;

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
            HelpMessage = "The name of the deployment it's going to create. If not specified, defaults to the template file name when a template file is provided; defaults to the current time when a template object is provided, e.g. \"20131223140835\".")]
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

        [Parameter(Mandatory = false, HelpMessage = "The tags to put on the deployment.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "The What-If result format. Applicable when the -WhatIf or -Confirm switch is set.")]
        public WhatIfResultFormat WhatIfResultFormat { get; set; } = WhatIfResultFormat.FullResourcePayloads;

        [Parameter(Mandatory = false, HelpMessage = "Comma-separated resource change types to be excluded from What-If results. Applicable when the -WhatIf or -Confirm switch is set.")]
        [ChangeTypeCompleter]
        [ValidateChangeTypes]
        public string[] WhatIfExcludeChangeType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public NewAzureResourceGroupDeploymentCmdlet()
        {
            this.Mode = DeploymentMode.Incremental;
        }

        protected override void OnProcessRecord()
        {
            if (this.ShouldExecuteWhatIf())
            {
                string whatIfMessage = ExecuteWhatIf();
                string warningMessage = $"{Environment.NewLine}{ProjectResources.ConfirmDeploymentMessage}";
                string captionMessage = $"{(char)27}[1A{Color.Reset}{whatIfMessage}"; // {(char)27}[1A for cursor up.

                if (this.ShouldProcess(whatIfMessage, warningMessage, captionMessage))
                {
                    this.ExecuteDeployment();
                }
            }
            else
            {
                this.ConfirmAction(
                    this.Force,
                    string.Format(ProjectResources.ConfirmOnCompleteDeploymentMode, this.ResourceGroupName),
                    ProjectResources.CreateDeployment,
                    ResourceGroupName,
                    this.ExecuteDeployment,
                    () => this.Mode == DeploymentMode.Complete);
            }
        }

        private bool ShouldExecuteWhatIf()
        {
            return this.MyInvocation.BoundParameters.ContainsKey("WhatIf") ||
                   this.MyInvocation.BoundParameters.ContainsKey("Confirm");
        }

        private string ExecuteWhatIf()
        {
            const string statusMessage = "Getting the latest status of all resources...";
            var clearMessage = new string(' ', statusMessage.Length);
            var information = new HostInformationMessage { Message = statusMessage, NoNewLine = true };
            var clearInformation = new HostInformationMessage { Message = $"\r{clearMessage}\r", NoNewLine = true };
            var tags = new[] { "PSHOST" };

            // Write status message.
            this.WriteInformation(information, tags);

            var parameters = new PSDeploymentWhatIfCmdletParameters
            {
                ScopeType = DeploymentScopeType.ResourceGroup,
                DeploymentName = this.Name,
                Mode = this.Mode,
                ResourceGroupName = this.ResourceGroupName,
                TemplateUri = TemplateUri ?? this.TryResolvePath(TemplateFile),
                TemplateObject = this.TemplateObject,
                TemplateParametersUri = this.TemplateParameterUri,
                TemplateParametersObject = GetTemplateParameterObject(this.TemplateParameterObject),
                ResultFormat = this.WhatIfResultFormat
            };

            try
            {
                PSWhatIfOperationResult whatIfResult = ResourceManagerSdkClient.ExecuteDeploymentWhatIf(parameters, this.WhatIfExcludeChangeType);
                string whatIfMessage = WhatIfOperationResultFormatter.Format(whatIfResult);

                // Clear status on success execution.
                this.WriteInformation(clearInformation, tags);

                // Use \r to override the built-in "What if:" in output.
                return $"\r        \r{Environment.NewLine}{whatIfMessage}{Environment.NewLine}";
            }
            catch (Exception)
            {
                // Clear status on exception.
                this.WriteInformation(clearInformation, tags);
                throw;
            }
        }

        private void ExecuteDeployment()
        {
            if (RollbackToLastDeployment && !string.IsNullOrEmpty(RollBackDeploymentName))
            {
                WriteExceptionError(new ArgumentException(ProjectResources.InvalidRollbackParameters));
            }

            var parameters = new PSDeploymentCmdletParameters()
            {
                ScopeType = DeploymentScopeType.ResourceGroup,
                ResourceGroupName = ResourceGroupName,
                DeploymentName = Name,
                DeploymentMode = Mode,
                TemplateFile = TemplateUri ?? this.TryResolvePath(TemplateFile),
                TemplateObject = TemplateObject,
                TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
                ParameterUri = TemplateParameterUri,
                DeploymentDebugLogLevel = GetDeploymentDebugLogLevel(DeploymentDebugLogLevel),
                Tags = TagsHelper.ConvertToTagsDictionary(Tag),
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
            WriteObject(ResourceManagerSdkClient.ExecuteResourceGroupDeployment(parameters));
        }
    }
}
