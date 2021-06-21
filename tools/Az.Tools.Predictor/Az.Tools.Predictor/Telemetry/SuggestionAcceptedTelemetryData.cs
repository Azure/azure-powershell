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
    /// The data to collect in <see cref="ITelemetryClient.OnSuggestionAccepted"/>.
    /// </summary>
    public sealed class SuggestionAcceptedTelemetryData : ITelemetryData
    {
        /// <inheritdoc/>
        string ITelemetryData.CommandId { get; set; }

        /// <inheritdoc/>
        string ITelemetryData.RequestId { get; set; }

        /// <inheritdoc/>
        string ITelemetryData.SessionId { get; set; }

        /// <summary>
        /// Gets the id of the client that makes the calls.
        /// </summary>
        public string ClientId { get; init; }

        /// <summary>
        /// Gets the suggestion that's accepted by the user.
        /// </summary>
        public string Suggestion { get; }

        /// <summary>
        /// Gets the id of the client that makes the calls.
        /// </summary>
        public uint SuggestionSessionId { get; init; }

        /// <summary>
        /// Creates a new instance of <see cref="SuggestionAcceptedTelemetryData"/>.
        /// </summary>
        /// <param name="clientId">The client id that makes the call.</param>
        /// <param name="suggestionSessionId">The suggestion session id.</param>
        /// <param name="suggestion">The suggestion that's accepted by the user.</param>
        public SuggestionAcceptedTelemetryData(string clientId, uint suggestionSessionId, string suggestion)
        {
            ClientId = clientId;
            SuggestionSessionId = suggestionSessionId;
            Suggestion = suggestion;
        }
    }
}
