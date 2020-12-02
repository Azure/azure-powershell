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
using System.Threading;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// The collection of the data that're collected in telemetry.
    /// </summary>
    public static class TelemetryData
    {
        /// <summary>
        /// An interface that all telemetry data class should implement.
        /// </summary>
        public interface ITelemetryData
        {
            /// <summary>
            /// Gets the session id.
            /// </summary>
            string SessionId { get; }

            /// <summary>
            /// Gets the correlation id.
            /// </summary>
            string CorrelationId { get; }
        }

        /// <summary>
        /// The data to collect in <see cref="ITelemetryClient.OnHistory"/>.
        /// </summary>
        public sealed class History : ITelemetryData
        {
            /// <inheritdoc/>
            public string SessionId { get; internal set; }

            /// <inheritdoc/>
            public string CorrelationId { get; internal set; }

            /// <summary>
            /// Gets the history command line.
            /// </summary>
            public string Command { get; }

            /// <summary>
            /// Creates a new instance of <see cref="History"/>.
            /// </summary>
            /// <param name="command">The history command line.</param>
            public History(string command) => Command = command;
        }

        /// <summary>
        /// The data to collect in <see cref="ITelemetryClient.OnRequestPrediction"/>.
        /// </summary>
        public sealed class RequestPrediction : ITelemetryData
        {
            /// <inheritdoc/>
            public string SessionId { get; internal set; }

            /// <inheritdoc/>
            public string CorrelationId { get; internal set; }

            /// <summary>
            /// Gets the masked command lines that are used to request prediction.
            /// </summary>
            public string Commands { get; }

            /// <summary>
            /// Gets whether the http request to the service is sent.
            /// </summary>
            public bool HasSentHttpRequest { get; }

            /// <summary>
            /// Gets the exception if there is an error during the operation.
            /// </summary>
            /// <remarks>
            /// OperationCanceledException isn't considered an error.
            /// </remarks>
            public Exception Exception { get; }

            /// <summary>
            /// Creates an instance of <see cref="RequestPrediction"/>.
            /// </summary>
            /// <param name="commands">The commands to request prediction for.</param>
            /// <param name="hasSentHttpRequest">The flag to indicate whether the http request is canceled.</param>
            /// <param name="exception">The exception that may be thrown.</param>
            public RequestPrediction(string commands, bool hasSentHttpRequest, Exception exception)
            {
                Commands = commands;
                HasSentHttpRequest = hasSentHttpRequest;
                Exception = exception;
            }
        }

        /// <summary>
        /// The data to collect in <see cref="ITelemetryClient.OnGetSuggestion"/>.
        /// </summary>
        public sealed class GetSuggestion : ITelemetryData
        {
            /// <inheritdoc/>
            public string SessionId { get; internal set; }

            /// <inheritdoc/>
            public string CorrelationId { get; internal set; }

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
            /// Creates a new instance of <see cref="GetSuggestion"/>.
            /// </summary>
            /// <param name="userInput">The user input that the <paramref name="suggestion"/> is for.</param>
            /// <param name="suggestion">The suggestions returned for the <paramref name="userInput"/>.</param>
            /// <param name="isCancellationRequested">Indicates if the cancellation has been requested.</param>
            /// <param name="exception">The exception that is thrown if there is an error.</param>
            public GetSuggestion(Ast userInput, CommandLineSuggestion suggestion, bool isCancellationRequested, Exception exception)
            {
                UserInput = userInput;
                Suggestion = suggestion;
                IsCancellationRequested = isCancellationRequested;
                Exception = exception;
            }
        }

        /// <summary>
        /// The data to collect in <see cref="ITelemetryClient.OnSuggestionAccepted"/>.
        /// </summary>
        public sealed class SuggestionAccepted : ITelemetryData
        {
            /// <inheritdoc/>
            public string SessionId { get; internal set; }

            /// <inheritdoc/>
            public string CorrelationId { get; internal set; }

            /// <summary>
            /// Gets the suggestion that's accepted by the user.
            /// </summary>
            public string Suggestion { get; }

            /// <summary>
            /// Creates a new instance of <see cref="SuggestionAccepted"/>.
            /// </summary>
            public SuggestionAccepted(string suggestion) => Suggestion = suggestion;
        }
    }
}
