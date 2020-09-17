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
using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
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
        /// <param name="historyLine">The history command from PSReadLine.</param>
        public void OnHistory(string historyLine);

        /// <summary>
        /// Collects the event when a prediction is requested.
        /// </summary>
        /// <param name="command">The command to that we request the prediction for.</param>
        public void OnRequestPrediction(string command);

        /// <summary>
        /// Collects when a suggestion is accepted.
        /// </summary>
        /// <param name="acceptedSuggestion">The suggestion that's accepted by the user.</param>
        public void OnSuggestionAccepted(string acceptedSuggestion);

        /// <summary>
        /// Collects when we return a suggestion
        /// </summary>
        /// <param name="suggestions">The list of suggestion and its source</param>
        /// <param name="isCancelled">Indicates whether the caller has cancelled the call to get suggestion. Usually that's because of time out </param>
        public void OnGetSuggestion(IEnumerable<Tuple<string, PredictionSource>> suggestions, bool isCancelled);
    }
}
