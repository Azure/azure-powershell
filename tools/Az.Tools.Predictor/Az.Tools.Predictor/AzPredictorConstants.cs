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
        /// The value to check to determine if it's an Az command.
        /// </summary>
        public const string AzCommandMoniker = "-Az";

        /// <summary>
        /// The value to use when the command isn't an Az command.
        /// </summary>
        public const string CommandPlaceholder = "start_of_snippet";

        /// <summary>
        /// The character to use when we join the commands together.
        /// </summary>
        public const char CommandConcatenator = '\n';

        /// <summary>
        /// The number of command to use from the history.
        /// </summary>
        public const int CommandHistoryCountToProcess = 2;

        /// <summary>
        /// The character to join the command name and parameter and the value.
        /// </summary>
        public const char CommandParameterSeperator = ' ';

        /// <summary>
        /// The service endpoint to get the list of commands.
        /// </summary>
        public const string CommandsEndpoint = "/commands";

        /// <summary>
        /// The default client id. This is used when we don't get the client id from the caller. For example, when the module
        /// is imported and it hasn't started processing yet.
        /// </summary>
        public const string DefaultClientId = "AzPredictor";

        /// <summary>
        /// The service endpoint to get the list of suggestions.
        /// </summary>
        public const string PredictionsEndpoint = "/predictions";

        /// <summary>
        /// The character that begins a parameter.
        /// </summary>
        public const char ParameterIndicator = '-';

        /// <summary>
        /// The seperator used in parameter name and value pair which is in the form -Name:Value.
        /// </summary>
        public const char ParameterValueSeperator = ':';

        /// <summary>
        /// The substitute for the parameter value.
        /// </summary>
        public const string ParameterValueMask = "***";

        /// <summary>
        /// The setting file name.
        /// </summary>
        public const string SettingsFileName = "AzPredictorSettings.json";

        /// <summary>
        /// The azure profile directory name.
        /// </summary>
        // See AzureDirectoryName in https://github.com/Azure/azure-powershell/blob/master/src/Accounts/Authentication/Properties/Resources.resx
        public const string AzureProfileDirectoryName = ".Azure";
    }
}

