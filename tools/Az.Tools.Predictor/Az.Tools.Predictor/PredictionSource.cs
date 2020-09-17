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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// An enum for the source where we get the prediction.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PredictionSource
    {
        /// <summary>
        /// There is no predictions.
        /// </summary>
        None,

        /// <summary>
        /// The prediction is from the command list.
        /// </summary>
        Commands,

        /// <summary>
        /// The prediction is from the list for the older command.
        /// </summary>
        PreviousCommand,

        /// <summary>
        /// The prediction is from the list for the currentc command.
        /// </summary>
        CurrentCommand
    }
}
