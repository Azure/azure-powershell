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
    /// <para type="synopsis">Cmdlet to enable Az Predictor and start receiving suggestions</para>
    /// <para type="description">Use this cmdlet to enable Az Predictor and start receiving suggestions</para>
    /// </summary>
    [Cmdlet("Enable", "AzPredictor"), OutputType(typeof(bool))]
    public sealed class EnableAzPredictor : BasePSCmdlet
    {
        private static readonly string[] _EnableStatements = {
            "Import-Module Az.Tools.Predictor",
            "Set-PSReadLineOption -PredictionSource HistoryAndPlugin"
        };

        /// <summary>
        /// <para type="description">Enable Az Predictor for the current and future PowerShell sessions.</para>
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Enable Az Predictor for the current and future PowerShell sessions.")]
        public SwitchParameter AllSession { get; set; }

        /// <summary>
        /// <para type="description">Indicates whether the user would like to receive output. </para>
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Indicates whether the user would like to receive output.")]
        public SwitchParameter PassThru { get; set; }

        /// <inheritdoc/>
        protected override void ProcessRecord()
        {
            var scriptToRun = new StringBuilder();
            var _ = scriptToRun.Append(EnableAzPredictor._EnableStatements[1]);

            if (AllSession.IsPresent)
            {
                _ = scriptToRun.Append($";Add-Content -Path $PROFILE -Value \"`n{string.Join("`n", EnableAzPredictor._EnableStatements)}\" -NoNewline -Encoding UTF8 -Force")
                                .Append($";Write-Host \"User profile ($PROFILE) has been updated.`n\"");
            }

            InvokeCommand.InvokeScript(scriptToRun.ToString());

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
