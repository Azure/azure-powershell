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

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry
{
    /// <summary>
    /// The telemetry client that collects and sends the telemetry data.
    /// </summary>
    public interface ITelemetryClient
    {
        /// <summary>
        /// Gets the correlation id for the telemetry events.
        /// </summary>
        public string CorrelationId { get; }

        /// <summary>
        /// Gets the session id for the telemetry events.
        /// </summary>
        public string SessionId { get; }

        /// <summary>
        /// Collects the event of the history command.
        /// </summary>
        /// <param name="telemetryData">The data to collect.</param>
        public void OnHistory(HistoryTelemetryData telemetryData);

        /// <summary>
        /// Collects the event when a prediction is requested.
        /// </summary>
        /// <param name="telemetryData">The data to collect.</param>
        public void OnRequestPrediction(RequestPredictionTelemetryData telemetryData);

        /// <summary>
        /// Collects when a suggestion is accepted.
        /// </summary>
        /// <param name="telemetryData">The data to collect.</param>
        public void OnSuggestionAccepted(SuggestionAcceptedTelemetryData telemetryData);

        /// <summary>
        /// Collects when we return a suggestion.
        /// </summary>
        /// <param name="telemetryData">The data to collect.</param>
        public void OnGetSuggestion(GetSuggestionTelemetryData telemetryData);

        /// <summary>
        /// Collects when we load parameter map file.
        /// </summary>
        /// <param name="telemetryData">The data to collect.</param>
        public void OnLoadParameterMap(ParameterMapTelemetryData telemetryData);
    }
}
