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

using System;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry
{
    /// <summary>
    /// The telemetry client that collects data at the interested places.
    /// </summary>
    public interface ITelemetryClient
    {
        /// <summary>
        /// Gets the id to identify the events proceeding to a CommandHistory
        /// </summary>
        public string CommandId { get; }

        /// <summary>
        /// Gets and sets the id to correlate the request and the server.
        /// </summary>
        public string RequestId { get; set; }

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
        /// Collects when we return a suggestion.
        /// </summary>
        /// <param name="telemetryData">The data to collect.</param>
        public void OnGetSuggestion(GetSuggestionTelemetryData telemetryData);

        /// <summary>
        /// Collects when a suggestion is displayed.
        /// </summary>
        /// <param name="telemetryData">The data to collect.</param>
        public void OnSuggestionDisplayed(SuggestionDisplayedTelemetryData telemetryData);

        /// <summary>
        /// Collects when a suggestion is accepted.
        /// </summary>
        /// <param name="telemetryData">The data to collect.</param>
        public void OnSuggestionAccepted(SuggestionAcceptedTelemetryData telemetryData);

        /// <summary>
        /// Collects when we load parameter map file.
        /// </summary>
        /// <param name="telemetryData">The data to collect.</param>
        public void OnLoadParameterMap(ParameterMapTelemetryData telemetryData);

        /// <summary>
        /// Collects when there is a non-specific failure in the code.
        /// </summary>
        /// <remarks>
        /// Use the other methods to record the exceptions in those events.
        /// This is only used when it's not in any specific telemetry event.
        /// </remarks>
        public void OnGeneralException(GeneralExceptionTelemetryData e);
    }
}
