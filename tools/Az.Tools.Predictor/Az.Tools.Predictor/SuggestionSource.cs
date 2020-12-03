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
    /// An enum for the source where we get the suggestion.
    /// </summary>
    public enum SuggestionSource
    {
        /// <summary>
        /// There is no predictions.
        /// </summary>
        None,

        /// <summary>
        /// The suggestion is from the static command list. This doesn't take command history into account.
        /// </summary>
        StaticCommands,

        /// <summary>
        /// The suggestion is from the list for outdated command history.
        /// </summary>
        PreviousCommand,

        /// <summary>
        /// The suggestion is from the list for latest command history.
        /// </summary>
        CurrentCommand
    }
}
