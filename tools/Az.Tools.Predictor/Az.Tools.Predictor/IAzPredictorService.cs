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

using System.Collections.Generic;
using System.Management.Automation.Language;
using System.Management.Automation.Subsystem;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// The interface to provide the prediction results in PSReadLine.
    /// </summary>
    public interface IAzPredictorService
    {
        /// <summary>
        /// Gest the suggestions for the user input.
        /// </summary>
        /// <param name="context">User input context from PSReadLine.</param>
        /// <param name="suggestionCount">The number of suggestion to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="maxAllowedCommandDuplicate">The maximum amount of the same commnds in the list of predictions.</param>
        /// <returns>The suggestions for <paramref name="context"/>. The maximum number of suggestions is <paramref name="suggestionCount"/>. A null will be returned if there the user input context isn't valid/supported at all.</returns>
        public CommandLineSuggestion GetSuggestion(PredictionContext context, int suggestionCount, int maxAllowedCommandDuplicate, CancellationToken cancellationToken);

        /// <summary>
        /// Requests predictions, given a command string.
        /// </summary>
        /// <param name="commands">A list of commands.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A boolean means that a request is made.</returns>
        public Task<bool> RequestPredictionsAsync(IEnumerable<string> commands, CancellationToken cancellationToken);

        /// <summary>
        /// Record the history from PSReadLine.
        /// </summary>
        /// <param name="history">The last command in history.</param>
        public void RecordHistory(CommandAst history);

        /// <summary>
        /// Return true if command is part of known set of Az cmdlets, false otherwise.
        /// </summary>
        public bool IsSupportedCommand(string cmd);
    }
}
