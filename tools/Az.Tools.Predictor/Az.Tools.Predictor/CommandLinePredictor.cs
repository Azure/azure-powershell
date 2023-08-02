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
using System.Management.Automation.Subsystem.Prediction;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// This class query the command model from Aladdin service and return suggestions based on user input, for example,
    /// when the user inputs "Connec", it returns "Connect-AzAccount".
    /// </summary>
    /// <remarks>
    /// The suggestion returned to PSReadLine may not be the same as the model to generate the suggestion. The suggestion may
    /// be adjusted based on user input.
    /// </remarks>
    internal sealed class CommandLinePredictor
    {
        private class DuplicateResult
        {
            public string Source { get; set; }

            public string Description { get; set; }

            public DuplicateResult(string source, string description)
            {
                this.Source = source;
                this.Description = description;
            }
        }

        private readonly IList<CommandLine> _commandLinePredictions = new List<CommandLine>();
        private readonly ParameterValuePredictor _parameterValuePredictor;
        private readonly ITelemetryClient _telemetryClient;

        public CommandLineSummary PredictorSummary { get; init; }

        /// <summary>
        /// Creates a new instance of <see cref="CommandLinePredictor"/>.
        /// </summary>
        /// <param name="modelPredictions">List of suggestions from the model, sorted by frequency (most to least).</param>
        /// <param name="parameterValuePredictor">Provide the prediction to the parameter values.</param>
        /// <param name="telemetryClient">The telemetry client.</param>
        /// <param name="azContext">The current PowerShell conext.</param>
        public CommandLinePredictor(IList<PredictiveCommand> modelPredictions, ParameterValuePredictor parameterValuePredictor, ITelemetryClient telemetryClient, IAzContext azContext = null)
        {
            Validation.CheckArgument(modelPredictions, $"{nameof(modelPredictions)} cannot be null.");

            _telemetryClient = telemetryClient;
            _parameterValuePredictor = parameterValuePredictor;
            var errors = new HashSet<string>();

            if (modelPredictions != null)
            {
                for (var i = 0; i < modelPredictions.Count; ++i)
                {
                    try
                    {
                        this._commandLinePredictions.Add(new CommandLine(modelPredictions[i], azContext));
                    }
                    catch (Exception e)
                    {
                        errors.Add(e.Message);
                    }
                }
            }

            PredictorSummary = new CommandLineSummary(modelPredictions?.Count ?? 0, this._commandLinePredictions.Count, errors);
        }

        /// <summary>
        /// Returns suggestions given the user input.
        /// </summary>
        /// <param name="inputCommandName">The command name extracted from the user input.</param>
        /// <param name="inputParameterSet">The parameter set extracted from the user input.</param>
        /// <param name="rawUserInput">The string format of the command line from user input.</param>
        /// <param name="presentCommands">Commands already present. Contents may be added to this collection.</param>
        /// <param name="suggestionCount">The number of suggestions to return.</param>
        /// <param name="maxAllowedCommandDuplicate">The maximum amount of the same commands in the list of predictions.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The collections of suggestions.</returns>
        public CommandLineSuggestion GetSuggestion(string inputCommandName,
                ParameterSet inputParameterSet,
                string rawUserInput,
                IDictionary<string, int> presentCommands,
                int suggestionCount,
                int maxAllowedCommandDuplicate,
                CancellationToken cancellationToken)
        {
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(inputCommandName), $"{nameof(inputCommandName)} cannot be null or whitespace.");
            Validation.CheckArgument(inputParameterSet, $"{nameof(inputParameterSet)} cannot be null.");
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(rawUserInput), $"{nameof(rawUserInput)} cannot be null or whitespace.");
            Validation.CheckArgument(presentCommands, $"{nameof(presentCommands)} cannot be null.");
            Validation.CheckArgument<ArgumentOutOfRangeException>(suggestionCount > 0, $"{nameof(suggestionCount)} must be larger than 0.");
            Validation.CheckArgument<ArgumentOutOfRangeException>(maxAllowedCommandDuplicate > 0, $"{nameof(maxAllowedCommandDuplicate)} must be larger than 0.");

            const int commandCollectionCapacity = 10;
            CommandLineSuggestion result = new();
            var duplicateResults = new Dictionary<string, DuplicateResult>(commandCollectionCapacity, StringComparer.OrdinalIgnoreCase);

            var isCommandNameComplete = (inputParameterSet.Parameters.Count > 0) || rawUserInput.EndsWith(' ');

            Func<string, bool> commandNameQuery = (command) => command.Equals(inputCommandName, StringComparison.OrdinalIgnoreCase);
            if (!isCommandNameComplete)
            {
                commandNameQuery = (command) => command.StartsWith(inputCommandName, StringComparison.OrdinalIgnoreCase);
            }

            // Try to find the matching command and arrange the parameters in the order of the input.
            //
            // Predictions should be flexible, e.g. if "Command -Name N -Location L" is a possibility,
            // then "Command -Location L -Name N" should also be possible.
            //
            // resultBuilder and usedParams are used to store the information to construct the result.
            // We want to avoid too much heap allocation for the performance purpose.

            const int parameterCollectionCapacity = 10;
            var resultBuilder = new StringBuilder();
            var usedParams = new HashSet<int>(parameterCollectionCapacity);

            for (var i = 0; i < _commandLinePredictions.Count && result.Count < suggestionCount; ++i)
            {
                if (commandNameQuery(_commandLinePredictions[i].Name))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    resultBuilder.Clear();
                    resultBuilder.Append(_commandLinePredictions[i].Name);
                    usedParams.Clear();
                    string commandNoun = ParameterValuePredictor.GetCommandNoun(_commandLinePredictions[i].Name)?.ToLower();

                    if (DoesPredictionParameterSetMatchInput(resultBuilder, inputParameterSet, commandNoun, _commandLinePredictions[i].ParameterSet, usedParams))
                    {
                        PredictRestOfParameters(resultBuilder, commandNoun, _commandLinePredictions[i].ParameterSet.Parameters, usedParams);

                        if (resultBuilder.Length <= rawUserInput.Length)
                        {
                            // We don't add anything to to the raw user input. So skip this.
                            continue;
                        }

                        var prediction = resultBuilder.ToString();

                        if (!presentCommands.ContainsKey(_commandLinePredictions[i].Name))
                        {
                            result.AddSuggestion(new PredictiveSuggestion(prediction, _commandLinePredictions[i].Description), _commandLinePredictions[i].SourceText);
                            presentCommands.Add(_commandLinePredictions[i].Name, 1);
                        }
                        else if (presentCommands[_commandLinePredictions[i].Name] < maxAllowedCommandDuplicate)
                        {
                            result.AddSuggestion(new PredictiveSuggestion(prediction, _commandLinePredictions[i].Description), _commandLinePredictions[i].SourceText);
                            presentCommands[_commandLinePredictions[i].Name] += 1;
                        }
                        else
                        {
                            _ = duplicateResults.TryAdd(prediction, new DuplicateResult(_commandLinePredictions[i].SourceText, _commandLinePredictions[i].Description));
                        }
                    }
                }
            }

            var resultCount = result.Count;

            if ((resultCount < suggestionCount) && (duplicateResults.Count > 0))
            {
                foreach (var temp in duplicateResults.Take(suggestionCount - resultCount))
                {
                    result.AddSuggestion(new PredictiveSuggestion(temp.Key, temp.Value.Description), temp.Value.Source);
                }
            }

            return result;
        }

        /// <summary>
        /// Appends unused parameters to the builder.
        /// </summary>
        /// <param name="builder">StringBuilder that aggregates the prediction text output.</param>
        /// <param name="commandNoun">Command Noun.</param>
        /// <param name="parameters">Chosen prediction parameters.</param>
        /// <param name="usedParams">Set of used parameters for set.</param>
        private void PredictRestOfParameters(StringBuilder builder, string commandNoun, IReadOnlyList<Parameter> parameters, HashSet<int> usedParams)
        {
            for (var j = 0; j < parameters.Count; j++)
            {
                if (!usedParams.Contains(j))
                {
                    BuildParameterValue(builder, commandNoun, parameters[j]);
                }
            }
        }

        /// <summary>
        /// Determines if parameter set contains all of the parameters of the input.
        /// </summary>
        /// <param name="builder">StringBuilder that aggregates the prediction text output.</param>
        /// <param name="inputParameters">Parsed ParameterSet from the user input AST.</param>
        /// <param name="commandNoun">Command Noun.</param>
        /// <param name="predictionParameters">Candidate prediction parameter set.</param>
        /// <param name="usedParams">Set of used parameters for set.</param>
        private bool DoesPredictionParameterSetMatchInput(StringBuilder builder, ParameterSet inputParameters, string commandNoun,ParameterSet predictionParameters, HashSet<int> usedParams)
        {
            for (var i = 0; i < inputParameters.Parameters.Count; ++i)
            {
                var inputParameter = inputParameters.Parameters[i];
                var matchIndex = FindParameterPositionInSet(inputParameter, predictionParameters, usedParams);
                if (matchIndex == -1)
                {
                    return false;
                }
                else
                {
                    usedParams.Add(matchIndex);
                    if (inputParameter.Value != null)
                    {
                        AppendParameterNameAndValue(builder, predictionParameters.Parameters[matchIndex].Name, inputParameter.Value, inputParameter.IsPositional);
                    }
                    else
                    {
                        BuildParameterValue(builder, commandNoun, predictionParameters.Parameters[matchIndex]);
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Create the parameter values from the history commandlines.
        ///
        /// For example:
        /// history command line
        /// > New-AzVM -Name "TestVM" ...
        /// prediction:
        /// > Get-AzVM -VMName &lt;TestVM&gt;
        /// "TestVM" is predicted for Get-AzVM.
        /// </summary>
        /// <param name="builder">The string builder to create the whole predicted command line.</param>
        /// <param name="commandNoun">Command Noun.</param>
        /// <param name="parameter">The parameter name and value from prediction.</param>
        private void BuildParameterValue(StringBuilder builder, string commandNoun, Parameter parameter)
        {
            var parameterName = parameter.Name;
            string parameterValue = this._parameterValuePredictor?.GetParameterValueFromCommand(commandNoun, parameterName);

            if (string.IsNullOrWhiteSpace(parameterValue))
            {
                parameterValue = parameter.Value;
            }

            AppendParameterNameAndValue(builder, parameterName, parameterValue, isPositional: false);
        }

        /// <summary>
        /// Determines the index of the given parameter in the parameter set.
        /// </summary>
        /// <param name="parameter">The parameter name and its value.</param>
        /// <param name="predictionSet">Prediction parameter set to find parameter position in.</param>
        /// <param name="usedParams">Set of used parameters for set.</param>
        private static int FindParameterPositionInSet(Parameter parameter, ParameterSet predictionSet, HashSet<int> usedParams)
        {
            var isPrefixed = string.Equals(parameter.Name, AzPredictorConstants.DashParameterName, StringComparison.Ordinal);
            for (var k = 0; k < predictionSet.Parameters.Count; k++)
            {
                isPrefixed = isPrefixed || predictionSet.Parameters[k].Name.StartsWith(parameter.Name, StringComparison.OrdinalIgnoreCase);
                var hasNotBeenUsed = !usedParams.Contains(k);
                if (isPrefixed && hasNotBeenUsed)
                {
                    return k;
                }
            }

            return -1;
        }

        private static void AppendParameterNameAndValue(StringBuilder builder, string name, string value, bool isPositional)
        {
            if (!isPositional)
            {
                _ = builder.Append(AzPredictorConstants.CommandParameterSeperator);
                _ = builder.Append(AzPredictorConstants.ParameterIndicator);
                _ = builder.Append(name);
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                _ = builder.Append(AzPredictorConstants.CommandParameterSeperator);
                _ = builder.Append(value);
            }
        }
    }
}
