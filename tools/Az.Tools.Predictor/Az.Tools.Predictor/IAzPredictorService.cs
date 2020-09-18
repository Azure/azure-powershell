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
        /// Gest the suggestion for the user input.
        /// </summary>
        /// <param name="input">User input from PSReadLine</param>
        /// <param name="cancellationToken">The cancellation token</param>
        public Tuple<string, PredictionSource> GetSuggestion(Ast input, CancellationToken cancellationToken);

        /// <summary>
        /// Requests predictions, given a history string.
        /// </summary>
        /// <param name="history">A list of history commands</param>
        public void RequestPredictions(IEnumerable<string> history);

        /// <summary>
        /// Record the history from PSReadLine.
        /// </summary>
        /// <param name="history">A list of history commands</param>
        public void RecordHistory(IEnumerable<CommandAst> history);

        /// <summary>
        /// Return true if command is part of known set of Az cmdlets, false otherwise.
        /// </summary>
        public bool IsSupportedCommand(string cmd);

        /// <summary>
        /// For logging purposes, get the rank of the user input in the model suggestions list.
        /// </summary>
        public int? GetRankOfSuggestion(string commandName);

        /// <summary>
        /// For logging purposes, get the rank of the user input in the fallback commands cache.
        /// </summary>
        public int? GetRankOfFallback(string commandName);

        /// <summary>
        /// For logging purposes, get the top N suggestions from the model suggestions list.
        /// </summary>
        public IEnumerable<string> GetTopNSuggestions(int n);
    }
}
