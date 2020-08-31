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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.AzPredictor
{
    /// <summary>
    /// A service that talk to Aladdin endpoints to get the commands and predictions.
    /// </summary>
    public class AzPredictorService : IAzPredictorService
    {
        private sealed class PredictionRequestBody
        {
            public sealed class RequestContext
            {
                public Guid CorrelationId { get; set; } = Guid.Empty;
                public Guid SessionId { get; set; } = Guid.Empty;
                public Guid SubscriptionId { get; set; } = Guid.Empty;
                public Version Version { get; set; } = new Version(1, 0);
            }

            public string History { get; set; }
            public string ClientType { get; set; } = "AzurePowerShell";
            public RequestContext Context { get; set; }

            public PredictionRequestBody(string history) => this.History = history;
        };

        private static readonly HttpClient _client = new HttpClient();
        private readonly string _commandsEndpoint;
        private readonly string _predictionsEndpoint;
        private volatile Predictor _suggestions;
        private volatile Predictor _commands;
        private HashSet<string> _commandSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

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

        /// <inheritdoc/>
        /// <remarks>
        /// Queries the Predictor with the user input if predictions are available, otherwise uses commands
        /// </remarks>
        public string GetSuggestion(Ast input, CancellationToken cancellationToken)
        {
            string result = null;
            var suggestions = this._suggestions;

            result = suggestions?.Query(input, cancellationToken);

            if (result == null)
            {
                var commands = this._commands;
                result = commands?.Query(input, cancellationToken);
            }

            return result;
        }

        /// <inheritdoc/>
        public virtual void RequestPredictions(string history)
        {
            Task.Run(async () =>
                    {
                        var requestBody = JsonConvert.SerializeObject(new PredictionRequestBody(history));
                        var httpResponseMessage = await _client.PostAsync(this._predictionsEndpoint, new StringContent(requestBody, Encoding.UTF8, "application/json"));

                        var reply = await httpResponseMessage.Content.ReadAsStringAsync();
                        var suggestionsList = JsonConvert.DeserializeObject<List<string>>(reply);

                        this.SetSuggestionPredictor(suggestionsList);
                    });
        }

        /// <summary>
        /// For logging purposes, get the rank of the user input in the model suggestions list.
        /// </summary>
        public int? GetRankOfSuggestion(CommandAst command, Ast input)
        {
            return _suggestions?.GetCommandPrediction(command, input, CancellationToken.None).Item2;
        }

        /// <inheritdoc/>
        public int? GetRankOfFallback(CommandAst command, Ast input)
        {
            return _commands?.GetCommandPrediction(command, input, CancellationToken.None).Item2;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetTopNSuggestions(int n) => _suggestions?.GetTopNPrediction(n);

        /// <inheritdoc/>
        public bool IsSupportedCommand(string cmd) => !string.IsNullOrWhiteSpace(cmd) && _commandSet.Contains(cmd);

        /// <summary>
        /// Requests a list of popular commands from service. These commands are used as fallback suggestion
        /// if none of the predictions fit for the current input. This method should be called once per session.
        /// </summary>
        protected virtual void RequestCommands()
        {
            Task.Run(async () =>
                    {
                        var httpResponseMessage = await AzPredictorService._client.GetAsync(this._commandsEndpoint);

                        var reply = await httpResponseMessage.Content.ReadAsStringAsync();
                        var commands_reply = JsonConvert.DeserializeObject<List<string>>(reply);
                        this.SetCommandsPredictor(commands_reply);

                        // Initialize predictions
                        RequestPredictions("start_of_snippet\nstart_of_snippet");
                    });
        }

        /// <summary>
        /// Sets the commands predictor.
        /// </summary>
        /// <param name="commands">The command collection to set the predictor</param>
        protected void SetCommandsPredictor(IList<string> commands)
        {
            this._commands = new Predictor(commands);
            this._commandSet = new HashSet<string>(commands.Select(x => AzPredictorService.GetCommandName(x))); // this could be slow

        }

        /// <summary>
        /// Sets the suggestiosn predictor.
        /// </summary>
        /// <param name="suggestions">The suggestion collection to set the predictor</param>
        protected void SetSuggestionPredictor(IList<string> suggestions)
        {
            this._suggestions = new Predictor(suggestions);
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
