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

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test.Mocks
{
    /// <summary>
    /// Mock <see cref="AzPredictorService"/> so that it doesn't do httpd request to get the commands and predictions.
    /// </summary>
    sealed class MockAzPredictorService : AzPredictorService
    {
        /// <summary>
        /// Gets or sets the commands in history to request prediction for.
        /// </summary>
        public IEnumerable<string> Commands { get; set; }

        /// <summary>
        /// Gets or sets the commands that's recorded in history.
        /// </summary>
        public CommandAst History { get; set; }

        /// <summary>
        /// Constructs a new instance of <see cref="MockAzPredictorService"/>
        /// </summary>
        /// <param name="history">The history that the suggestion is for</param>
        /// <param name="suggestions">The suggestions collection</param>
        /// <param name="commands">The commands collection</param>
        public MockAzPredictorService(string history, IList<PredictiveCommand> suggestions, IList<PredictiveCommand> commands)
        {
            if (history != null)
            {
                SetCommandToRequestPrediction(history);

                if (suggestions != null)
                {
                    SetCommandBasedPreditor(history, suggestions);
                }
            }

            if (commands != null)
            {
                SetFallbackPredictor(commands);
            }
        }

        /// <inheritdoc/>
        public override void RequestPredictions(IEnumerable<string> commands)
        {
            Commands = commands;
        }

        /// <inheritdoc/>
        protected override void RequestAllPredictiveCommands()
        {
            // Do nothing since we've set the command and suggestion predictors.
        }

        /// <inheritdoc/>
        public override void RecordHistory(CommandAst history)
        {
            History = history;
        }
    }
}
