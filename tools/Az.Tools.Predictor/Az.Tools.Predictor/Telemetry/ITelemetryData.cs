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
    /// An interface that all telemetry data class should implement.
    /// </summary>
    public interface ITelemetryData
    {
        /// <summary>
        /// Gets the id to correlate events proceeding to and including a command history.
        /// </summary>
        public string CommandId { get; internal set; }

        /// <summary>
        /// Gets the id to correlate the request and the server.
        /// </summary>
        public string RequestId { get; internal set; }

        /// <summary>
        /// Gets the client that makes the calls.
        /// </summary>
        public PredictionClient Client { get; }
    }
}
