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

using System.Text;
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// A cmdlet that disable Az Predictor.
    /// </summary>
    [Cmdlet("Disable", "AzPredictor")]
    public sealed class DisableAzPredictor : PSCmdlet
    {
        private static readonly string[] _DisableStatements = {
            "Set-PSReadLineOption -PredictionSource History"
        };

        /// <summary>
        /// Indicates whether it's applied to all sessions.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter AllSession { get; set; }

        /// <summary>
        /// Indicates whether the user would like to receive output.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <inheritdoc/>
        protected override void ProcessRecord()
        {
            var scriptToRun = new StringBuilder();
            var _ = scriptToRun.Append(DisableAzPredictor._DisableStatements[0]);

            if (AllSession.IsPresent)
            {
                _ = scriptToRun.Append(";Write-Host \"To disable Az Predictor, please edit your profile ($PROFILE) and remove the following lines:`nImport-Module Az.Tools.Predictor`nSet-PSReadLineOption -PredictionSource HistoryAndPlugin`n\"");
            }

            InvokeCommand.InvokeScript(scriptToRun.ToString());

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
