﻿// ----------------------------------------------------------------------------------
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Management.Automation.Subsystem;
using System.Management.Automation.Subsystem.Prediction;
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
        private struct ParsedCommandLineHistory
        {
            public CommandAst Ast;
            public string MaskedCommandLine;
            public bool IsSupported;
        }

        /// <inhericdoc />
        public string Name => "Az Predictor";

        /// <inhericdoc />
        public string Description => "Azure PowerShell command predictor";

        /// <inhericdoc />
        public Guid Id => Identifier;

        internal static readonly Guid Identifier = new Guid("599d1760-4ee1-4ed2-806e-f2a1b1a0ba4d");

        private const int SuggestionCountForTelemetry = 5;

        private static readonly HashSet<string> _azAccountCommands = new HashSet<string>(new string[]
                {
                    "Connect-AzAccount", "Clear-AzContext", "Disconnect-AzAccount", "Import-AzContext", "Remove-AzContext", "Set-AzContext"
                },
                StringComparer.InvariantCultureIgnoreCase);

        private static readonly PredictiveSuggestion[] _surveySuggestions = new PredictiveSuggestion[AzPredictorConstants.CohortCount]
        {
            new PredictiveSuggestion("Open-AzPredictorSurvey # Run this command to tell us about your experience with Az Predictor"),
            new PredictiveSuggestion("Send-AzPredictorRating # Run this command followed by your rating of Az Predictor: 1 (poor) - 5 (great)"),
        };

        private IAzPredictorService _service;
        private ITelemetryClient _telemetryClient;
        private Settings _settings;
        private IAzContext _azContext;
        private uint _suggestionSessionId = 0;

        private Queue<string> _lastTwoMaskedCommands = new Queue<string>(AzPredictorConstants.CommandHistoryCountToProcess);
        private ConcurrentDictionary<string, ParsedCommandLineHistory> _parsedCommandLineHistory = new ConcurrentDictionary<string, ParsedCommandLineHistory>();

        private CancellationTokenSource _predictionRequestCancellationSource;
        private TaskCompletionSource _commandLineExecutedCompletion;

        private List<IDisposable> _externalDisposableObjects = new List<IDisposable>();

        private bool _isInitialized;

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictor"/> to use in PowerShell's prediction subsystem.
        /// </summary>
        public AzPredictor()
        {
            // To make import-module fast, we'll do all the initialization in a task.
            // Slow initialization may make opening a PowerShell window slow if "Import-Module" is added to the user's profile.
            Task.Run(() =>
                    {
                        _settings = Settings.GetSettings();
                        var azContext = new AzContext()
                        {
                            IsInternal = (_settings.SetAsInternal == true) ? true : false,
                            SurveyId = _settings.SurveyId?.ToString(CultureInfo.InvariantCulture) ?? string.Empty,
                        };

                        RegisterDisposableObject(azContext);

                        _azContext = azContext;

                        _azContext.UpdateContext();
                        _telemetryClient = new AzPredictorTelemetryClient(_azContext);
                        _service = new AzPredictorService(_settings.ServiceUri, _telemetryClient, _azContext);
                        _isInitialized = true;
                    });
        }

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictor"/> for testing.
        /// </summary>
        /// <param name="service">The service that provides the suggestion.</param>
        /// <param name="telemetryClient">The client to collect telemetry.</param>
        /// <param name="settings">The settings for <see cref="AzPredictor"/>.</param>
        /// <param name="azContext">The Az context which this module runs in.</param>
        internal AzPredictor(IAzPredictorService service, ITelemetryClient telemetryClient, Settings settings, IAzContext azContext)
        {
            _service = service;
            _telemetryClient = telemetryClient;
            _settings = settings;
            _azContext = azContext;
            _isInitialized = true;
        }

        /// <inhericdoc/>
        public void Dispose()
        {
            if (_predictionRequestCancellationSource != null)
            {
                _predictionRequestCancellationSource.Dispose();
                _predictionRequestCancellationSource = null;
            }

            _externalDisposableObjects.ForEach((o) => o?.Dispose());
            _externalDisposableObjects.Clear();
        }

        /// <inhericdoc />
        public bool CanAcceptFeedback(PredictionClient client, PredictorFeedbackKind feedback)
        {
            if (!_isInitialized)
            {
                return false;
            }

            switch (feedback)
            {
                case PredictorFeedbackKind.SuggestionDisplayed:
                case PredictorFeedbackKind.SuggestionAccepted:
                case PredictorFeedbackKind.CommandLineAccepted:
                case PredictorFeedbackKind.CommandLineExecuted:
                    return true;
                default:
                    return false;
            }
        }

        /// <inhericdoc />
        public void OnCommandLineAccepted(PredictionClient client, IReadOnlyList<string> history)
        {
            _commandLineExecutedCompletion = new TaskCompletionSource();

            if (history.Count > 0)
            {
                // We try to find the commands to request predictions for.
                // We should only have "start_of_snippet" when there are no enough Az commands for prediction.
                // We only send the requests when Az commands are changed. So we'll never add "start_of_snippet" again
                // once we have enough Az commands.
                // This is the scenario.
                // 1. New-AzResourceGroup -Name ****
                // 2. $resourceName="Test"
                // 3. $resourceLocation="westus2"
                // 4. New-AzVM -Name $resourceName -Location $resourceLocation
                //
                // If the history only contains 1, we'll add "start_of_snippet" to the request.
                // We'll replace 2 and 3 with "start_of_snippet". But if we request prediction using 2 and 3, that'll reset the
                // workflow. We want to predict only by Az commands. So we don't send the request until the command 4.
                // That's to use commands 1 and 4 to request prediction.

                bool ShouldRequestPrediction = false;

                if (_lastTwoMaskedCommands.Count == 0)
                {
                    // This is the first time we populate our record. Push the second to last command in history to the
                    // queue. If there is only one command in history, push the command placeholder.

                    if (history.Count() > 1)
                    {
                        string secondToLastLine = history.TakeLast(AzPredictorConstants.CommandHistoryCountToProcess).First();
                        var secondToLastCommand = GetAstAndMaskedCommandLine(secondToLastLine);
                        _lastTwoMaskedCommands.Enqueue(secondToLastCommand.IsSupported ? secondToLastCommand.MaskedCommandLine : AzPredictorConstants.CommandPlaceholder);

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

                    ShouldRequestPrediction = true;
                }

                string lastLine = history.Last();
                var lastCommand = GetAstAndMaskedCommandLine(lastLine);
                bool isLastCommandSupported = lastCommand.IsSupported;

                _parsedCommandLineHistory.TryAdd(lastLine, lastCommand);

                if (isLastCommandSupported)
                {
                    if (_lastTwoMaskedCommands.Count == 2)
                    {
                        // There are already two commands, dequeue the oldest one.
                        _lastTwoMaskedCommands.Dequeue();
                    }

                    _lastTwoMaskedCommands.Enqueue(lastCommand.MaskedCommandLine);
                    ShouldRequestPrediction = true;

                    _service.RecordHistory(lastCommand.Ast);
                }
                else if (_lastTwoMaskedCommands.Count == 1)
                {
                    ShouldRequestPrediction = true;
                    var existingInQueue = _lastTwoMaskedCommands.Dequeue();
                    _lastTwoMaskedCommands.Enqueue(AzPredictorConstants.CommandPlaceholder);
                    _lastTwoMaskedCommands.Enqueue(existingInQueue);
                }


                if (ShouldRequestPrediction)
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
                                var localCommandLineExecutedCompletion = _commandLineExecutedCompletion;
                                var requestId = Guid.NewGuid().ToString();

                                try
                                {
                                    hasSentHttpRequest = await _service.RequestPredictionsAsync(lastTwoMaskedCommands, requestId,  _predictionRequestCancellationSource.Token);
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
                                    await localCommandLineExecutedCompletion.Task;
                                    _telemetryClient.RequestId = requestId;
                                    _telemetryClient.OnRequestPrediction(new RequestPredictionTelemetryData(client, lastTwoMaskedCommands,
                                                hasSentHttpRequest,
                                                (exception is OperationCanceledException ? null : exception)));
                                }
                            }, _predictionRequestCancellationSource.Token);
                }
            }
        }

        public void OnCommandLineExecuted(PredictionClient client, string commandLine, bool success)
        {
            if (success && AzPredictor._azAccountCommands.Contains(commandLine.Trim().Split().FirstOrDefault()))
            {
                // The context only changes when the user executes the corresponding command successfully.
                _azContext?.UpdateContext();
            }

            if (!_parsedCommandLineHistory.TryRemove(commandLine, out var parsedResult))
            {
                // We should already parsed the last command in OnCommandLineAccepted which we don't need to do again now.
                // Just in case that wasn't correct or that's missing, we clear the _parsedCommandLineHistory and parse it now.
                // On possible reason it's missing is because we're still initializing in the task and don't handle
                // OnCommandLineAccepted.
                _parsedCommandLineHistory.Clear();
                parsedResult = GetAstAndMaskedCommandLine(commandLine);
            }

            _telemetryClient.OnHistory(new HistoryTelemetryData(client, parsedResult.MaskedCommandLine ?? AzPredictorConstants.CommandPlaceholder, success));
            _commandLineExecutedCompletion?.SetResult();
        }

        /// <inhericdoc />
        public SuggestionPackage GetSuggestion(PredictionClient client, PredictionContext context, CancellationToken cancellationToken)
        {
            var localSuggestionSessionId = _suggestionSessionId++;

            if (!_isInitialized || _settings.SuggestionCount.Value <= 0)
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

                _telemetryClient.OnGetSuggestion(new GetSuggestionTelemetryData(client, localSuggestionSessionId, context.InputAst,
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

                // Replace the last suggestion with "Open-AzPredictorSurvey".

                if (suggestions.Count == _settings.SuggestionCount.Value)
                {
                    suggestions[suggestions.Count - 1] = _surveySuggestions[_azContext?.Cohort ?? 0];
                }
                else
                {
                    suggestions.Add(_surveySuggestions[_azContext?.Cohort ?? 0]);
                }

                return new SuggestionPackage(localSuggestionSessionId, suggestions);
            }
        }

        /// <inhericdoc />
        public void OnSuggestionDisplayed(PredictionClient client, uint session, int countOrIndex)
        {
            if (countOrIndex > 0)
            {
                _telemetryClient.OnSuggestionDisplayed(SuggestionDisplayedTelemetryData.CreateForListView(client, session, countOrIndex));
            }
            else
            {
                _telemetryClient.OnSuggestionDisplayed(SuggestionDisplayedTelemetryData.CreateForInlineView(client, session, -countOrIndex));
            }
        }

        /// <inhericdoc />
        public void OnSuggestionAccepted(PredictionClient client, uint session, string acceptedSuggestion)
        {
            _telemetryClient.OnSuggestionAccepted(new SuggestionAcceptedTelemetryData(client, session, acceptedSuggestion));
        }

        /// <summary>
        /// Addds an object that's not created by <see cref="AzPredictor"/> to the list to be disposed in
        /// <see cref="AzPredictor.Dispose"/>.
        /// </summary>
        public void RegisterDisposableObject(IDisposable o)
        {
            _externalDisposableObjects.Add(o);
        }

        private ParsedCommandLineHistory GetAstAndMaskedCommandLine(string commandLine)
        {
            var asts = Parser.ParseInput(commandLine, out _, out _);
            var allNestedAsts = asts?.FindAll((ast) => ast is CommandAst, true);
            var commandAst = allNestedAsts?.LastOrDefault() as CommandAst;

            var commandName = commandAst?.CommandElements?.FirstOrDefault().ToString();
            bool isSupported = _service.IsSupportedCommand(commandName);
            string maskedCommandLine = CommandLineUtilities.MaskCommandLine(commandAst);

            return new ParsedCommandLineHistory
            {
                Ast = commandAst,
                MaskedCommandLine = maskedCommandLine,
                IsSupported = isSupported
            };
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
            var predictor = new AzPredictor();
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
