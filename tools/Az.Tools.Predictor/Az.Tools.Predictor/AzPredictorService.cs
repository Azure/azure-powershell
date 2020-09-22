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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// A service that talk to Aladdin endpoints to get the commands and predictions.
    /// </summary>
    internal class AzPredictorService : IAzPredictorService, IDisposable
    {
        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        private sealed class PredictionRequestBody
        {
            public sealed class RequestContext
            {
                public Guid CorrelationId { get; set; } = Guid.Empty;
                public Guid SessionId { get; set; } = Guid.Empty;
                public Guid SubscriptionId { get; set; } = Guid.Empty;
                public Version VersionNumber{ get; set; } = new Version(1, 0);
            }

            public string History { get; set; }
            public string ClientType { get; set; } = "AzurePowerShell";
            public RequestContext Context { get; set; } = new RequestContext();

            public PredictionRequestBody(string history) => this.History = history;
        };

        private static readonly HttpClient _client = new HttpClient();
        private readonly string _commandsEndpoint;
        private readonly string _predictionsEndpoint;
        private volatile Tuple<string, Predictor> _historySuggestions; // The history and the prediction for that.
        private volatile Predictor _commands;
        private volatile string _history;
        private HashSet<string> _commandSet;
        private CancellationTokenSource _predictionRequestCancellationSource;
        private ParameterValuePredictor _parameterValuePredictor = new ParameterValuePredictor();

        /// <summary>
        /// The AzPredictor service interacts with the Aladdin service specified in serviceUri.
        /// At initialization, it requests a list of the popular commands.
        /// </summary>
        /// <param name="serviceUri">The URI of the Aladdin service.</param>
        public AzPredictorService(string serviceUri)
        {
            this._commandsEndpoint = serviceUri + AzPredictorConstants.CommandsEndpoint;
            this._predictionsEndpoint = serviceUri + AzPredictorConstants.PredictionsEndpoint;

            RequestCommands();
        }

        /// <summary>
        /// A default constructor for the derived class.
        /// </summary>
        protected AzPredictorService()
        {
            RequestCommands();
        }

        /// <inhericdoc/>
        public void Dispose()
        {
            Dispose(disposing: true);
        }

        /// <summary>
        /// Dispose the object
        /// </summary>
        /// <param name="disposing">Indicate if this is called from <see cref="Dispose()"/></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._predictionRequestCancellationSource != null)
                {
                    this._predictionRequestCancellationSource.Dispose();
                    this._predictionRequestCancellationSource = null;
                }
            }
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Queries the Predictor with the user input if predictions are available, otherwise uses commands
        /// </remarks>
        public IEnumerable<ValueTuple<string, PredictionSource>> GetSuggestion(Ast input, int suggestionCount, CancellationToken cancellationToken)
        {
            var historySuggestions = this._historySuggestions;
            var history = this._history;

            // We've already used _historySuggestions. There is no need to wait the request to complete at this point.
            // Cancel it.
            this._predictionRequestCancellationSource?.Cancel();

            IList<ValueTuple<string, PredictionSource>> results = new List<ValueTuple<string, PredictionSource>>();

            var resultsFromSuggestion = historySuggestions?.Item2?.Query(input, suggestionCount, cancellationToken);

            if (resultsFromSuggestion != null)
            {
                var predictionSource = PredictionSource.None;

                if (string.Equals(history, historySuggestions?.Item1, StringComparison.Ordinal))
                {
                    predictionSource = PredictionSource.CurrentHistory;
                }
                else
                {
                    predictionSource = PredictionSource.PreviousHistory;
                }

                foreach (var r in resultsFromSuggestion)
                {
                    results.Add(ValueTuple.Create(r, predictionSource));
                }
            }

            if ((resultsFromSuggestion != null) && (resultsFromSuggestion.Count() < suggestionCount))
            {
                var commands = this._commands;
                var resultsFromCommands = commands?.Query(input, suggestionCount - resultsFromSuggestion.Count(), cancellationToken);

                resultsFromCommands?.ExceptWith(resultsFromSuggestion);

                if (resultsFromCommands != null)
                {
                    foreach (var r in resultsFromCommands)
                    {
                        results.Add(ValueTuple.Create(r, PredictionSource.Commands));
                    }
                }
            }

            return results;
        }

        /// <inheritdoc/>
        public virtual void RequestPredictions(IEnumerable<string> history)
        {
            // Even if it's called multiple times, we only need to keep the one for the latest history.

            this._predictionRequestCancellationSource?.Cancel();
            this._predictionRequestCancellationSource = new CancellationTokenSource();
            var cancellationToken = this._predictionRequestCancellationSource.Token;
            var localHistory = string.Join(AzPredictorConstants.CommandConcatenator, history);
            this._history = localHistory;

            // We don't need to block on the task. We send the HTTP request and update prediction list at the background.
            Task.Run(async () => {
                    var requestBody = JsonConvert.SerializeObject(new PredictionRequestBody(localHistory));
                    var httpResponseMessage = await _client.PostAsync(this._predictionsEndpoint, new StringContent(requestBody, Encoding.UTF8, "application/json"), cancellationToken);

                    var reply = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
                    var suggestionsList = JsonConvert.DeserializeObject<List<string>>(reply);

                    this.SetSuggestionPredictor(localHistory, suggestionsList);
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual void RecordHistory(IEnumerable<CommandAst> history)
        {
            history.ForEach((h) => this._parameterValuePredictor.ProcessHistoryCommand(h));
        }

        /// <inhericdoc/>
        public int? GetRankOfSuggestion(string commandName)
        {
            // This function is removed in another PR
            return null;
        }

        /// <inhericdoc/>
        public int? GetRankOfFallback(string commandName)
        {
            // This function is removed in another PR
            return null;
        }

        /// <inhericdoc/>
        public IEnumerable<string> GetTopNSuggestions(int n)
        {
            // This function is removed in another PR
            return null;
        }

        /// <inheritdoc/>
        public bool IsSupportedCommand(string cmd) => !string.IsNullOrWhiteSpace(cmd) && (_commandSet?.Contains(cmd) == true);

        /// <summary>
        /// Requests a list of popular commands from service. These commands are used as fallback suggestion
        /// if none of the predictions fit for the current input. This method should be called once per session.
        /// </summary>
        protected virtual void RequestCommands()
        {
            // We don't need to block on the task. We send the HTTP request and update commands and predictions list at the background.
            Task.Run(async () =>
                    {
                        var httpResponseMessage = await AzPredictorService._client.GetAsync(this._commandsEndpoint);

                        var reply = await httpResponseMessage.Content.ReadAsStringAsync();
                        var commands_reply = JsonConvert.DeserializeObject<List<string>>(reply);
                        this.SetCommandsPredictor(commands_reply);

                        // Initialize predictions
                        var startHistory = $"{AzPredictorConstants.CommandHistoryPlaceholder}{AzPredictorConstants.CommandConcatenator}{AzPredictorConstants.CommandHistoryPlaceholder}";
                        RequestPredictions(new string[] {
                                AzPredictorConstants.CommandHistoryPlaceholder,
                                AzPredictorConstants.CommandHistoryPlaceholder});

                    });
        }

        /// <summary>
        /// Sets the commands predictor.
        /// </summary>
        /// <param name="commands">The command collection to set the predictor</param>
        protected void SetCommandsPredictor(IList<string> commands)
        {
            this._commands = new Predictor(commands, this._parameterValuePredictor);
            this._commandSet = commands.Select(x => AzPredictorService.GetCommandName(x)).ToHashSet<string>(StringComparer.OrdinalIgnoreCase); // this could be slow

        }

        /// <summary>
        /// Sets the suggestiosn predictor.
        /// </summary>
        /// <param name="history">The history that the suggestions are for</param>
        /// <param name="suggestions">The suggestion collection to set the predictor</param>
        protected void SetSuggestionPredictor(string history, IList<string> suggestions)
        {
            this._historySuggestions = Tuple.Create(history, new Predictor(suggestions, this._parameterValuePredictor));
        }

        /// <summary>
        /// Updates the history for prediction.
        /// </summary>
        /// <param name="history">The value to update the history</param>
        protected void SetHistory(string history)
        {
            this._history = history;
        }

        /// <summary>
        /// Gets the command name for the whole line command which has the parameters.
        /// </summary>
        private static string GetCommandName(string commandLine)
        {
            return commandLine.Split(AzPredictorConstants.CommandParameterSeperator).First();
        }
    }
}
