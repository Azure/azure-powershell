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
using System.Management.Automation.Language;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// A command line consists of the command name and the parameter set,
    /// where the parameter set is a set of parameters (order independent) that go along with the command.
    /// </summary>
    struct CommandLine
    {
        /// <summary>
        /// Gets the command name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the description text for the command.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the <see cref="ParameterSet "/>.
        /// </summary>
        public ParameterSet ParameterSet { get; }

        /// <summary>
        /// Gets the text of the whole command line that is used to get the <see cref="CommandLine.Name" /> and <see cref="CommandLine.ParameterSet" />.
        /// </summary>
        public string SourceText { get; }

        /// <summary>
        /// Create a new instance of <see cref="CommandLine"/> from <see cref="PredictiveCommand" />.
        /// </summary>
        /// <param name="predictiveCommand">The command information.</param>
        /// <param name="azContext">The current PowerShell conext.</param>
        public CommandLine(PredictiveCommand predictiveCommand, IAzContext azContext = null)
        {
            Validation.CheckArgument(predictiveCommand, $"{nameof(predictiveCommand)} cannot be null.");
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(predictiveCommand.Command), $"{nameof(predictiveCommand.Command)} cannot be null or whitespace.");

            var predictionText = CommandLineUtilities.EscapePredictionText(predictiveCommand.Command);
            var commandAst = CommandLineUtilities.GetCommandAst(predictionText);
            var commandName = commandAst?.GetCommandName();

            Validation.CheckInvariant<CommandLineException>(!string.IsNullOrWhiteSpace(commandName), "Cannot get the command name from the model.");

            var parameterSet = new ParameterSet(commandAst, azContext);

            Name = commandName;
            Description = predictiveCommand.Description;
            ParameterSet = parameterSet;
            SourceText = predictiveCommand.Command;
        }
    }
}
