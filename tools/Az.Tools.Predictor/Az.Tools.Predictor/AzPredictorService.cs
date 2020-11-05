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

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Net.Http;
using System.Net.Http.Headers;
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
        private const string ClientType = "AzurePowerShell";

        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        private sealed class PredictionRequestBody
        {
            public sealed class RequestContext
            {
                public string CorrelationId { get; set; } = Guid.Empty.ToString();
                public string SessionId { get; set; } = Guid.Empty.ToString();
                public string SubscriptionId { get; set; } = Guid.Empty.ToString();
                public Version VersionNumber{ get; set; } = new Version(0, 0);
            }

            public string History { get; set; }
            public string ClientType { get; set; } = AzPredictorService.ClientType;
            public RequestContext Context { get; set; } = new RequestContext();

            public PredictionRequestBody(string command) => this.History = command;
        };

        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        private sealed class CommandRequestContext
        {
            public Version VersionNumber{ get; set; } = new Version(0, 0);
        }

        private const string ThrottleByIdHeader = "X-UserId";
        private readonly HttpClient _client;
        private readonly string _commandsEndpoint;
        private readonly string _predictionsEndpoint;
        private volatile Tuple<string, Predictor> _commandSuggestions; // The command and the prediction for that.
        private volatile Predictor _commands;
        private volatile string _commandForPrediction;
        private HashSet<string> _commandSet;
        private CancellationTokenSource _predictionRequestCancellationSource;
        private readonly ParameterValuePredictor _parameterValuePredictor = new ParameterValuePredictor();

        private readonly ITelemetryClient _telemetryClient;
        private readonly IAzContext _azContext;

        /// <summary>
        /// The AzPredictor service interacts with the Aladdin service specified in serviceUri.
        /// At initialization, it requests a list of the popular commands.
        /// </summary>
        /// <param name="serviceUri">The URI of the Aladdin service.</param>
        /// <param name="telemetryClient">The telemetry client.</param>
        /// <param name="azContext">The Az context which this module runs with</param>
        public AzPredictorService(string serviceUri, ITelemetryClient telemetryClient, IAzContext azContext)
        {
            this._commandsEndpoint = $"{serviceUri}{AzPredictorConstants.CommandsEndpoint}?clientType={AzPredictorService.ClientType}&context={JsonConvert.SerializeObject(new CommandRequestContext())}";
            this._predictionsEndpoint = serviceUri + AzPredictorConstants.PredictionsEndpoint;
            this._telemetryClient = telemetryClient;
            this._azContext = azContext;

            this._client = new HttpClient();
            this._client.DefaultRequestHeaders?.Add(AzPredictorService.ThrottleByIdHeader, this._azContext.UserId);

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
        public IEnumerable<ValueTuple<string, string, PredictionSource>> GetSuggestion(Ast input, int suggestionCount, CancellationToken cancellationToken)
        {
            var commandSuggestions = this._commandSuggestions;
            var command = this._commandForPrediction;

            IList<ValueTuple<string, string, PredictionSource>> results = new List<ValueTuple<string, string, PredictionSource>>();

            var resultsFromSuggestion = commandSuggestions?.Item2?.Query(input, suggestionCount, cancellationToken);

            if (resultsFromSuggestion != null)
            {
                var predictionSource = PredictionSource.None;

                if (string.Equals(command, commandSuggestions?.Item1, StringComparison.Ordinal))
                {
                    predictionSource = PredictionSource.CurrentCommand;
                }
                else
                {
                    predictionSource = PredictionSource.PreviousCommand;
                }

                if (resultsFromSuggestion != null)
                {
                    foreach (var r in resultsFromSuggestion)
                    {
                        results.Add(ValueTuple.Create(r.Key, r.Value, predictionSource));
                    }
                }
            }

            if ((resultsFromSuggestion == null) || (resultsFromSuggestion.Count() < suggestionCount))
            {
                var commands = this._commands;
                var resultsFromCommands = commands?.Query(input, suggestionCount - resultsFromSuggestion.Count(), cancellationToken);

                if (resultsFromCommands != null)
                {
                    foreach (var r in resultsFromCommands)
                    {
                        if (resultsFromSuggestion?.ContainsKey(r.Key) == true)
                        {
                            continue;
                        }

                        results.Add(ValueTuple.Create(r.Key, r.Value, PredictionSource.StaticCommands));
                    }
                }
            }

            return results;
        }

        /// <inheritdoc/>
        public virtual void RequestPredictions(IEnumerable<string> commands)
        {
            AzPredictorService.ReplaceThrottleUserIdToHeader(this._client?.DefaultRequestHeaders, this._azContext.UserId);
            var localCommands= string.Join(AzPredictorConstants.CommandConcatenator, commands);
            this._telemetryClient.OnRequestPrediction(localCommands);

            if (string.Equals(localCommands, this._commandForPrediction, StringComparison.Ordinal))
            {
                // It's the same history we've already requested the prediction for last time, skip it.
                return;
            }
            else
            {
                this.SetPredictionCommand(localCommands);

                // When it's called multiple times, we only need to keep the one for the latest command.

                this._predictionRequestCancellationSource?.Cancel();
                this._predictionRequestCancellationSource = new CancellationTokenSource();

                var cancellationToken = this._predictionRequestCancellationSource.Token;

                // We don't need to block on the task. We send the HTTP request and update prediction list at the background.
                Task.Run(async () => {
                    try
                    {
                        var requestContext = new PredictionRequestBody.RequestContext()
                        {
                            SessionId = this._telemetryClient.SessionId,
                            CorrelationId = this._telemetryClient.CorrelationId,
                        };
                        var requestBody = new PredictionRequestBody(localCommands)
                        {
                            Context = requestContext,
                        };

                        var requestBodyString = JsonConvert.SerializeObject(requestBody);
                        var httpResponseMessage = await _client.PostAsync(this._predictionsEndpoint, new StringContent(requestBodyString, Encoding.UTF8, "application/json"), cancellationToken);

                        var reply = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
                        var suggestionsList = JsonConvert.DeserializeObject<List<string>>(reply);

                        this.SetSuggestionPredictor(localCommands, suggestionsList);
                    }
                    catch (Exception e) when (!(e is OperationCanceledException))
                    {
                        this._telemetryClient.OnRequestPredictionError(localCommands, e);
                    }
                },
                cancellationToken);
            }
        }

        /// <inheritdoc/>
        public virtual void RecordHistory(CommandAst history)
        {
            this._parameterValuePredictor.ProcessHistoryCommand(history);
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
                        var httpResponseMessage = await this._client.GetAsync(this._commandsEndpoint);

                        var reply = await httpResponseMessage.Content.ReadAsStringAsync();
                        var commands_reply = JsonConvert.DeserializeObject<List<string>>(reply);
                        this.SetCommandsPredictor(commands_reply);

                        // Initialize predictions
                        RequestPredictions(new string[] {
                                AzPredictorConstants.CommandPlaceholder,
                                AzPredictorConstants.CommandPlaceholder});
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
        /// <param name="commands">The commands that the suggestions are for</param>
        /// <param name="suggestions">The suggestion collection to set the predictor</param>
        protected void SetSuggestionPredictor(string commands, IList<string> suggestions)
        {
            this._commandSuggestions = Tuple.Create(commands, new Predictor(suggestions, this._parameterValuePredictor));
        }

        /// <summary>
        /// Updates the command for prediction.
        /// </summary>
        /// <param name="command">The command for the new prediction</param>
        protected void SetPredictionCommand(string command)
        {
            this._commandForPrediction = command;
        }

        /// <summary>
        /// Gets the command name for the whole line command which has the parameters.
        /// </summary>
        private static string GetCommandName(string commandLine)
        {
            return commandLine.Split(AzPredictorConstants.CommandParameterSeperator).First();
        }

        private static void ReplaceThrottleUserIdToHeader(HttpRequestHeaders header, string value)
        {
            if (header != null)
            {
                lock (header)
                {
                    header.Remove(AzPredictorService.ThrottleByIdHeader);

                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        header.Add(AzPredictorService.ThrottleByIdHeader, value);
                    }
                }
            }

        }
    }
}
