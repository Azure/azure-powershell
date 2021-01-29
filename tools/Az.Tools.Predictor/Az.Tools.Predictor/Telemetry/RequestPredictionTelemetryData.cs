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
    /// The data to collect in <see cref="ITelemetryClient.OnRequestPrediction"/>.
    /// </summary>
    public sealed class RequestPredictionTelemetryData : ITelemetryData
    {
        /// <inheritdoc/>
        string ITelemetryData.SessionId { get; set; }

        /// <inheritdoc/>
        string ITelemetryData.CorrelationId { get; set; }

        /// <summary>
        /// Gets the masked command lines that are used to request prediction.
        /// </summary>
        public string Commands { get; } // "Get-AzContext\nGet-AzVM" /predictions

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
        /// <param name="commands">The commands to request prediction for.</param>
        /// <param name="hasSentHttpRequest">The flag to indicate whether the http request is canceled.</param>
        /// <param name="exception">The exception that may be thrown.</param>
        public RequestPredictionTelemetryData(string commands, bool hasSentHttpRequest, Exception exception)
        {
            Commands = commands;
            HasSentHttpRequest = hasSentHttpRequest;
            Exception = exception;
        }
    }
}
