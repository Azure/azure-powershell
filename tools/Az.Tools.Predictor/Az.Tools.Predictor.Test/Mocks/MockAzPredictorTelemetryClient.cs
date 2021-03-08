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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry;
using System;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test.Mocks
{
    sealed class MockAzPredictorTelemetryClient : ITelemetryClient
    {
        public class RecordedSuggestionForHistory
        {
            public string HistoryLine { get; set; }
        }

        /// <inheritdoc/>
        public string SessionId { get; } = Guid.NewGuid().ToString();

        /// <inheritdoc/>
        public string CorrelationId { get; private set; } = Guid.NewGuid().ToString();

        public RecordedSuggestionForHistory RecordedSuggestion { get; set; }
        public int SuggestionAccepted { get; set; }

        /// <inheritdoc/>
        public void OnHistory(HistoryTelemetryData telemetryData)
        {
            this.RecordedSuggestion = new RecordedSuggestionForHistory()
            {
                HistoryLine = telemetryData.Command,
            };
        }

        /// <inheritdoc/>
        public void OnRequestPrediction(RequestPredictionTelemetryData telemetryData)
        {
        }

        /// <inheritdoc/>
        public void OnSuggestionAccepted(SuggestionAcceptedTelemetryData telemetryData)
        {
            ++this.SuggestionAccepted;
        }

        /// <inheritdoc/>
        public void OnGetSuggestion(GetSuggestionTelemetryData telemetryData)
        {
        }

        /// <inheritdoc/>
        public void OnLoadParameterMap(ParameterMapTelemetryData telemetryData)
        {
        }

    }
}
