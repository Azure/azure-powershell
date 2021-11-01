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
using System.Text.Json.Serialization;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// Represents a command entry in the model files.
    /// </summary>
    public class ModelEntry
    {
        /// <summary>
        /// The command in the model.
        /// </summary>
        [JsonPropertyName("suggestion")]
        public string Command { get; set; }

        /// <summary>
        /// The description of the command in the model.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The prediction count in the model.
        /// </summary>
        [JsonPropertyName("suggestion count")]
        public int PredictionCount { get; set; }

        /// <summary>
        /// The history count in the model.
        /// </summary>
        [JsonPropertyName("history count")]
        public int HistoryCount { get; set; }

        /// <summary>
        /// Transforms the model entry into the client PredictiveCommand object.
        /// </summary>
        /// <returns>The PredictiveCommand object used on the client.</returns>
        public PredictiveCommand TransformEntry()
        {
            return new PredictiveCommand()
            {
                Command = this.Command,
                Description = this.Description
            };
        }
    }
}
