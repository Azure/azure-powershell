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
        [Parameter(Mandatory = false, HelpMessage = "The query string (for example, a SAS token) to be used with the TemplateUri parameter. Would be used in case of linked templates")]
        public string QueryString { get; set; }

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
                string cursorUp = $"{(char)27}[1A";

                // Use \r to override the built-in "What if:" in output.
                whatIfMessage = $"\r        \r{Environment.NewLine}{whatIfFormattedOutput}{Environment.NewLine}";
                warningMessage = $"{Environment.NewLine}{Resources.ConfirmDeploymentMessage}";
                captionMessage = $"{cursorUp}{Color.Reset}{whatIfMessage}";
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

            if (this.DeploymentParameters.ScopeType == DeploymentScopeType.ResourceGroup)
            {
                WriteObject(this.ResourceManagerSdkClient.ExecuteResourceGroupDeployment(this.DeploymentParameters));
            }
            else
            {
                WriteObject(this.ResourceManagerSdkClient.ExecuteDeployment(this.DeploymentParameters));
            }
        }

        protected bool ShouldExecuteWhatIf()
        {
            return ShouldProcessGivenCurrentWhatIfFlagAndPreference()
                || ShouldProcessGivenCurrentConfirmFlagAndPreference();
        }

        private bool ShouldProcessGivenCurrentWhatIfFlagAndPreference()
        {
            if (this.MyInvocation.BoundParameters.GetOrNull("WhatIf") is SwitchParameter whatIfFlag)
            {
                return whatIfFlag.IsPresent;
            }

            if (this.SessionState == null)
            {
                return false;
            }

            object whatIfPreference = this.SessionState.PSVariable.GetValue("WhatIfPreference");

            return whatIfPreference is SwitchParameter whatIfPreferenceFlag
                ? whatIfPreferenceFlag.IsPresent
                : (bool)whatIfPreference;
        }

        private bool ShouldProcessGivenCurrentConfirmFlagAndPreference()
        {
            if (this.MyInvocation.BoundParameters.GetOrNull("Confirm") is SwitchParameter confirmFlag)
            {
                return confirmFlag.IsPresent;
            }

            if (this.SessionState == null)
            {
                return false;
            }

            var confirmPreference = (ConfirmImpact)this.SessionState.PSVariable.GetValue("ConfirmPreference");

            return this.ConfirmImpact >= confirmPreference;
        }

        public override object GetDynamicParameters()
        {
            if (!string.IsNullOrEmpty(QueryString))
            {
                protectedTemplateUri = TemplateUri + "?" + QueryString;
            }
            return base.GetDynamicParameters();
        }
    }
}
