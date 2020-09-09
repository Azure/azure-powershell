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

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Microsoft.Azure.PowerShell.AzPredictor
{
    /// <summary>
    /// A telemetry client implementation to collect the telemetry data for AzPredictor
    /// </summary>
    sealed class AzPredictorTelemetryClient : ITelemetryClient
    {
        /// <summary>
        /// A simple session class that provides neccessary information to get the profile.
        /// </summary>
        private sealed class TelemetrySession : AzureSession
        {
            /// <summary>
            /// Constructs a new instance of <see cref="TelemetrySession" />
            /// </summary>
            public TelemetrySession()
            {
                this.DataStore = new DiskDataStore();
                this.ProfileDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    AzPredictorConstants.AzureProfileDirectoryName);
            }

            /// <inheritdoc/>
            public override TraceLevel AuthenticationLegacyTraceLevel
            {
                get => TraceLevel.Off;
                set { }
            }

            /// <inheritdoc/>
            public override TraceListenerCollection AuthenticationTraceListeners => Trace.Listeners;

            /// <inheritdoc/>
            public override SourceLevels AuthenticationTraceSourceLevel
            {
                get => SourceLevels.Off;
                set { }
            }
        }

        private readonly TelemetryClient _telemetryClient;
        private int _accepts;
        private readonly string _sessionId;

        private object lockObject = new object();
        private AzurePSDataCollectionProfile _cachedProfile;

        private AzurePSDataCollectionProfile DataCollectionProfile
        {
            get
            {
                lock (lockObject)
                {
                    if (_cachedProfile == null)
                    {
                        var controller = DataCollectionController.Create(new TelemetrySession());
                        this._cachedProfile = controller.GetProfile(() => { });
                    }

                    return this._cachedProfile;
                }
            }
        }

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorTelemetryClient"/>
        /// </summary>
        public AzPredictorTelemetryClient()
        {
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = "7df6ff70-8353-4672-80d6-568517fed090"; // Use Azuer-PowerShell instrumentation key. see https://github.com/Azure/azure-powershell-common/blob/master/src/Common/AzurePSCmdlet.cs
            _telemetryClient = new TelemetryClient(configuration);
            _sessionId = Guid.NewGuid().ToString();
        }

        /// <inheritdoc/>
        public void OnSuggestionForHistory(string historyLine,
                             int? suggestionIndex,
                             int? fallbackIndex,
                             IEnumerable<string> topSuggestions)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            var currentLog = new Dictionary<string, string>();
            currentLog["History"] = historyLine;
            currentLog["SessionId"] = _sessionId;

            if (suggestionIndex.HasValue)
            {
                currentLog["SuggestionIndex"] = suggestionIndex.Value.ToString(CultureInfo.InvariantCulture);
            }

            if (fallbackIndex.HasValue)
            {
                currentLog["FallbackIndex"] = fallbackIndex.Value.ToString(CultureInfo.InvariantCulture);
            }

            if (topSuggestions != null)
            {
                currentLog["Top5Suggestions"] = string.Join(',', topSuggestions.Take(5));
            }

            this._telemetryClient.TrackEvent("GetSuggestion", currentLog);
        }

        /// <inheritdoc/>
        public void OnSuggestionAccepted(string acceptedSuggestion)
        {
            ++this._accepts;

            if (!IsDataCollectionAllowed())
            {
                return;
            }
        }

        /// <summary>
        /// Check whether the data collection is opted in from user
        /// </summary>
        /// <returns>true if allowed</returns>
        private bool IsDataCollectionAllowed()
        {
            if (DataCollectionProfile != null &&
                DataCollectionProfile.EnableAzureDataCollection.HasValue &&
                DataCollectionProfile.EnableAzureDataCollection.Value)
            {
                return true;
            }

            return false;
        }
    }
}
