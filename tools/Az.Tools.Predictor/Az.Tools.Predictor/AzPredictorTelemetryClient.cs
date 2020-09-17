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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
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
                DataStore = new DiskDataStore();
                ProfileDirectory = Path.Combine(
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

        /// <inheritdoc/>
        public string SessionId { get; } = Guid.NewGuid().ToString();

        /// <inheritdoc/>
        public string CorrelationId { get; private set; } = Guid.NewGuid().ToString();

        private readonly TelemetryClient _telemetryClient;

        private object lockObject = new object();
        private AzurePSDataCollectionProfile _cachedProfile;

        private AzurePSDataCollectionProfile DataCollectionProfile
        {
            get
            {
                if (_cachedProfile != null)
                {
                    return _cachedProfile;
                }

                lock (lockObject)
                {
                    if (_cachedProfile == null)
                    {
                        var controller = DataCollectionController.Create(new TelemetrySession());
                        _cachedProfile = controller.GetProfile(() => { });
                    }

                    return _cachedProfile;
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
        }

        /// <inheritdoc/>
        public void OnHistory(string historyLine)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            var currentLog = new Dictionary<string, string>()
            {
                { "History", historyLine },
                { "SessionId", SessionId },
                { "CorrelationId", CorrelationId },
            };

            _telemetryClient.TrackEvent("CommandHistory", currentLog);

#if DEBUG
            Console.WriteLine("Recording CommandHistory");
#endif
        }

        /// <inheritdoc/>
        public void OnRequestPrediction(string command)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            CorrelationId = Guid.NewGuid().ToString();

            var currentLog = new Dictionary<string, string>()
            {
                { "Command", command },
                { "SessionId", SessionId },
                { "CorrelationId", CorrelationId },
            };

            _telemetryClient.TrackEvent("RequestPrediction", currentLog);

#if DEBUG
            Console.WriteLine("Recording RequestPrediction");
#endif
        }

        /// <inheritdoc/>
        public void OnSuggestionAccepted(string acceptedSuggestion)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            var properties = new Dictionary<string, string>()
            {
                { "AcceptedSuggestion", acceptedSuggestion },
                { "SessionId", SessionId },
                { "CorrelationId", CorrelationId },
            };

            _telemetryClient.TrackEvent("AcceptSuggestion", properties);

#if DEBUG
            Console.WriteLine("Recording AcceptSuggestion");
#endif
        }

        /// <inheritdoc/>
        public void OnGetSuggestion(IEnumerable<Tuple<string, PredictionSource>> suggestions, bool isCancelled)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            var properties = new Dictionary<string, string>()
            {
                { "Suggestion", JsonConvert.SerializeObject(suggestions) },
                { "SessionId", SessionId },
                { "CorrelationId", CorrelationId },
                { "IsCancelled", isCancelled.ToString(CultureInfo.InvariantCulture) },
            };

            _telemetryClient.TrackEvent("GetSuggestion", properties);

#if DEBUG
            Console.WriteLine("Recording GetSuggestioin");
#endif
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
