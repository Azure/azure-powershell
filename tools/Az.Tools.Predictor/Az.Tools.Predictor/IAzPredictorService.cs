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
using System.Collections.Generic;
using System.Management.Automation.Language;
using System.Threading;

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
        /// <param name="input">User input from PSReadLine</param>
        /// <param name="suggestionCount">The number of suggestion to return.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The list of suggestions for <paramref name="input"/>. The maximum number of suggestion is <paramref name="suggestionCount"/></returns>
        public IEnumerable<ValueTuple<string, PredictionSource>> GetSuggestion(Ast input, int suggestionCount, CancellationToken cancellationToken);

        /// <summary>
        /// Requests predictions, given a command string.
        /// </summary>
        /// <param name="commands">A list of commands</param>
        public void RequestPredictions(IEnumerable<string> commands);

        /// <summary>
        /// Record the history from PSReadLine.
        /// </summary>
        /// <param name="history">The last command in history</param>
        public void RecordHistory(CommandAst history);

        /// <summary>
        /// Return true if command is part of known set of Az cmdlets, false otherwise.
        /// </summary>
        public bool IsSupportedCommand(string cmd);
    }
}
