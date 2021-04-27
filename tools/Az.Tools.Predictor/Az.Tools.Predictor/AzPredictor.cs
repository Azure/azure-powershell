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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Management.Automation.Subsystem;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Microsoft.Azure.PowerShell.Tools.AzPredictor.Test")]

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// The implementation of a <see cref="ICommandPredictor"/> to provide suggestions in PSReadLine.
    /// </summary>
    internal sealed class AzPredictor : ICommandPredictor, IDisposable
    {
        /// <inhericdoc />
        public string Name => "Az Predictor";

        /// <inhericdoc />
        public string Description => "Azure PowerShell command predictor";

        /// <inhericdoc />
        public Guid Id => Identifier;

        /// <inhericdoc />
        public bool SupportEarlyProcessing => true;

        /// <inhericdoc />
        public bool AcceptFeedback => true;

        internal static readonly Guid Identifier = new Guid("599d1760-4ee1-4ed2-806e-f2a1b1a0ba4d");

        private const int SuggestionCountForTelemetry = 5;

        private static readonly string[] CommonParameters = new string[] { "location" };

        private readonly IAzPredictorService _service;
        private readonly ITelemetryClient _telemetryClient;
        private readonly Settings _settings;
        private readonly IAzContext _azContext;
        private uint _suggestionSessionId = 0;

        private Queue<string> _lastTwoMaskedCommands = new Queue<string>(AzPredictorConstants.CommandHistoryCountToProcess);
        private CancellationTokenSource _predictionRequestCancellationSource;

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictor"/>.
        /// </summary>
        /// <param name="service">The service that provides the suggestion.</param>
        /// <param name="telemetryClient">The client to collect telemetry.</param>
        /// <param name="settings">The settings for <see cref="AzPredictor"/>.</param>
        /// <param name="azContext">The Az context which this module runs in.</param>
        public AzPredictor(IAzPredictorService service, ITelemetryClient telemetryClient, Settings settings, IAzContext azContext)
        {
            _service = service;
            _telemetryClient = telemetryClient;
            _settings = settings;
            _azContext = azContext;
        }

        /// <inhericdoc/>
        public void Dispose()
        {
            if (_predictionRequestCancellationSource != null)
            {
                _predictionRequestCancellationSource.Dispose();
                _predictionRequestCancellationSource = null;
            }
        }

        /// <inhericdoc />
        public void StartEarlyProcessing(string clientId, IReadOnlyList<string> history)
        {
            // The context only changes when the user executes the corresponding command.
            _azContext?.UpdateContext();

            if (history.Count > 0)
            {
                // We try to find the commands to request predictions for.
                // We should only have "start_of_snippet" when there are no enough Az commands for prediction.
                // We then ignore that when there are new "start_of_snippet".
                // This is the scenario.
                // 1. New-AzResourceGroup -Name ****
                // 2. $resourceName="Test"
                // 3. $resourceLocation="westus2"
                // 4. New-AzVM -Name $resourceName -Location $resourceLocation
                //
                // We'll replace 2 and 3 with "start_of_snippet" but if we request prediction using 2 and 3, that'll reset the
                // workflow. We want to predict only by Az commands. That's to use commands 1 and 4.

                bool isLastTwoCommandsChanged = false;

                if (_lastTwoMaskedCommands.Count == 0)
                {
                    // This is the first time we populate our record. Push the second to last command in history to the
                    // queue. If there is only one command in history, push the command placeholder.

                    if (history.Count() > 1)
                    {
                        string secondToLastLine = history.TakeLast(AzPredictorConstants.CommandHistoryCountToProcess).First();
                        var secondToLastCommand = GetAstAndMaskedCommandLine(secondToLastLine);
                        _lastTwoMaskedCommands.Enqueue(secondToLastCommand.IsSupported ? secondToLastCommand.MaskedValue : AzPredictorConstants.CommandPlaceholder);

                        if (secondToLastCommand.IsSupported)
                        {
                            _service.RecordHistory(secondToLastCommand.Ast);
                        }
                    }
                    else
                    {
                        _lastTwoMaskedCommands.Enqueue(AzPredictorConstants.CommandPlaceholder);
                        // We only extract parameter values from the command line in _service.RecordHistory.
                        // So we don't need to do that for a placeholder.
                    }

                    isLastTwoCommandsChanged = true;
                }

                string lastLine = history.Last();
                var lastCommand = GetAstAndMaskedCommandLine(lastLine);
                bool isLastCommandSupported = lastCommand.IsSupported;

                if (isLastCommandSupported)
                {
                    if (_lastTwoMaskedCommands.Count == 2)
                    {
                        // There are already two commands, dequeue the oldest one.
                        _lastTwoMaskedCommands.Dequeue();
                    }

                    _lastTwoMaskedCommands.Enqueue(lastCommand.Item2);
                    isLastTwoCommandsChanged = true;

                    _service.RecordHistory(lastCommand.Item1);
                }
                else if (_lastTwoMaskedCommands.Count == 1)
                {
                    isLastTwoCommandsChanged = true;
                    var existingInQueue = _lastTwoMaskedCommands.Dequeue();
                    _lastTwoMaskedCommands.Enqueue(AzPredictorConstants.CommandPlaceholder);
                    _lastTwoMaskedCommands.Enqueue(existingInQueue);
                }

                _telemetryClient.OnHistory(new HistoryTelemetryData(clientId, lastCommand.MaskedValue ?? AzPredictorConstants.CommandPlaceholder));

                if (isLastTwoCommandsChanged)
                {
                    // When it's called multiple times, we only need to keep the one for the latest command.

                    _predictionRequestCancellationSource?.Cancel();
                    _predictionRequestCancellationSource = new CancellationTokenSource();
                    // Need to create a new object to hold the string. They're used in a seperate thread the the contents in
                    // _lastTwoMaskedCommands may change when the method is called again.
                    var lastTwoMaskedCommands = new List<string>(_lastTwoMaskedCommands);
                    Exception exception = null;
                    var hasSentHttpRequest = false;

                    // We don't need to block on the task. It sends the HTTP request and update prediction list. That can run at the background.
                    Task.Run(async () =>
                            {
                                try
                                {
                                    await _service.RequestPredictionsAsync(lastTwoMaskedCommands, _predictionRequestCancellationSource.Token);
                                }
                                catch (ServiceRequestException e)
                                {
                                    hasSentHttpRequest = e.IsRequestSent;
                                    exception = e.InnerException;
                                }
                                catch (Exception e)
                                {
                                    exception = e;
                                }
                                finally
                                {
                                    _telemetryClient.OnRequestPrediction(new RequestPredictionTelemetryData(clientId, lastTwoMaskedCommands,
                                                hasSentHttpRequest,
                                                (exception is OperationCanceledException ? null : exception)));
                                }
                            }, _predictionRequestCancellationSource.Token);
                }
            }

            (CommandAst Ast, string MaskedValue, bool IsSupported) GetAstAndMaskedCommandLine(string commandLine)
            {
                var asts = Parser.ParseInput(commandLine, out _, out _);
                var allNestedAsts = asts?.FindAll((ast) => ast is CommandAst, true);
                var commandAst = allNestedAsts?.LastOrDefault() as CommandAst;

                var commandName = commandAst?.CommandElements?.FirstOrDefault().ToString();
                bool isSupported = _service.IsSupportedCommand(commandName);
                string maskedCommandLine = CommandLineUtilities.MaskCommandLine(commandAst);

                return (commandAst, maskedCommandLine, isSupported);
            }
        }

        /// <inhericdoc />
        public SuggestionPackage GetSuggestion(string clientId, PredictionContext context, CancellationToken cancellationToken)
        {
            var localSuggestionSessionId = _suggestionSessionId++;

            if (_settings.SuggestionCount.Value <= 0)
            {
                return CreateResult(null);
            }

            Exception exception = null;
            CommandLineSuggestion suggestions = null;

            try
            {
                var localCancellationToken = Settings.ContinueOnTimeout ? CancellationToken.None : cancellationToken;

                suggestions = _service.GetSuggestion(context, _settings.SuggestionCount.Value, _settings.MaxAllowedCommandDuplicate.Value, localCancellationToken);

                var returnedValue = suggestions?.PredictiveSuggestions?.ToList();
                return CreateResult(returnedValue);
            }
            catch (Exception e) when (!(e is OperationCanceledException))
            {
                exception = e;
                return CreateResult(null);
            }
            finally
            {

                _telemetryClient.OnGetSuggestion(new GetSuggestionTelemetryData(clientId, localSuggestionSessionId, context.InputAst,
                        suggestions,
                        cancellationToken.IsCancellationRequested,
                        exception));
            }

            SuggestionPackage CreateResult(List<PredictiveSuggestion> suggestions)
            {
                if ((suggestions == null) || (suggestions.Count == 0))
                {
                    return default(SuggestionPackage);
                }

                return new SuggestionPackage(localSuggestionSessionId, suggestions);
            }
        }

        /// <inhericdoc />
        public void OnSuggestionDisplayed(string clientId, uint session, int countOrIndex)
        {
            if (countOrIndex > 0)
            {
                _telemetryClient.OnSuggestionDisplayed(SuggestionDisplayedTelemetryData.CreateForListView(clientId, session, countOrIndex));
            }
            else
            {
                _telemetryClient.OnSuggestionDisplayed(SuggestionDisplayedTelemetryData.CreateForInlineView(clientId, session, -countOrIndex));
            }
        }

        /// <inhericdoc />
        public void OnSuggestionAccepted(string clientId, uint session, string acceptedSuggestion)
        {
            _telemetryClient.OnSuggestionAccepted(new SuggestionAcceptedTelemetryData(clientId, session, acceptedSuggestion));
        }
    }

    /// <summary>
    /// The initializer to register the predictor implementation at module loading time.
    /// </summary>
    public class PredictorInitializer : IModuleAssemblyInitializer
    {
        /// <inheritdoc/>
        public void OnImport()
        {
            var settings = Settings.GetSettings();
            var azContext = new AzContext()
            {
                IsInternal = (settings.SetAsInternal == true) ? true : false,
                SurveyId = settings.SurveyId?.ToString(CultureInfo.InvariantCulture) ?? string.Empty,
            };

            azContext.UpdateContext();
            var telemetryClient = new AzPredictorTelemetryClient(azContext);
            var azPredictorService = new AzPredictorService(settings.ServiceUri, telemetryClient, azContext);
            var predictor = new AzPredictor(azPredictorService, telemetryClient, settings, azContext);
            SubsystemManager.RegisterSubsystem<ICommandPredictor, AzPredictor>(predictor);
        }
    }

    /// <summary>
    /// Clean up the registeration when unloading the module.
    /// </summary>
    public class PredictorCleanup : IModuleAssemblyCleanup
    {
        /// <inheritdoc/>
        public void OnRemove(PSModuleInfo psModuleInfo)
        {
            SubsystemManager.UnregisterSubsystem<ICommandPredictor>(AzPredictor.Identifier);
        }
    }
}
