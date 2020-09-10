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

using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test.Mocks
{
    sealed class MockAzPredictorTelemetryClient : ITelemetryClient
    {
        public class RecordedSuggestionForHistory
        {
            public string HistoryLine { get; set; }
            public int? SuggestionIndex { get; set; }
            public int? FallbackIndex { get; set; }
            public IEnumerable<string> TopSuggestions { get; set; }
        }

        public RecordedSuggestionForHistory RecordedSuggestion { get; set; }
        public int SuggestionAccepted { get; set; }

        /// <inheritdoc/>
        public void OnSuggestionForHistory(string historyLine, int? suggestionIndex, int? fallbackIndex, IEnumerable<string> topSuggestions)
        {
            this.RecordedSuggestion = new RecordedSuggestionForHistory()
            {
                HistoryLine = historyLine,
                SuggestionIndex = suggestionIndex,
                FallbackIndex = fallbackIndex,
                TopSuggestions = topSuggestions
            };
        }

        /// <inheritdoc/>
        public void OnSuggestionAccepted(string acceptedSuggestion)
        {
            ++this.SuggestionAccepted;
        }
    }
}
