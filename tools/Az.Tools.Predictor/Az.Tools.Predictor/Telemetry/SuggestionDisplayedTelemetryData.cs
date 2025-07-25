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

using System.Management.Automation.Subsystem.Prediction;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry
{
    /// <summary>
    /// The data to collect in <see cref="ITelemetryClient.OnSuggestionDisplayed"/>.
    /// </summary>
    public sealed class SuggestionDisplayedTelemetryData : ITelemetryData
    {
        /// <summary>
        /// The telemetry property name for "Displayed".
        /// </summary>
        public const string PropertyNameDisplayed = "Displayed";

        /// <inheritdoc/>
        public PredictionClient Client { get; init; }

        /// <inheritdoc/>
        string ITelemetryData.CommandId { get; set; }

        /// <inheritdoc/>
        string ITelemetryData.RequestId { get; set; }

        /// <summary>
        /// The mode the suggestion is displayed in.
        /// </summary>
        public SuggestionDisplayMode DisplayMode { get; init; }

        /// <summary>
        /// Gets the information about the suggestions displayed to the user.
        /// When <see cref="SuggestionDisplayMode"/> is <see cref="SuggestionDisplayMode.ListView"/>, this is the number of suggestions displayed
        /// on the list. When <see cref="SuggestionDisplayMode"/> is <see cref="SuggestionDisplayMode.InlineView"/>, this is the index of the
        /// suggestion displayed. There is only one suggestion display in <see cref="SuggestionDisplayMode.InlineView"/>.
        /// All the index are zero-based.
        /// </summary>
        public int SuggestionCountOrIndex { get; }

        /// <summary>
        /// Gets the id of the client that makes the calls.
        /// </summary>
        public uint SuggestionSessionId { get; init; }

        /// <summary>
        /// Creates a new instance of <see cref="SuggestionDisplayedTelemetryData"/>.
        /// </summary>
        /// <param name="client">The client that makes the call.</param>
        /// <param name="suggestionSessionId">The suggestion session id.</param>
        /// <param name="displayMode">The mode the suggestion is displayed in.</param>
        /// <param name="suggestionCountOrIndex">The index or count of the suggestions displayed.</param>
        private SuggestionDisplayedTelemetryData(PredictionClient client, uint suggestionSessionId, SuggestionDisplayMode displayMode, int suggestionCountOrIndex)
        {
            Client = client;
            SuggestionSessionId = suggestionSessionId;
            DisplayMode = displayMode;
            SuggestionCountOrIndex = suggestionCountOrIndex;
        }

        /// <summary>
        /// Creates a new instance of <see cref="SuggestionDisplayedTelemetryData"/> for the suggestions displayed in
        /// <see cref="SuggestionDisplayMode.InlineView"/>.
        /// </summary>
        /// <param name="client">The client that makes the call.</param>
        /// <param name="suggestionSessionId">The suggestion session id.</param>
        /// <param name="index">The index of the suggestion that's displayed.</param>
        public static SuggestionDisplayedTelemetryData CreateForInlineView(PredictionClient client, uint suggestionSessionId, int index)
        {
            return new SuggestionDisplayedTelemetryData(client, suggestionSessionId, SuggestionDisplayMode.InlineView, index);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SuggestionDisplayedTelemetryData"/> for the suggestions displayed in
        /// <see cref="SuggestionDisplayMode.ListView"/>.
        /// </summary>
        /// <param name="client">The client that makes the call.</param>
        /// <param name="suggestionSessionId">The suggestion session id.</param>
        /// <param name="count">The count of the suggestions that are displayed.</param>
        public static SuggestionDisplayedTelemetryData CreateForListView(PredictionClient client, uint suggestionSessionId, int count)
        {
            return new SuggestionDisplayedTelemetryData(client, suggestionSessionId, SuggestionDisplayMode.ListView, count);
        }
    }
}
