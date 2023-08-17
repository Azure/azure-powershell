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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry;
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Management.Automation.Subsystem.Prediction;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// A service that connects to Aladdin endpoints to get the model and provides suggestions to PSReadLine.
    /// </summary>
    internal class AzPredictorService : IAzPredictorService
    {
        private const string ClientType = "AzurePowerShell";

        private static readonly PredictiveCommand[] _surveyCmdlets = new PredictiveCommand[AzPredictorConstants.CohortCount]
        {
            new PredictiveCommand()
                    {
                        Command = "Open-AzPredictorSurvey",
                        Description = "Run this command to tell us about your experience with Az Predictor",
                    },
            new PredictiveCommand()
                    {
                        Command = "Send-AzPredictorRating -Rating 5",
                        Description = "Run this command followed by your rating of Az Predictor: 1 (poor) - 5 (great)"
                    },
        };

        private sealed class PredictionRequestBody
        {
            public sealed class RequestContext
            {
                public string SubscriptionId { get; set; } = Guid.Empty.ToString();
                public Version VersionNumber{ get; set; } = new Version(0, 0);
            }

            public IEnumerable<string> History { get; set; }
            public string ClientType { get; set; } = AzPredictorService.ClientType;
            public RequestContext Context { get; set; } = new RequestContext();

            public PredictionRequestBody(IEnumerable<string> commands) => History = commands;
        };

        private sealed class CommandRequestContext
        {
            public Version VersionNumber{ get; set; } = new Version(0, 0);
        }

        /// <summary>
        /// The name of the header value that contains the platform correlation id.
        /// </summary>
        private const string CorrelationIdHeader = "Sml-CorrelationId";

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
        private readonly ParameterValuePredictor _parameterValuePredictor;

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

            _parameterValuePredictor = new ParameterValuePredictor(telemetryClient, azContext);

            _commandsEndpoint = $"{serviceUri}{AzPredictorConstants.CommandsEndpoint}?clientType={AzPredictorService.ClientType}&context.versionNumber={azContext.AzVersion}";
            _predictionsEndpoint = serviceUri + AzPredictorConstants.PredictionsEndpoint;
            _telemetryClient = telemetryClient;
            _azContext = azContext;

            _client = new HttpClient();

            RequestAllPredictiveCommands();
        }

        /// <summary>
        /// A default constructor for the derived class. This is used in test cases.
        /// </summary>
        /// <param name="azContext">The Az context which this module runs in.</param>
        protected AzPredictorService(IAzContext azContext)
        {
            _azContext = azContext;
            RequestAllPredictiveCommands();
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Tries to get the suggestions for the user input from the command history. If that doesn't find
        /// <paramref name="suggestionCount"/> suggestions, it'll fallback to find the suggestion regardless of command history.
        /// </remarks>
        public virtual CommandLineSuggestion GetSuggestion(PredictionContext context, int suggestionCount, int maxAllowedCommandDuplicate, CancellationToken cancellationToken)
        {
            Validation.CheckArgument(context, $"{nameof(context)} cannot be null");
            Validation.CheckArgument<ArgumentOutOfRangeException>(suggestionCount > 0, $"{nameof(suggestionCount)} must be larger than 0.");
            Validation.CheckArgument<ArgumentOutOfRangeException>(maxAllowedCommandDuplicate > 0, $"{nameof(maxAllowedCommandDuplicate)} must be larger than 0.");

            CommandAst commandAst = CommandLineUtilities.GetCommandAst(context);

            CommandLineSuggestion earlyReturnResult = new()
            {
                CommandAst = commandAst
            };

            if (commandAst == null)
            {
                return earlyReturnResult;
            }

            var commandName = commandAst.GetCommandName();

            if (string.IsNullOrWhiteSpace(commandName))
            {
                return earlyReturnResult;
            }

            ParameterSet inputParameterSet = null;

            try
            {
                inputParameterSet = new ParameterSet(commandAst, _azContext);
            }
            catch when (!IsRecognizedCommand(commandName))
            {
                // We only ignore the exception when the command name is not supported.
                // We want to collect the telemetry about the exception how common it is for the format we don't support.
                return earlyReturnResult;
            }

            cancellationToken.ThrowIfCancellationRequested();

            // We want to show a survey/feedback cmdlet at the end of the suggestion list. We try to find one less
            // suggestions to make room for that cmdlet and avoid too much computation.
            // But if only one suggestion is requested, we don't replace it with the survey cmdlets.
            var suggestionFromPredictorCount = (suggestionCount == 1) ? 1 : (suggestionCount - 1);

            var rawUserInput = context.InputAst.ToString();
            var presentCommands = new Dictionary<string, int>();
            var commandBasedPredictor = _commandBasedPredictor;
            var commandToRequestPrediction = _commandToRequestPrediction;

            var result = commandBasedPredictor?.Item2?.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    suggestionFromPredictorCount,
                    maxAllowedCommandDuplicate,
                    cancellationToken);

            if ((result != null) && (result.Count > 0))
            {
                var suggestionSource = SuggestionSource.PreviousCommand;

                if (string.Equals(commandToRequestPrediction, commandBasedPredictor?.Item1, StringComparison.Ordinal))
                {
                    suggestionSource = SuggestionSource.CurrentCommand;
                }

                for (var i = 0; i < result.Count; ++i)
                {
                    result.UpdateSuggestionSource(i, suggestionSource);
                }
            }

            if ((result == null) || (result.Count < suggestionFromPredictorCount))
            {
                var fallbackPredictor = _fallbackPredictor;
                var suggestionCountToRequest = (result == null) ? suggestionFromPredictorCount : suggestionFromPredictorCount - result.Count;
                var resultsFromFallback = fallbackPredictor?.GetSuggestion(commandName,
                        inputParameterSet,
                        rawUserInput,
                        presentCommands,
                        suggestionCountToRequest,
                        maxAllowedCommandDuplicate,
                        cancellationToken);

                if ((result == null) && (resultsFromFallback != null))
                {
                    result = resultsFromFallback;

                    for (var i = 0; i < result.Count; ++i)
                    {
                        result.UpdateSuggestionSource(i, SuggestionSource.StaticCommands);
                    }
                }
                else if ((resultsFromFallback != null) && (resultsFromFallback.Count > 0))
                {
                    for (var i = 0; i < resultsFromFallback.Count; ++i)
                    {
                        result.AddSuggestion(resultsFromFallback.PredictiveSuggestions[i], resultsFromFallback.SourceTexts[i], SuggestionSource.StaticCommands);
                    }
                }
            }

            if (result is null)
            {
                result = new CommandLineSuggestion();
            }

            result.CommandAst = commandAst;

            return result;
        }

        /// <inheritdoc/>
        public virtual async Task<(bool, CommandLineSummary)?> RequestPredictionsAsync(IEnumerable<string> commands, string requestId, CancellationToken cancellationToken)
        {
            Validation.CheckArgument(commands, $"{nameof(commands)} cannot be null.");

            var localCommands = string.Join(AzPredictorConstants.CommandConcatenator, commands);
            bool isRequestSent = false;

            try
            {
                if (string.Equals(localCommands, _commandToRequestPrediction, StringComparison.OrdinalIgnoreCase))
                {
                    // It's the same history we've already requested the prediction for last time, skip it.
                    return null;
                }

                if (!commands.Any())
                {
                    return null;
                }

                // We have a check to avoid sending the request using the same commands. So we only check if it's cancelled
                // here. We don't cancel the request once we set _commandToRequestPrediction to localCommands.
                cancellationToken.ThrowIfCancellationRequested();
                cancellationToken = CancellationToken.None;
                SetCommandToRequestPrediction(localCommands);

                AzPredictorService.SetHttpRequestHeader(_client?.DefaultRequestHeaders, _azContext.HashUserId, requestId);

                var requestContext = new PredictionRequestBody.RequestContext()
                {
                    VersionNumber = this._azContext.AzVersion
                };

                var requestBody = new PredictionRequestBody(commands)
                {
                    Context = requestContext,
                };

                var requestBodyString = JsonSerializer.Serialize(requestBody, JsonUtilities.DefaultSerializerOptions);
                var httpResponseMessage = await _client.PostAsync(_predictionsEndpoint, new StringContent(requestBodyString, Encoding.UTF8, "application/json"), cancellationToken);
                isRequestSent = true;

                httpResponseMessage.EnsureSuccessStatusCode();
                var reply = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken);
                var suggestionsList = await JsonSerializer.DeserializeAsync<IList<PredictiveCommand>>(reply, JsonUtilities.DefaultSerializerOptions);

                SetCommandBasedPreditor(localCommands, suggestionsList);
            }
            catch (Exception e) when (!(e is OperationCanceledException))
            {
                throw new ServiceRequestException(e.Message, e)
                        {
                            IsRequestSent = isRequestSent,
                            PredictorSummary = _commandBasedPredictor.Item2.PredictorSummary,
                        };
            }

            return (isRequestSent, _commandBasedPredictor.Item2.PredictorSummary);
        }

        /// <inheritdoc/>
        public virtual void RecordHistory(CommandAst history) =>
            ExceptionUtilities.RecordExceptionWrapper(_telemetryClient, () =>
            {
                Validation.CheckArgument(history, $"{nameof(history)} cannot be null.");

                _parameterValuePredictor.ProcessHistoryCommand(history);
            });

        /// <inheritdoc/>
        public virtual bool IsSupportedCommand(string cmd)
        {
            if (string.IsNullOrWhiteSpace(cmd))
            {
                return false;
            }

            if (IsRecognizedCommand(cmd))
            {
                // When it's already on our list of suggestions.
                return true;
            }

            // If it's not completely certain the command is supported (as it's checked in IsRecognizedCommand),
            // we need to apply strict heuristic check to make sure that we don't collect any other information other than the command in the telemetry.

            var commandParts = cmd.Split(AzPredictorConstants.PowerShellCommandSeparator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            // There must be two parts (verb and noun) to be a valid PowerShell commands.
            // The first part must be an approved PowerShell verb and the second part must begin with "Az".
            if (commandParts?.Length == 2 )
            {
                return AzPredictorConstants.ApprovedPowerShellVerbs.Contains(commandParts[0])
                    && commandParts[1].StartsWith(AzPredictorConstants.AzCommandMoniker, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

        /// <summary>
        /// Checks whether the given <paramref name="cmd" /> is in the command list.
        /// </summary>
        /// <param name="cmd">The command to check if it's in the list.</param>
        protected bool IsRecognizedCommand(string cmd) => _allPredictiveCommands?.Contains(cmd) == true;

        /// <summary>
        /// Requests a list of popular commands from service. These commands are used as fall back suggestion
        /// if none of the predictions fit for the current input. This method should be called once per session.
        /// </summary>
        protected virtual void RequestAllPredictiveCommands()
        {
            // We don't need to block on the task. We send the HTTP request and update commands and predictions list at the background.
            Task.Run(async () =>
                    {
                        var hasSentHttpRequest = false;
                        Exception exception = null;
                        var requestId = Guid.NewGuid().ToString();

                        try
                        {
                            AzPredictorService.SetHttpRequestHeader(_client.DefaultRequestHeaders, _azContext.HashUserId, requestId);

                            var httpResponseMessage = await _client.GetAsync(_commandsEndpoint);
                            hasSentHttpRequest = true;

                            httpResponseMessage.EnsureSuccessStatusCode();
                            var reply = await httpResponseMessage.Content.ReadAsStringAsync();
                            var commandsReply = JsonSerializer.Deserialize<List<PredictiveCommand>>(reply, JsonUtilities.DefaultSerializerOptions);
                            commandsReply.AddRange(_surveyCmdlets);
                            SetFallbackPredictor(commandsReply);
                        }
                        catch (Exception e) when (!(e is OperationCanceledException))
                        {
                            exception = e;
                        }
                        finally
                        {
                            _telemetryClient.RequestId = requestId;
                            _telemetryClient.OnRequestPrediction(new RequestPredictionTelemetryData(null,
                                        new List<string>(),
                                        hasSentHttpRequest,
                                        exception,
                                        _fallbackPredictor.PredictorSummary));
                        }

                        // Initialize predictions
                        var placeholderCommands = new string[] {
                                    AzPredictorConstants.CommandPlaceholder,
                                    AzPredictorConstants.CommandPlaceholder};

                        return AzPredictorUtilities.RequestPredictionAndCollectTelemetryAync(this, _telemetryClient, null, placeholderCommands, null, CancellationToken.None);
                    });
        }

        /// <summary>
        /// Sets the fallback predictor.
        /// </summary>
        /// <param name="commands">The command collection to set the predictor</param>
        protected void SetFallbackPredictor(IList<PredictiveCommand> commands)
        {
            Validation.CheckArgument(commands, $"{nameof(commands)} cannot be null.");

            _fallbackPredictor = new CommandLinePredictor(commands, _parameterValuePredictor, _telemetryClient, _azContext);
            _allPredictiveCommands = commands.Select(x => AzPredictorService.GetCommandName(x.Command)).ToHashSet<string>(StringComparer.OrdinalIgnoreCase); // this could be slow
        }

        /// <summary>
        /// Sets the predictor based on the command history.
        /// </summary>
        /// <param name="commands">The commands that the suggestions are for</param>
        /// <param name="suggestions">The suggestion collection to set the predictor</param>
        protected void SetCommandBasedPreditor(string commands, IList<PredictiveCommand> suggestions)
        {
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(commands), $"{nameof(commands)} cannot be null or whitespace.");
            Validation.CheckArgument(suggestions, $"{nameof(suggestions)} cannot be null.");

            _commandBasedPredictor = Tuple.Create(commands, new CommandLinePredictor(suggestions, _parameterValuePredictor, _telemetryClient, _azContext));
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

        private static void SetHttpRequestHeader(HttpRequestHeaders header, string idToThrottle, string correlationId)
        {
            if (header != null)
            {
                lock (header)
                {
                    header.Remove(AzPredictorService.ThrottleByIdHeader);

                    if (!string.IsNullOrWhiteSpace(idToThrottle))
                    {
                        header.Add(AzPredictorService.ThrottleByIdHeader, idToThrottle);
                    }

                    header.Remove(AzPredictorService.CorrelationIdHeader);

                    if (!string.IsNullOrWhiteSpace(correlationId))
                    {
                        header.Add(AzPredictorService.CorrelationIdHeader, correlationId);
                    }
                }
            }
        }
    }
}
