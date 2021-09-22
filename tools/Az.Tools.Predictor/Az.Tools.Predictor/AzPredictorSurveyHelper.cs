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

using Microsoft.Azure.PowerShell.Common.Share.Survey;
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// An intrface to decide whether we should prompt an suvey and do so.
    /// </summary>
    internal sealed class AzPredictorSurveyHelper : ISurveyHelper
    {
        private const string _PromptMessageScript = "Write-Host \"---------------------------------------------------\""
            + "Write-Host \"Survey:\" -ForegroundColor $Host.PrivateData.VerboseBackgroundColor -BackgroundColor $host.PrivateData.VerboseForegroundColor -NoNewline;"
            + "Write-Host \" How was your experience using the Az Predictor module?\";"
            + "Write-Host \"\";"
            + "Write-Host \"Run \" -NoNewline; Write-Host \"Open-AzPredictorSurvey\" -ForegroundColor $Host.PrivateData.VerboseBackgroundColor -BackgroundColor $host.PrivateData.VerboseForegroundColor -NoNewline; Write-Host \" to give us your feedback.\";"
            + "Write-Host \"---------------------------------------------------\";";

        private static readonly string _ModuleName = typeof(AzPredictorSurveyHelper).Assembly.GetName().Name;
        private static readonly Version _ModuleVersion = typeof(AzPredictorSurveyHelper).Assembly.GetName().Version;
        private static readonly SurveyHelper _sharedSurveyHelper = SurveyHelper.GetInstance();

        private readonly PowerShellRuntime _powerShellRuntime;

        public AzPredictorSurveyHelper(PowerShellRuntime powerShellRuntime) => _powerShellRuntime = powerShellRuntime;

        /// <inheritdoc/>
        public bool ShouldPromptSurvey() => _sharedSurveyHelper.ShouldPropmtSurvey(_ModuleName, _ModuleVersion);

        /// <inheritdoc/>
        public void PromptSurvey()
        {
            _powerShellRuntime.ExecuteScript<string>(AzPredictorSurveyHelper._PromptMessageScript);
        }
    }
}
