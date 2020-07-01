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

using System;
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Attributes;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
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
    /// Creates a new deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "Deployment", SupportsShouldProcess = true,
        DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSDeployment))]
    [Alias("New-AzSubscriptionDeployment")]
    public class NewAzureSubscriptionDeploymentCmdlet : ResourceWithParameterCmdletBase, IDynamicParameters
    {
        [Alias("DeploymentName")]
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the deployment it's going to create. If not specified, defaults to the template file name when a template file is provided; defaults to the current time when a template object is provided, e.g. \"20131223140835\".")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location to store deployment data.")]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The deployment debug log level.")]
        [PSArgumentCompleter("RequestContent", "ResponseContent", "All", "None")]
        public string DeploymentDebugLogLevel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The tags to put on the deployment.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "The What-If result format. Applicable when the -WhatIf or -Confirm switch is set.")]
        public WhatIfResultFormat WhatIfResultFormat { get; set; } = WhatIfResultFormat.FullResourcePayloads;

        [Parameter(Mandatory = false, HelpMessage = "Comma-separated resource change types to be excluded from What-If results. Applicable when the -WhatIf or -Confirm switch is set.")]
        [ChangeTypeCompleter]
        [ValidateChangeTypes]
        public string[] WhatIfExcludeChangeType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        protected override void OnProcessRecord()
        {
            string whatIfMessage = this.ShouldExecuteWhatIf() ? this.ExecuteWhatIf() : null;
            string warningMessage = $"{Environment.NewLine}{ProjectResources.ConfirmDeploymentMessage}";
            string captionMessage = $"{(char)27}[1A{Color.Reset}{whatIfMessage}"; // {(char)27}[1A for cursor up.

            if (ShouldProcess(whatIfMessage, warningMessage, captionMessage))
            {
                var parameters = new PSDeploymentCmdletParameters()
                {
                    ScopeType = DeploymentScopeType.Subscription,
                    Location = Location,
                    DeploymentName = Name,
                    DeploymentMode = DeploymentMode.Incremental,
                    TemplateSpecId = TemplateSpecId ?? null,
                    TemplateFile = TemplateUri ?? this.TryResolvePath(TemplateFile),
                    TemplateObject = TemplateObject,
                    TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
                    ParameterUri = TemplateParameterUri,
                    DeploymentDebugLogLevel = GetDeploymentDebugLogLevel(DeploymentDebugLogLevel),
                    Tags = TagsHelper.ConvertToTagsDictionary(Tag)
                };

                if (!string.IsNullOrEmpty(parameters.DeploymentDebugLogLevel))
                {
                    WriteWarning(ProjectResources.WarnOnDeploymentDebugSetting);
                }
                WriteObject(ResourceManagerSdkClient.ExecuteDeployment(parameters));
            }
        }

        private string ExecuteWhatIf()
        {
            const string statusMessage = "Getting the latest status of all resources...";
            var clearMessage = new string(' ', statusMessage.Length);
            var information = new HostInformationMessage { Message = statusMessage, NoNewLine = true };
            var clearInformation = new HostInformationMessage { Message = $"\r{clearMessage}\r", NoNewLine = true };
            var tags = new[] { "PSHOST" };

            try
            {
                // Write status message.
                this.WriteInformation(information, tags);


                var parameters = new PSDeploymentWhatIfCmdletParameters
                {
                    DeploymentName = this.Name,
                    Location = this.Location,
                    Mode = DeploymentMode.Incremental,
                    TemplateUri = TemplateUri ?? this.TryResolvePath(TemplateFile),
                    TemplateObject = this.TemplateObject,
                    TemplateParametersUri = this.TemplateParameterUri,
                    TemplateParametersObject = GetTemplateParameterObject(this.TemplateParameterObject),
                    ResultFormat = this.WhatIfResultFormat
                };

                PSWhatIfOperationResult whatIfResult = ResourceManagerSdkClient.ExecuteDeploymentWhatIf(parameters, this.WhatIfExcludeChangeType);
                string whatIfMessage = WhatIfOperationResultFormatter.Format(whatIfResult);

                // Clear status before returning result.
                this.WriteInformation(clearInformation, tags);

                // Use \r to override the built-in "What if:" in output.
                return $"\r        \r{Environment.NewLine}{whatIfMessage}{Environment.NewLine}";
            }
            catch (Exception)
            {
                // Clear status before handling exception.
                this.WriteInformation(clearInformation, tags);
                throw;
            }
        }

        private bool ShouldExecuteWhatIf()
        {
            return this.MyInvocation.BoundParameters.ContainsKey("WhatIf") ||
                   this.MyInvocation.BoundParameters.ContainsKey("Confirm");
        }
    }
}
