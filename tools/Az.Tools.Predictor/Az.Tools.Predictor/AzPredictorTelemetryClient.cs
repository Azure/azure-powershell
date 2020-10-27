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
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Profile;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// A telemetry client implementation to collect the telemetry data for AzPredictor
    /// </summary>
    sealed class AzPredictorTelemetryClient : ITelemetryClient
    {
        private const string TelemetryEventPrefix = "Az.Tools.Predictor";

        /// <inheritdoc/>
        public string SessionId { get; } = Guid.NewGuid().ToString();

        /// <inheritdoc/>
        public string CorrelationId { get; private set; } = Guid.NewGuid().ToString();

        private readonly TelemetryClient _telemetryClient;

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorTelemetryClient"/>
        /// </summary>
        public AzPredictorTelemetryClient()
        {
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = "7df6ff70-8353-4672-80d6-568517fed090"; // Use Azuer-PowerShell instrumentation key. see https://github.com/Azure/azure-powershell-common/blob/master/src/Common/AzurePSCmdlet.cs
            _telemetryClient = new TelemetryClient(configuration);
            _telemetryClient.Context.Location.Ip = "0.0.0.0";
            _telemetryClient.Context.Cloud.RoleInstance = "placeholderdon'tuse";
            _telemetryClient.Context.Cloud.RoleName = "placeholderdon'tuse";
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

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/CommandHistory", currentLog);

#if TELEMETRY_TRACE && DEBUG
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

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/RequestPrediction", currentLog);

#if TELEMETRY_TRACE && DEBUG
            Console.WriteLine("Recording RequestPrediction");
#endif
        }

        /// <inheritdoc/>
        public void OnRequestPredictionError(string command, Exception e)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            var currentLog = new Dictionary<string, string>()
            {
                { "Command", command },
                { "SessionId", SessionId },
                { "CorrelationId", CorrelationId },
                { "Exception", e.ToString() },
            };

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/RequestPredictionError", currentLog);

#if TELEMETRY_TRACE && DEBUG
            Console.WriteLine("Recording RequestPredictionError");
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

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/AcceptSuggestion", properties);

#if TELEMETRY_TRACE && DEBUG
            Console.WriteLine("Recording AcceptSuggestion");
#endif
        }

        /// <inheritdoc/>
        public void OnGetSuggestion(string maskedUserInput, IEnumerable<ValueTuple<string, PredictionSource>> suggestions, bool isCancelled)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            var properties = new Dictionary<string, string>()
            {
                { "UserInput", maskedUserInput },
                { "Suggestion", JsonConvert.SerializeObject(suggestions) },
                { "SessionId", SessionId },
                { "CorrelationId", CorrelationId },
                { "IsCancelled", isCancelled.ToString(CultureInfo.InvariantCulture) },
            };

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/GetSuggestion", properties);

#if TELEMETRY_TRACE && DEBUG
            Console.WriteLine("Recording GetSuggestioin");
#endif
        }

        /// <inheritdoc/>
        public void OnGetSuggestionError(Exception e)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            var properties = new Dictionary<string, string>()
            {
                { "SessionId", SessionId },
                { "CorrelationId", CorrelationId },
                { "Exception", e.ToString() },
            };

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/GetSuggestionError", properties);

#if TELEMETRY_TRACE && DEBUG
            Console.WriteLine("Recording GetSuggestioinError");
#endif
        }

        /// <summary>
        /// Check whether the data collection is opted in from user
        /// </summary>
        /// <returns>true if allowed</returns>
        private bool IsDataCollectionAllowed()
        {
            if (AzurePSDataCollectionProfile.Instance.EnableAzureDataCollection == true)
            {
                return true;
            }

            return false;
        }
    }
}
