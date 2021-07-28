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
    /// The data to collect in <see cref="ITelemetryClient.OnHistory"/>.
    /// </summary>
    public sealed class HistoryTelemetryData : ITelemetryData
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
        /// Gets the history command line.
        /// </summary>
        public string Command { get; }

        /// <summary>
        /// Creates a new instance of <see cref="HistoryTelemetryData"/>.
        /// </summary>
        /// <param name="clientId">The client id that makes the call.</param>
        /// <param name="command">The history command line.</param>
        public HistoryTelemetryData(string clientId, string command)
        {
            ClientId = clientId;
            Command = command;
        }
    }
}
