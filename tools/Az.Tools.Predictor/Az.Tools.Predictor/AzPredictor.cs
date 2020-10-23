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
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Management.Automation.Subsystem;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

[assembly:InternalsVisibleTo("Microsoft.Azure.PowerShell.Tools.AzPredictor.Test")]

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// The implementation of a <see cref="ICommandPredictor"/> to provide suggestion in PSReadLine.
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
        private const string ParameterValueMask = "***";
        private const char ParameterValueSeperator = ':';

        private static readonly string[] CommonParameters = new string[] { "location" };

        private readonly IAzPredictorService _service;
        private readonly ITelemetryClient _telemetryClient;
        private readonly Settings _settings;

        private Queue<string> _lastTwoMaskedCommands = new Queue<string>(AzPredictorConstants.CommandHistoryCountToProcess);

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictor"/>
        /// </summary>
        /// <param name="service">The service that provides the suggestion</param>
        /// <param name="telemetryClient">The client to collect telemetry</param>
        /// <param name="settings">The settings of the service</param>
        public AzPredictor(IAzPredictorService service, ITelemetryClient telemetryClient, Settings settings)
        {
            this._service = service;
            this._telemetryClient = telemetryClient;
            this._settings = settings;
        }

        /// <inhericdoc />
        public void StartEarlyProcessing(IReadOnlyList<string> history)
        {
            if (history.Count > 0)
            {
                if (_lastTwoMaskedCommands.Any())
                {
                    _lastTwoMaskedCommands.Dequeue();
                }
                else
                {
                    // This is the first time we populate our record. Push the second to last command in history to the
                    // queue. If there is only one command in history, push the command placeholder.

                    if (history.Count() > 1)
                    {
                        string secondToLastLine = history.TakeLast(AzPredictorConstants.CommandHistoryCountToProcess).First();
                        var secondToLastCommand = GetAstAndMaskedCommandLine(secondToLastLine);
                        _lastTwoMaskedCommands.Enqueue(secondToLastCommand.Item2);
                        _service.RecordHistory(secondToLastCommand.Item1);
                    }
                    else
                    {
                        _lastTwoMaskedCommands.Enqueue(AzPredictorConstants.CommandPlaceholder);
                        // We only extract parameter values from the command line in _service.RecordHistory.
                        // So we don't need to do that for a placeholder.
                    }
                }

                string lastLine = history.Last();
                var lastCommand = GetAstAndMaskedCommandLine(lastLine);

                _lastTwoMaskedCommands.Enqueue(lastCommand.Item2);

                if ((lastCommand.Item2 != null) && !string.Equals(AzPredictorConstants.CommandPlaceholder, lastCommand.Item2, StringComparison.Ordinal))
                {
                    _service.RecordHistory(lastCommand.Item1);
                }

                _telemetryClient.OnHistory(lastCommand.Item2);
                _service.RequestPredictions(_lastTwoMaskedCommands);
            }

            ValueTuple<CommandAst, string> GetAstAndMaskedCommandLine(string commandLine)
            {
                var asts = Parser.ParseInput(commandLine, out _, out _);
                var allNestedAsts = asts?.FindAll((ast) => ast is CommandAst, true);
                var commandAst = allNestedAsts?.LastOrDefault() as CommandAst;
                string maskedCommandLine = null;

                var commandName = commandAst?.CommandElements?.FirstOrDefault().ToString();

                if (_service.IsSupportedCommand(commandName))
                {
                    maskedCommandLine = AzPredictor.MaskCommandLine(commandAst);
                }
                else
                {
                    maskedCommandLine = AzPredictorConstants.CommandPlaceholder;
                }

                return ValueTuple.Create(commandAst, maskedCommandLine);
            }
        }

        /// <inhericdoc />
        public void OnSuggestionAccepted(string acceptedSuggestion)
        {
            _telemetryClient.OnSuggestionAccepted(acceptedSuggestion);
        }

        /// <inhericdoc />
        public List<PredictiveSuggestion> GetSuggestion(PredictionContext context, CancellationToken cancellationToken)
        {
            // Eventually, the rendering layer in PSReadLine will show the suggestions in a list,
            // with an experience similar to you typing in the text box in google/bing search page.
            // Hence, the returned texts don't have to be prefixed with the `userInput`, but the
            // text should be in the order of relevance, meaning that if you have a result that
            // is prefixed with `userInput`, it should be ordered before result that is not prefixed
            // with `userInput`.

            IEnumerable<ValueTuple<string, PredictionSource>> suggestions = Enumerable.Empty<ValueTuple<string, PredictionSource>>();

            try
            {
                suggestions = _service.GetSuggestion(context.InputAst, _settings.SuggestionCount.Value, Settings.ContinueOnTimeout ? CancellationToken.None : cancellationToken);

                if (!Settings.ContinueOnTimeout)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }

                var userInput = context.InputAst.Extent.Text;
                return suggestions.Select((r, index) =>
                    {
                        return new PredictiveSuggestion(MergeStrings(userInput, r.Item1));
                    })
                    .ToList();
            }
            catch (Exception e) when (!(e is OperationCanceledException))
            {
                this._telemetryClient.OnGetSuggestionError(e);
            }
            finally
            {
                var maskedCommandLine = MaskCommandLine(context.InputAst.FindAll((ast) => ast is CommandAst, true).LastOrDefault() as CommandAst);
                _telemetryClient.OnGetSuggestion(maskedCommandLine, suggestions, cancellationToken.IsCancellationRequested);
            }

            return new List<PredictiveSuggestion>();
        }

        // Merge strings a and b such that the prefix of b is deleted if it is the suffix of a
        private static string MergeStrings(string a, string b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                var j = i;
                while (char.ToLower(a[j]) == char.ToLower(b[j - i]))
                {
                    j++;
                    if (j == a.Length)
                    {
                        return a.Substring(0, i) + b;
                    }
                }
            }

            return a + b;
        }

        /// <summary>
        /// Masks the user input of any data, like names and locations.
        /// Also alphabetizes the parameters to normalize them before sending
        /// them to the model.
        /// e.g., Get-AzContext -Name Hello -Location 'EastUS' => Get-AzContext -Location *** -Name ***
        /// </summary>
        /// <param name="cmdAst">The last user input command</param>
        private static string MaskCommandLine(CommandAst cmdAst)
        {
            var commandElements = cmdAst?.CommandElements;

            if (commandElements == null)
            {
                return null;
            }

            if (commandElements.Count == 1)
            {
                return cmdAst.Extent.Text;
            }

            var sb = new StringBuilder(cmdAst.Extent.Text.Length);
            _ = sb.Append(commandElements[0].ToString());
            var parameters = commandElements
                .Skip(1)
                .Where(element => element is CommandParameterAst)
                .Cast<CommandParameterAst>()
                .OrderBy(ast => ast.ParameterName);

            foreach (CommandParameterAst param in parameters)
            {
                _ = sb.Append(AzPredictorConstants.CommandParameterSeperator);
                if (param.Argument != null)
                {
                    // Parameter is in the form of `-Name:name`
                    _ = sb.Append(AzPredictorConstants.ParameterIndicator)
                        .Append(param.ParameterName)
                        .Append(AzPredictor.ParameterValueSeperator)
                        .Append(AzPredictor.ParameterValueMask);
                }
                else
                {
                    // Parameter is in the form of `-Name`
                    _ = sb.Append(AzPredictorConstants.ParameterIndicator)
                        .Append(param.ParameterName)
                        .Append(AzPredictorConstants.CommandParameterSeperator)
                        .Append(AzPredictor.ParameterValueMask);
                }
            }
            return sb.ToString();
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
            var telemetryClient = new AzPredictorTelemetryClient();
            var azPredictorService = new AzPredictorService(settings.ServiceUri, telemetryClient);
            var predictor = new AzPredictor(azPredictorService, telemetryClient, settings);
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
