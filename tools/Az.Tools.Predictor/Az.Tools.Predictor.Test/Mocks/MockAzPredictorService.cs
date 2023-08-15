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
using System.Management.Automation.Subsystem.Prediction;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test.Mocks
{
    /// <summary>
    /// Mock <see cref="AzPredictorService"/> so that it doesn't do httpd request to get the commands and predictions.
    /// </summary>
    sealed class MockAzPredictorService : AzPredictorService
    {
        /// <summary>
        /// Gets or sets the value to indicate whether it throws exception in it's implementation.
        /// </summary>
        public bool ThrowException { get; set; }

        /// <summary>
        /// Gets or sets the commands in history to request prediction for.
        /// </summary>
        public IEnumerable<string> Commands { get; set; }

        /// <summary>
        /// Gets or sets the commands that's recorded in history.
        /// </summary>
        public CommandAst History { get; set; }

        /// <summary>
        /// The task that a test can wait on until RequestPredictionsAsync is complete.
        /// </summary>
        public TaskCompletionSource<(bool, CommandLineSummary)?> RequestPredictionTaskCompletionSource { get; private set; }

        /// <summary>
        /// Constructs a new instance of <see cref="MockAzPredictorService"/>
        /// </summary>
        /// <param name="history">The history that the suggestion is for</param>
        /// <param name="suggestions">The suggestions collection</param>
        /// <param name="commands">The commands collection</param>
        /// <param name="azContext">The Az context which this module runs in.</param>
        public MockAzPredictorService(string history, IList<PredictiveCommand> suggestions, IList<PredictiveCommand> commands, IAzContext azContext) : base(azContext)
        {
            ResetRequestPredictionTask();
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
        public override Task<(bool, CommandLineSummary)?> RequestPredictionsAsync(IEnumerable<string> commands, string requestId, CancellationToken cancellationToken)
        {
            if (ThrowException)
            {
                RequestPredictionTaskCompletionSource.TrySetResult((false, null));
                var e = new MockTestException("Test Exception");
                throw new ServiceRequestException(e.Message, e)
                {
                    IsRequestSent = false,
                };
            }

            Commands = commands;
            RequestPredictionTaskCompletionSource.TrySetResult((true, new CommandLineSummary(3, 3, null)));
            return RequestPredictionTaskCompletionSource.Task;
        }

        /// <inheritdoc/>
        public override CommandLineSuggestion GetSuggestion(PredictionContext context, int suggestionCount, int maxAllowedCommandDuplicate, CancellationToken cancellationToken)
        {
            if (ThrowException)
            {
                throw new MockTestException("Test Exception");
            }

            return base.GetSuggestion(context, suggestionCount, maxAllowedCommandDuplicate, cancellationToken);
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

        public void ResetRequestPredictionTask()
        {
            RequestPredictionTaskCompletionSource = new TaskCompletionSource<(bool, CommandLineSummary)?>();
        }
    }
}
