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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;

    /// <summary>
    /// Base class for Deployment Stack What-If cmdlets.
    /// </summary>
    public abstract class DeploymentStackWhatIfCmdlet : DeploymentStacksCreateCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation when an existing WhatIf result will be overwritten.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// It's important not to call this function more than once during an invocation, as it can call the Bicep CLI.
        /// This is slow, and can also cause diagnostics to be emitted multiple times.
        /// </summary>
        protected abstract PSDeploymentStackWhatIfParameters BuildWhatIfParameters();

        protected override void OnProcessRecord()
        {
            var parameters = this.BuildWhatIfParameters();

            // Check if a WhatIf result already exists for this name/scope
            PSDeploymentStackWhatIfResult existing = null;
            try
            {
                if (!string.IsNullOrEmpty(parameters.ResourceGroupName))
                {
                    existing = DeploymentStacksWhatIfSdkClient.GetResourceGroupDeploymentStackWhatIfResult(
                        parameters.ResourceGroupName, parameters.StackName, throwIfNotExists: false);
                }
                else if (!string.IsNullOrEmpty(parameters.ManagementGroupId))
                {
                    existing = DeploymentStacksWhatIfSdkClient.GetManagementGroupDeploymentStackWhatIfResult(
                        parameters.ManagementGroupId, parameters.StackName, throwIfNotExists: false);
                }
                else
                {
                    existing = DeploymentStacksWhatIfSdkClient.GetSubscriptionDeploymentStackWhatIfResult(
                        parameters.StackName, throwIfNotExists: false);
                }
            }
            catch
            {
                // Any other error during existence check is non-fatal.
                existing = null;
            }

            Action executeAction = () =>
            {
                PSDeploymentStackWhatIfResult whatIfResult = this.ExecuteWhatIf(parameters);
                // The ToString() method on PSDeploymentStackWhatIfResult calls the formatter
                this.WriteObject(whatIfResult);
            };

            if (existing != null)
            {
                ConfirmAction(
                    Force.IsPresent,
                    $"A WhatIf result '{parameters.StackName}' already exists. Overwriting it will replace any existing changes.",
                    "Overwrite WhatIf result",
                    parameters.StackName,
                    executeAction);
            }
            else
            {
                executeAction();
            }
        }

        protected PSDeploymentStackWhatIfResult ExecuteWhatIf(PSDeploymentStackWhatIfParameters parameters)
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

                var whatIfResult = DeploymentStacksWhatIfSdkClient.ExecuteDeploymentStackWhatIf(parameters);

                // Clear status before returning result.
                this.WriteInformation(clearInformation, tags);

                return whatIfResult;
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