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

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// The constants shared in the project.
    /// </summary>
    internal static class AzPredictorConstants
    {
        /// <summary>
        /// The value to use when the command isn't an Az command.
        /// </summary>
        public const string CommandPlaceholder = "start_of_snippet";

        /// <summary>
        /// The value to check to determine if it's an Az command.
        /// </summary>
        public const string AzCommandMoniktor = "az";

        /// <summary>
        /// The character to use when we join the commands together.
        /// </summary>
        public const char CommandConcatenator = '\n';

        /// <summary>
        /// The number of command to use from the history.
        /// </summary>
        public const int CommandHistoryCountToProcess = 2;

        /// <summary>
        /// The service endpoint to get the list of commands.
        /// </summary>
        public const string CommandsEndpoint = "/commands";

        /// <summary>
        /// The service endpoint to get the list of suggestions.
        /// </summary>
        public const string PredictionsEndpoint = "/predictions";

        /// <summary>
        /// The character to join the command name and parameter and the value.
        /// </summary>
        public const char CommandParameterSeperator = ' ';

        /// <summary>
        /// The setting file name.
        /// </summary>
        public const string SettingsFileName = "AzPredictorSettings.json";

        /// <summary>
        /// The azure profile directory name.
        /// </summary>
        public const string AzureProfileDirectoryName = ".Azure";
    }
}

