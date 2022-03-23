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
using System.Timers;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// An intrface to decide whether we should prompt an suvey and do so.
    /// </summary>
    internal sealed class AzPredictorSurveyHelper : ISurveyHelper, IDisposable
    {
        private static readonly string _ModuleName = "Az.Predictor";
        private static readonly Version _ModuleVersion = typeof(AzPredictorSurveyHelper).Assembly.GetName().Version;
        private static readonly SurveyHelper _sharedSurveyHelper = SurveyHelper.GetInstance();

        private readonly PSEventManager _powerShellEventManager;
        private PSEventSubscriber _idleEventSubscriber = null;

        private DateTime _lastCheckedTime = DateTime.MinValue;
        private Timer _promptDelayTimer;

        public AzPredictorSurveyHelper(IPowerShellRuntime powerShellRuntime)
        {
            var host = powerShellRuntime.HostName;

            if ((host.IndexOf("Visual Studio Code", StringComparison.InvariantCultureIgnoreCase) == -1) &&
                !string.Equals(host, AzPredictorConstants.MockPSHostName, StringComparison.Ordinal))
            {
                var promptMessageScript = @"
                    if ([Microsoft.Azure.PowerShell.Tools.AzPredictor.AzPredictorData]::ShowSurveyOnIdle) {
                        [Microsoft.Azure.PowerShell.Tools.AzPredictor.AzPredictorData]::ShowSurveyOnIdle = $False
                        Write-Host ''
                        Write-Host ''; Write-Host `Survey: -ForegroundColor $Host.PrivateData.VerboseBackgroundColor -BackgroundColor $host.PrivateData.VerboseForegroundColor -NoNewLine; Write-Host ' How was your experience using the Az Predictor module?'
                        Write-Host ''
                        Write-Host 'Run ' -NoNewline; Write-Host Open-AzPredictorSurvey -ForegroundColor $Host.PrivateData.VerboseBackgroundColor -BackgroundColor $host.PrivateData.VerboseForegroundColor -NoNewline; Write-Host ' to give us your feedback.'
                        Write-Host ''
                        Write-Host '(Use ""Ctrl + C"" to return to the prompt)'
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

                _promptDelayTimer = new Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
                _promptDelayTimer.Elapsed += OnPromptDelayTimer;
            }
        }

        public void Dispose()
        {
            AzPredictorData.ShowSurveyOnIdle = false;

            if (_idleEventSubscriber is not null)
            {
                _powerShellEventManager.UnsubscribeEvent(_idleEventSubscriber);
                _idleEventSubscriber = null;
            }

            if (_promptDelayTimer is not null)
            {
                _promptDelayTimer.Elapsed -= OnPromptDelayTimer;
                _promptDelayTimer.Dispose();
                _promptDelayTimer = null;
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
                return _sharedSurveyHelper.ShouldPropmtSurvey(_ModuleName, _ModuleVersion);
            }

            return false;
        }

        /// <inheritdoc/>
        public void PromptSurvey()
        {
            _promptDelayTimer.Enabled = true;
        }

        private void OnPromptDelayTimer(object sender, ElapsedEventArgs args)
        {
            _promptDelayTimer.Enabled = false;
            AzPredictorData.ShowSurveyOnIdle = true;
        }
    }
}
