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
    /// The data to collect in <see cref="ITelemetryClient.OnHistory"/>.
    /// </summary>
    public sealed class HistoryTelemetryData : ITelemetryData
    {
        /// <summary>
        /// The telemetry property name for "Command".
        /// </summary>
        public const string PropertyNameCommand = "Command";

        /// <summary>
        /// The telemetry property name for "Success".
        /// </summary>
        public const string PropertyNameSuccess = "Success";

        /// <inheritdoc/>
        public PredictionClient Client { get; init; }

        /// <inheritdoc/>
        string ITelemetryData.CommandId { get; set; }

        /// <inheritdoc/>
        string ITelemetryData.RequestId { get; set; }

        /// <summary>
        /// Gets the history command line.
        /// </summary>
        public string Command { get; }

        /// <summary>
        /// Gets whether the commdn line ran successfully.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Creates a new instance of <see cref="HistoryTelemetryData"/>.
        /// </summary>
        /// <param name="client">The client that makes the call.</param>
        /// <param name="command">The history command line.</param>
        /// <param name="success">Whether the <paramref name="command" /> ran successfully.</param>
        public HistoryTelemetryData(PredictionClient client, string command, bool success)
        {
            Client = client;
            Command = command;
            Success = success;
        }
    }
}
