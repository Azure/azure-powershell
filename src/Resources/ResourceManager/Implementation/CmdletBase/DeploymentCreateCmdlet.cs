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
    using Microsoft.Azure.Commands.Common.Strategies;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;

    public abstract class DeploymentCreateCmdlet: DeploymentWhatIfCmdlet
    {
        protected abstract ConfirmImpact ConfirmImpact { get; }

        protected abstract PSDeploymentCmdletParameters DeploymentParameters { get; }

        protected override void OnProcessRecord()
        {
            string whatIfMessage = null;
            string warningMessage = null;
            string captionMessage = null;

            if (this.ShouldExecuteWhatIf())
            {
                PSWhatIfOperationResult whatIfResult = this.ExecuteWhatIf();
                string whatIfFormattedOutput = WhatIfOperationResultFormatter.Format(whatIfResult);

                // Use \r to override the built-in "What if:" in output.
                whatIfMessage = $"\r        \r{Environment.NewLine}{whatIfFormattedOutput}{Environment.NewLine}";
                warningMessage = $"{Environment.NewLine}{Resources.ConfirmDeploymentMessage}";
                captionMessage = $"{(char)27}[1A{Color.Reset}{whatIfMessage}"; // {(char)27}[1A for cursor up.
            }

            if (this.ShouldProcess(whatIfMessage, warningMessage, captionMessage))
            {
                this.ExecuteDeployment();
            }
        }

        protected void ExecuteDeployment()
        {
            if (!string.IsNullOrEmpty(this.DeploymentParameters.DeploymentDebugLogLevel))
            {
                WriteWarning(Resources.WarnOnDeploymentDebugSetting);
            }

            WriteObject(ResourceManagerSdkClient.ExecuteDeployment(this.DeploymentParameters));
        }

        protected bool ShouldExecuteWhatIf()
        {
            return ShouldProcessWithCurrentWhatIfFlagAndPreference()
                || ShouldProcessWithCurrentConfirmFlagAndPreference();
        }

        private bool ShouldProcessWithCurrentWhatIfFlagAndPreference()
        {
            if (this.MyInvocation.BoundParameters.GetOrNull("WhatIf") is SwitchParameter whatIfFlag)
            {
                return whatIfFlag.IsPresent;
            }

            return (bool)this.SessionState.PSVariable.GetValue("WhatIfPreference");
        }

        private bool ShouldProcessWithCurrentConfirmFlagAndPreference()
        {
            if (this.MyInvocation.BoundParameters.GetOrNull("Confirm") is SwitchParameter confirmFlag)
            {
                return confirmFlag.IsPresent;
            }

            var confirmPreference = (ConfirmImpact)this.SessionState.PSVariable.GetValue("ConfirmPreference");

            return this.ConfirmImpact >= confirmPreference;
        }
    }
}
