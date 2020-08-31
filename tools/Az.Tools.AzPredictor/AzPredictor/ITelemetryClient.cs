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

namespace Microsoft.Azure.PowerShell.AzPredictor
{
    /// <summary>
    /// The telemetry client that collects and sends the telemetry data.
    /// </summary>
    public interface ITelemetryClient
    {
        /// <summary>
        /// Collects the event for the top 5 predeiction for the history.
        /// </summary>
        /// <param name="historyLine">The history command that triggers the suggestion.</param>
        /// <param name="suggestionIndex">The index of the suggestion from the suggestion model.</param>
        /// <param name="fallbackIndex">The index in the command list as a fallback.</param>
        /// <param name="topSuggestions">The top suggestions.</param>
        public void OnSuggestionForHistory(string historyLine, int? suggestionIndex, int? fallbackIndex, IEnumerable<string> topSuggestions);

        /// <summary>
        /// Collects when a suggestion is accepted.
        /// </summary>
        /// <param name="acceptedSuggestion">The suggestion that's accepted by the user.</param>
        public void OnSuggestionAccepted(string acceptedSuggestion);
    }
}
