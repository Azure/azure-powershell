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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
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
    /// A service that connects to Aladdin endpoints to get the model and provides suggestions to PSReadLine.
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

            public PredictionRequestBody(string command) => History = command;
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

        /// <summary>
        /// The history command line and the predictor based on that.
        /// </summary>
        private volatile Tuple<string, CommandLinePredictor> _commandBasedPredictor;

        /// <summary>
        /// The predictor to used when <see cref="_commandBasedPredictor"/> doesn't return enough suggestions.
        /// </summary>
        private volatile CommandLinePredictor _fallbackPredictor;

        /// <summary>
        /// The history command line that we request prediction for.
        /// </summary>
        private volatile string _commandToRequestPrediction;

        /// <summary>
        /// All the command lines we can provide as suggestions.
        /// </summary>
        private HashSet<string> _allPredictiveCommands;
        private CancellationTokenSource _predictionRequestCancellationSource;
        private readonly ParameterValuePredictor _parameterValuePredictor = new ParameterValuePredictor();

        private readonly ITelemetryClient _telemetryClient;
        private readonly IAzContext _azContext;

        /// <summary>
        /// Creates a new instance of <see cref="AzPredictorService"/>.
        /// </summary>
        /// <param name="serviceUri">The URI of the Aladdin service.</param>
        /// <param name="telemetryClient">The telemetry client.</param>
        /// <param name="azContext">The Az context which this module runs in.</param>
        public AzPredictorService(string serviceUri, ITelemetryClient telemetryClient, IAzContext azContext)
        {
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(serviceUri), $"{nameof(serviceUri)} cannot be null or whitespace.");
            Validation.CheckArgument(telemetryClient, $"{nameof(telemetryClient)} cannot be null.");
            Validation.CheckArgument(azContext, $"{nameof(azContext)} cannot be null.");

            _commandsEndpoint = $"{serviceUri}{AzPredictorConstants.CommandsEndpoint}?clientType={AzPredictorService.ClientType}&context={JsonConvert.SerializeObject(new CommandRequestContext())}";
            _predictionsEndpoint = serviceUri + AzPredictorConstants.PredictionsEndpoint;
            _telemetryClient = telemetryClient;
            _azContext = azContext;

            _client = new HttpClient();

            RequestAllPredictiveCommands();
        }

        /// <summary>
        /// A default constructor for the derived class. This is used in test cases.
        /// </summary>
        protected AzPredictorService()
        {
            RequestAllPredictiveCommands();
        }

        /// <inhericdoc/>
        public void Dispose()
        {
            Dispose(disposing: true);
        }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        /// <param name="disposing">Indicate if this is called from <see cref="Dispose()"/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_predictionRequestCancellationSource != null)
                {
                    _predictionRequestCancellationSource.Dispose();
                    _predictionRequestCancellationSource = null;
                }
            }
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Tries to get the suggestions for the user input from the command history. If that doesn't find
        /// <paramref name="suggestionCount"/> suggestions, it'll fallback to find the suggestion regardless of command history.
        /// </remarks>
        public CommandLineSuggestion GetSuggestion(Ast input, int suggestionCount, int maxAllowedCommandDuplicate, CancellationToken cancellationToken)
        {
            Validation.CheckArgument(input, $"{nameof(input)} cannot be null");
            Validation.CheckArgument<ArgumentOutOfRangeException>(suggestionCount > 0, $"{nameof(suggestionCount)} must be larger than 0.");
            Validation.CheckArgument<ArgumentOutOfRangeException>(maxAllowedCommandDuplicate > 0, $"{nameof(maxAllowedCommandDuplicate)} must be larger than 0.");

            var commandBasedPredictor = _commandBasedPredictor;
            var command = _commandToRequestPrediction;

            var presentCommands = new Dictionary<string, int>();
            var result = commandBasedPredictor?.Item2?.GetSuggestion(input, presentCommands, suggestionCount, maxAllowedCommandDuplicate, cancellationToken);

            if ((result != null) && (result.Count > 0))
            {
                var suggestionSource = SuggestionSource.PreviousCommand;

                if (string.Equals(command, commandBasedPredictor?.Item1, StringComparison.Ordinal))
                {
                    suggestionSource = SuggestionSource.CurrentCommand;
                }

                for (var i = 0; i < result.Count; ++i)
                {
                    result.UpdateSuggestionSource(i, suggestionSource);
                }
            }

            if ((result == null) || (result.Count < suggestionCount))
            {
                var fallbackPredictor = _fallbackPredictor;
                var suggestionCountToRequest = (result == null) ? suggestionCount : suggestionCount - result.Count;
                var resultsFromFallback = fallbackPredictor?.GetSuggestion(input, presentCommands, suggestionCountToRequest, maxAllowedCommandDuplicate, cancellationToken);

                if (result == null)
                {
                    result = resultsFromFallback;
                }
                else if ((resultsFromFallback != null) && (resultsFromFallback.Count > 0))
                {
                    for (var i = 0; i < resultsFromFallback.Count; ++i)
                    {
                        if (result.SourceTexts.Contains(resultsFromFallback.SourceTexts[i]))
                        {
                            continue;
                        }

                        result.AddSuggestion(resultsFromFallback.PredictiveSuggestions[i], resultsFromFallback.SourceTexts[i], SuggestionSource.StaticCommands);
                    }
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public virtual void RequestPredictions(IEnumerable<string> commands)
        {
            Validation.CheckArgument(commands, $"{nameof(commands)} cannot be null.");

            var localCommands= string.Join(AzPredictorConstants.CommandConcatenator, commands);
            bool postSuccess = false;
            Exception exception = null;
            bool startRequestTask = false;

            try
            {
                if (string.Equals(localCommands, _commandToRequestPrediction, StringComparison.Ordinal))
                {
                    // It's the same history we've already requested the prediction for last time, skip it.
                    return;
                }

                if (commands.Any())
                {
                    SetCommandToRequestPrediction(localCommands);

                    // When it's called multiple times, we only need to keep the one for the latest command.

                    _predictionRequestCancellationSource?.Cancel();
                    _predictionRequestCancellationSource = new CancellationTokenSource();

                    var cancellationToken = _predictionRequestCancellationSource.Token;

                    // We don't need to block on the task. We send the HTTP request and update prediction list at the background.
                    startRequestTask = true;
                    Task.Run(async () => {
                        try
                        {
                            AzPredictorService.ReplaceThrottleUserIdToHeader(_client?.DefaultRequestHeaders, _azContext.UserId);

                            var requestContext = new PredictionRequestBody.RequestContext()
                            {
                                SessionId = _telemetryClient.SessionId,
                                CorrelationId = _telemetryClient.CorrelationId,
                            };

                            var requestBody = new PredictionRequestBody(localCommands)
                            {
                                Context = requestContext,
                            };

                            var requestBodyString = JsonConvert.SerializeObject(requestBody);
                            var httpResponseMessage = await _client.PostAsync(_predictionsEndpoint, new StringContent(requestBodyString, Encoding.UTF8, "application/json"), cancellationToken);
                            postSuccess = true;

                            var reply = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
                            var suggestionsList = JsonConvert.DeserializeObject<List<string>>(reply);

                            SetCommandBasedPreditor(localCommands, suggestionsList);
                        }
                        catch (Exception e) when (!(e is OperationCanceledException))
                        {
                            exception = e;
                        }
                        finally
                        {
                            _telemetryClient.OnRequestPrediction(new TelemetryData.RequestPrediction(localCommands, postSuccess, exception));
                        }
                    },
                    cancellationToken);
                }
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                if (!startRequestTask)
                {
                    _telemetryClient.OnRequestPrediction(new TelemetryData.RequestPrediction(localCommands, hasSentHttpRequest: false, exception: exception));
                }
            }
        }

        /// <inheritdoc/>
        public virtual void RecordHistory(CommandAst history)
        {
            Validation.CheckArgument(history, $"{nameof(history)} cannot be null.");

            _parameterValuePredictor.ProcessHistoryCommand(history);
        }

        /// <inheritdoc/>
        public bool IsSupportedCommand(string cmd) => !string.IsNullOrWhiteSpace(cmd) && (_allPredictiveCommands?.Contains(cmd) == true);

        /// <summary>
        /// Requests a list of popular commands from service. These commands are used as fallback suggestion
        /// if none of the predictions fit for the current input. This method should be called once per session.
        /// </summary>
        protected virtual void RequestAllPredictiveCommands()
        {
            // We don't need to block on the task. We send the HTTP request and update commands and predictions list at the background.
            Task.Run(async () =>
                    {
                        _client.DefaultRequestHeaders?.Add(AzPredictorService.ThrottleByIdHeader, _azContext.UserId);

                        var httpResponseMessage = await _client.GetAsync(_commandsEndpoint);

                        var reply = await httpResponseMessage.Content.ReadAsStringAsync();
                        var commandsReply = JsonConvert.DeserializeObject<List<string>>(reply);
                        SetFallbackPredictor(commandsReply);

                        // Initialize predictions
                        RequestPredictions(new string[] {
                                AzPredictorConstants.CommandPlaceholder,
                                AzPredictorConstants.CommandPlaceholder});
                    });
        }

        /// <summary>
        /// Sets the fallback predictor.
        /// </summary>
        /// <param name="commands">The command collection to set the predictor</param>
        protected void SetFallbackPredictor(IList<string> commands)
        {
            Validation.CheckArgument(commands, $"{nameof(commands)} cannot be null.");

            _fallbackPredictor = new CommandLinePredictor(commands, _parameterValuePredictor);
            _allPredictiveCommands = commands.Select(x => AzPredictorService.GetCommandName(x)).ToHashSet<string>(StringComparer.OrdinalIgnoreCase); // this could be slow
        }

        /// <summary>
        /// Sets the predictor based on the command history.
        /// </summary>
        /// <param name="commands">The commands that the suggestions are for</param>
        /// <param name="suggestions">The suggestion collection to set the predictor</param>
        protected void SetCommandBasedPreditor(string commands, IList<string> suggestions)
        {
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(commands), $"{nameof(commands)} cannot be null or whitespace.");
            Validation.CheckArgument(suggestions, $"{nameof(suggestions)} cannot be null.");

            _commandBasedPredictor = Tuple.Create(commands, new CommandLinePredictor(suggestions, _parameterValuePredictor));
        }

        /// <summary>
        /// Updates the command for prediction.
        /// </summary>
        /// <param name="command">The command for the new prediction</param>
        protected void SetCommandToRequestPrediction(string command)
        {
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(command), $"{nameof(command)} cannot be null or whitespace.");

            _commandToRequestPrediction = command;
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
