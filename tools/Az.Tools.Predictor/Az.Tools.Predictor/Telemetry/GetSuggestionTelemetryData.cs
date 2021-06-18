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
using System.Management.Automation.Language;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry
{
    /// <summary>
    /// The data to collect in <see cref="ITelemetryClient.OnGetSuggestion"/>.
    /// </summary>
    public sealed class GetSuggestionTelemetryData : ITelemetryData
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
        /// Gets the user input.
        /// </summary>
        public Ast UserInput { get; }

        /// <summary>
        /// Gets the suggestions to return to the user.
        /// </summary>
        public CommandLineSuggestion Suggestion { get; }

        /// <summary>
        /// Gets whether the cancellation request is already set.
        /// </summary>
        public bool IsCancellationRequested { get; }

        /// <summary>
        /// Gets the exception if there is an error during the operation.
        /// </summary>
        /// <remarks>
        /// OperationCanceledException isn't considered an error.
        /// </remarks>
        public Exception Exception { get; }

        /// <summary>
        /// Gets the id of the suggestion session.
        /// </summary>
        public uint SuggestionSessionId { get; init; }

        /// <summary>
        /// Creates a new instance of <see cref="GetSuggestionTelemetryData"/>.
        /// </summary>
        /// <param name="clientId">The client id that makes the call.</param>
        /// <param name="suggestionSessionId">The suggestion session id.</param>
        /// <param name="userInput">The user input that the <paramref name="suggestion"/> is for.</param>
        /// <param name="suggestion">The suggestions returned for the <paramref name="userInput"/>.</param>
        /// <param name="isCancellationRequested">Indicates if the cancellation has been requested.</param>
        /// <param name="exception">The exception that is thrown if there is an error.</param>
        public GetSuggestionTelemetryData(string clientId, uint suggestionSessionId, Ast userInput, CommandLineSuggestion suggestion, bool isCancellationRequested, Exception exception)
        {
            ClientId = clientId;
            SuggestionSessionId = suggestionSessionId;
            UserInput = userInput;
            Suggestion = suggestion;
            IsCancellationRequested = isCancellationRequested;
            Exception = exception;
        }
    }
}
