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

[assembly: InternalsVisibleTo("Microsoft.Azure.PowerShell.Tools.AzPredictor.Test")]

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// The implementation of a <see cref="ICommandPredictor"/> to provide suggestions in PSReadLine.
    /// </summary>
    internal sealed class AzPredictor : ICommandPredictor
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

        private Queue<string> _lastTwoMaskedCommands = new Queue<string>(AzPredictorConstants.CommandHistoryCountToProcess);

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

        /// <inhericdoc />
        public void StartEarlyProcessing(IReadOnlyList<string> history)
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
                        _lastTwoMaskedCommands.Enqueue(secondToLastCommand.Item2);

                        if (!string.Equals(AzPredictorConstants.CommandPlaceholder, secondToLastCommand.Item2, StringComparison.Ordinal))
                        {
                            _service.RecordHistory(secondToLastCommand.Item1);
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
                bool isLastCommandSupported = !string.Equals(AzPredictorConstants.CommandPlaceholder, lastCommand.Item2, StringComparison.Ordinal);

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

                _telemetryClient.OnHistory(new HistoryTelemetryData(lastCommand.Item2));

                if (isLastTwoCommandsChanged)
                {
                    _service.RequestPredictions(_lastTwoMaskedCommands);
                }
            }

            ValueTuple<CommandAst, string> GetAstAndMaskedCommandLine(string commandLine)
            {
                var asts = Parser.ParseInput(commandLine, out _, out _);
                var allNestedAsts = asts?.FindAll((ast) => ast is CommandAst, true);
                var commandAst = allNestedAsts?.LastOrDefault() as CommandAst;
                string maskedCommandLine = AzPredictorConstants.CommandPlaceholder;

                var commandName = commandAst?.CommandElements?.FirstOrDefault().ToString();

                if (_service.IsSupportedCommand(commandName))
                {
                    maskedCommandLine = CommandLineUtilities.MaskCommandLine(commandAst);
                }

                return ValueTuple.Create(commandAst, maskedCommandLine);
            }
        }

        /// <inhericdoc />
        public void OnSuggestionAccepted(string acceptedSuggestion)
        {
            _telemetryClient.OnSuggestionAccepted(new SuggestionAcceptedTelemetryData(acceptedSuggestion));
        }

        /// <inhericdoc />
        public List<PredictiveSuggestion> GetSuggestion(PredictionContext context, CancellationToken cancellationToken)
        {
            if (_settings.SuggestionCount.Value <= 0)
            {
                return new List<PredictiveSuggestion>();
            }

            Exception exception = null;
            CommandLineSuggestion suggestions = null;

            try
            {
                var localCancellationToken = Settings.ContinueOnTimeout ? CancellationToken.None : cancellationToken;

                suggestions = _service.GetSuggestion(context, _settings.SuggestionCount.Value, _settings.MaxAllowedCommandDuplicate.Value, localCancellationToken);

                var returnedValue = suggestions?.PredictiveSuggestions?.ToList();
                return returnedValue ?? new List<PredictiveSuggestion>();
            }
            catch (Exception e) when (!(e is OperationCanceledException))
            {
                exception = e;
                return new List<PredictiveSuggestion>();
            }
            finally
            {

                _telemetryClient.OnGetSuggestion(new GetSuggestionTelemetryData(context.InputAst,
                        suggestions,
                        cancellationToken.IsCancellationRequested,
                        exception));
            }
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
