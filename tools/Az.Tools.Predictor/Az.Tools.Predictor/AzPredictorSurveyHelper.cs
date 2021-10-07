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
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// An intrface to decide whether we should prompt an suvey and do so.
    /// </summary>
    internal sealed class AzPredictorSurveyHelper : ISurveyHelper, IDisposable
    {
        private static readonly string _ModuleName = "Az.Predictor";
        private static readonly Version _ModuleVersion = new Version("1.0.0.0"); //typeof(AzPredictorSurveyHelper).Assembly.GetName().Version;
        private static readonly SurveyHelper _sharedSurveyHelper = SurveyHelper.GetInstance();

        private readonly PSEventManager _powerShellEventManager;
        private PSEventSubscriber _idleEventSubscriber = null;

        private DateTime _lastCheckedTime = DateTime.MinValue;

        public AzPredictorSurveyHelper(PowerShellRuntime powerShellRuntime)
        {
            var promptMessageScript = @"
                if ([Microsoft.Azure.PowerShell.Tools.AzPredictor.AzPredictorData]::ShowSurveyOnIdle) {
                    Write-Host `n---------------------------------------------------
                    Write-Host Survey: -ForegroundColor $Host.PrivateData.VerboseBackgroundColor -BackgroundColor $host.PrivateData.VerboseForegroundColor -NoNewline
                    Write-Host ' How was your experience using the Az Predictor module?'
                    Write-Host ''
                    Write-Host 'Run ' -NoNewline; Write-Host Open-AzPredictorSurvey -ForegroundColor $Host.PrivateData.VerboseBackgroundColor -BackgroundColor $host.PrivateData.VerboseForegroundColor -NoNewline; Write-Host ' to give us your feedback.'
                    Write-Host ---------------------------------------------------
                    [Microsoft.Azure.PowerShell.Tools.AzPredictor.AzPredictorData]::ShowSurveyOnIdle = $False
                }";

            ScriptBlock scriptBlock = ScriptBlock.Create(promptMessageScript);
            _powerShellEventManager = powerShellRuntime.ConsoleRuntime.Runspace.Events;
            _idleEventSubscriber = _powerShellEventManager.SubscribeEvent(source: null,
                eventName: null,
                sourceIdentifier: PSEngineEvent.OnIdle,
                data: null,
                action: scriptBlock,
                supportEvent: true,
                forwardEvent: false);
        }

        public void Dispose()
        {
            AzPredictorData.ShowSurveyOnIdle = false;

            if (_idleEventSubscriber != null)
            {
                _powerShellEventManager.UnsubscribeEvent(_idleEventSubscriber);
                _idleEventSubscriber = null;
            }
        }

        /// <inheritdoc/>
        public bool ShouldPromptSurvey()
        {
            // Since we only consider days when we decide whether to show the survey. So we don't need to call
            // _sharedSurveyHelper.ShouldPromptSurvey more than once per day.
            if ((_lastCheckedTime == DateTime.MinValue) || (_lastCheckedTime.AddDays(1) <= DateTime.Now))
            {
                _lastCheckedTime = DateTime.Now;
                retur _sharedSurveyHelper.ShouldPropmtSurvey(_ModuleName, _ModuleVersion);
            }

            return false;
        }

        /// <inheritdoc/>
        public void PromptSurvey()
        {
            AzPredictorData.ShowSurveyOnIdle = true;
        }
    }
}
