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
using System.Collections.Concurrent;
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
                public string CorrelationId { get; set; } = Guid.Empty.ToString();
                public string SessionId { get; set; } = Guid.Empty.ToString();
                public string SubscriptionId { get; set; } = Guid.Empty.ToString();
                public Version VersionNumber{ get; set; } = new Version(1, 0);
            }

            public string History { get; set; }
            public string ClientType { get; set; } = "AzurePowerShell";
            public RequestContext Context { get; set; } = new RequestContext();

            public PredictionRequestBody(string command) => this.History = command;
        };

        private static readonly HttpClient _client = new HttpClient();
        private readonly string _commandsEndpoint;
        private readonly string _predictionsEndpoint;
        private volatile Tuple<string, Predictor> _commandSuggestions; // The command and the prediction for that.
        private volatile Predictor _commands;
        private volatile string CommandForPrediction;
        private HashSet<string> _commandSet;
        private CancellationTokenSource _predictionRequestCancellationSource;
        private ParameterValuePredictor _parameterValuePredictor = new ParameterValuePredictor();

        private readonly ITelemetryClient _telemetryClient;

        /// <summary>
        /// The AzPredictor service interacts with the Aladdin service specified in serviceUri.
        /// At initialization, it requests a list of the popular commands.
        /// </summary>
        /// <param name="serviceUri">The URI of the Aladdin service.</param>
        /// <param name="telemetryClient">The telemetry client.</param>
        public AzPredictorService(string serviceUri, ITelemetryClient telemetryClient)
        {
            this._commandsEndpoint = serviceUri + AzPredictorConstants.CommandsEndpoint;
            this._predictionsEndpoint = serviceUri + AzPredictorConstants.PredictionsEndpoint;
            this._telemetryClient = telemetryClient;

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
        public Tuple<string, PredictionSource> GetSuggestion(Ast input, CancellationToken cancellationToken)
        {
            var commandSuggestions = this._commandSuggestions;
            var command = this.CommandForPrediction;
            var predictionSource = PredictionSource.None;

            // We've already used _commandSuggestions. There is no need to wait the request to complete at this point.
            // Cancel it.
            this._predictionRequestCancellationSource?.Cancel();

            string result = commandSuggestions?.Item2?.Query(input, cancellationToken);

            if (result != null)
            {
                if (string.Equals(command, commandSuggestions?.Item1, StringComparison.Ordinal))
                {
                    predictionSource = PredictionSource.CurrentCommand;
                }
                else
                {
                    predictionSource = PredictionSource.PreviousCommand;
                }
            }
            else
            {
                var commands = this._commands;
                result = commands?.Query(input, cancellationToken);

                if (result != null)
                {
                    predictionSource = PredictionSource.StaticCommands;
                }
            }

            return Tuple.Create(result, predictionSource);
        }

        /// <inheritdoc/>
        public virtual void RequestPredictions(IEnumerable<string> commands)
        {
            // Even if it's called multiple times, we only need to keep the one for the latest command.

            this._predictionRequestCancellationSource?.Cancel();
            this._predictionRequestCancellationSource = new CancellationTokenSource();

            var cancellationToken = this._predictionRequestCancellationSource.Token;

            var localCommands= string.Join(AzPredictorConstants.CommandConcatenator, commands);
            this._telemetryClient.OnRequestPrediction(localCommands);
            this.SetPredictionCommand(localCommands);

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

        /// <inheritdoc/>
        public virtual void RecordHistory(IEnumerable<CommandAst> history)
        {
            history.ForEach((h) => this._parameterValuePredictor.ProcessHistoryCommand(h));
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
            this.CommandForPrediction = command;
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
