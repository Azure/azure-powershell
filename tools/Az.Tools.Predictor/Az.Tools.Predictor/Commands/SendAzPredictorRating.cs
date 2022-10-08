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

using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// <para type="synopsis">Cmdlet to send a rating between 1 and 5 about the suggestions provided by the Az.Tools.Predictor module</para>
    /// <para type="description">This cmdlet sends the given rating about Az.Tools.Predictor to the server. Accepted values for the rating range 1 (poor) - 5 (great). All data from this survey will be anonymized. See the Microsoft Privacy Policy (https://privacy.microsoft.com/) for more information </para>
    /// </summary>
    [Cmdlet("Send", "AzPredictorRating"), OutputType(typeof(bool))]
    public sealed class SendAzPredictorRating : BasePSCmdlet
    {
        /// <summary>
        /// <para type="description">Indicates whether the user would like to receive output. </para>
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Indicates whether the user would like to receive output.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// <para type="description">The rating of Az Predictor: 1 (poor) - 5 (great).</para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "The rating of Az Predictor: 1 (poor) - 5 (great).")]
        [ValidateRange(1, 5)]
        public int Rating { get; set; }

        /// <inheritdoc/>
        protected override void ProcessRecord()
        {
            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
