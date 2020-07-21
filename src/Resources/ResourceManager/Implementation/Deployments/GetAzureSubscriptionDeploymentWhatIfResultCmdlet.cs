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
    using System;
    using System.Management.Automation;
    using Common;
    using Common.ArgumentCompleters;
    using Management.ResourceManager.Models;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Attributes;
    using SdkModels.Deployments;
    using WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Gets What-If results for a deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "DeploymentWhatIfResult",
         DefaultParameterSetName = ParameterlessTemplateFileParameterSetName),
     OutputType(typeof(PSWhatIfOperationResult))]
    [Alias("Get-AzSubscriptionDeploymentWhatIfResult")]
    public class GetAzureSubscriptionDeploymentWhatIfResultCmdlet : ResourceWithParameterCmdletBase, IDynamicParameters
    {
        [Alias("DeploymentName")]
        [Parameter(Mandatory = false, HelpMessage = "The name of the deployment it's going to create. If not specified, defaults to the template file name when a template file is provided; defaults to the current time when a template object is provided, e.g. \"20131223140835\".")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }


        [Parameter(Mandatory = true, HelpMessage = "The location to store deployment data.")]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The What-If result format.")]
        public WhatIfResultFormat ResultFormat { get; set; } = WhatIfResultFormat.FullResourcePayloads;

        [Parameter(Mandatory = false, HelpMessage = "Comma-separated list of resource change types to be excluded from What-If results.")]
        [ChangeTypeCompleter]
        [ValidateChangeTypes]
        public string[] ExcludeChangeType { get; set; }


        protected override void OnProcessRecord()
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
                    TemplateSpecId = this.TemplateSpecId,
                    TemplateUri = this.TemplateUri ?? this.TryResolvePath(this.TemplateFile),
                    TemplateObject = this.TemplateObject,
                    TemplateParametersUri = this.TemplateParameterUri,
                    TemplateParametersObject = GetTemplateParameterObject(this.TemplateParameterObject),
                    ResultFormat = this.ResultFormat
                };

                PSWhatIfOperationResult whatIfResult = ResourceManagerSdkClient.ExecuteDeploymentWhatIf(parameters, this.ExcludeChangeType);

                // Clear status before returning result.
                this.WriteInformation(clearInformation, tags);
                this.WriteObject(whatIfResult);
            }
            catch (Exception)
            {
                // Clear status on exception.
                this.WriteInformation(clearInformation, tags);
                throw;
            }
        }
    }
}
