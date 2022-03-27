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
using System.Management.Automation.Subsystem.Prediction;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry
{
    /// <summary>
    /// The data to collect in <see cref="ITelemetryClient.OnParseCommandLineFailure(CommandLineParsingTelemetryData)"/>.
    /// </summary>
    public sealed class CommandLineParsingTelemetryData : ITelemetryData
    {
        /// <inheritdoc/>
        public PredictionClient Client { get; }

        /// <inheritdoc/>
        string ITelemetryData.CommandId { get; set; }

        /// <inheritdoc/>
        string ITelemetryData.RequestId { get; set; }

        /// <summary>
        /// Gets the command line being parsed.
        /// </summary>
        public string Command { get; }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Creates a new instance of <see cref="CommandLineParsingTelemetryData"/>.
        /// </summary>
        /// <param name="command">The command line.</param>
        /// <param name="exception">The exception that may be thrown.</param>
        public CommandLineParsingTelemetryData(string command, Exception exception)
        {
            Command = command;
            Exception = exception;
        }
    }
}
