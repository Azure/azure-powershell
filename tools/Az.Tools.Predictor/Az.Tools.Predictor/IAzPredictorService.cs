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
        /// Requests predictions, given a command string.
        /// </summary>
        /// <param name="command">A history string could look like: "Get-AzContext -Name NAME\nSet-AzContext"</param>
        public void RequestPredictions(string command);

        /// <summary>
        /// Return true if command is part of known set of Az cmdlets, false otherwise.
        /// </summary>
        public bool IsSupportedCommand(string cmd);
    }
}
