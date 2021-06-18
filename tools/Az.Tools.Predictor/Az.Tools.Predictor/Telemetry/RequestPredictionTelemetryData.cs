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

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry
{
    /// <summary>
    /// The data to collect in <see cref="ITelemetryClient.OnRequestPrediction"/>.
    /// </summary>
    public sealed class RequestPredictionTelemetryData : ITelemetryData
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
        /// Gets the masked command lines that are used to request prediction.
        /// </summary>
        public IEnumerable<string> Commands { get; } // ["Get-AzContext", "Get-AzVM"]

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
        /// Creates an instance of <see cref="RequestPredictionTelemetryData"/>.
        /// </summary>
        /// <param name="clientId">The client id that makes the call.</param>
        /// <param name="commands">The commands to request prediction for.</param>
        /// <param name="hasSentHttpRequest">The flag to indicate whether the http request is canceled.</param>
        /// <param name="exception">The exception that may be thrown.</param>
        public RequestPredictionTelemetryData(string clientId, IEnumerable<string> commands, bool hasSentHttpRequest, Exception exception)
        {
            ClientId = clientId;
            Commands = commands;
            HasSentHttpRequest = hasSentHttpRequest;
            Exception = exception;
        }
    }
}
