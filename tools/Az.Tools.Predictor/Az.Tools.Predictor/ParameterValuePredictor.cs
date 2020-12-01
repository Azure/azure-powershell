using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// A predictor to learn and provide values for Azure PowerShell commands' parameters values.
    /// </summary>
    sealed class ParameterValuePredictor
    {
        /// <summary>
        /// The collections of the parameter names that is used directly as the key in local parameter collection.
        /// </summary>
        private static readonly IReadOnlyCollection<string> _specialLocalParameterNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "location", "credential", "addressprefix" };

        private readonly ConcurrentDictionary<string, string> _localParameterValues = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// Process the command from history
        /// </summary>
        /// <param name="command"></param>
        public void ProcessHistoryCommand(CommandAst command)
        {
            if (command != null)
            {
                ExtractLocalParameters(command.CommandElements);
            }
        }

        /// <summary>
        /// Gets the parameter value prediction from the previous Azure PowerShell command.
        /// e.g. history command line
        /// > New-AzVM -Name "TestVM" ...
        /// prediction:
        /// > Get-AzVM -VMName &lt;TestVM&gt;
        /// "TestVM" is predicted for Get-AzVM.
        /// </summary>
        /// <param name="parameterName">The parameter name</param>
        /// <returns>The parameter value from the history command. Null if that is not available.</returns>
        public string GetParameterValueFromAzCommand(string parameterName)
        {
            parameterName = parameterName.TrimStart(AzPredictorConstants.ParameterIndicator);
            if (_localParameterValues.TryGetValue(parameterName.ToUpper(), out var value))
            {
                return value;
            }

            return null;
        }

        /// <summary>
        /// Gets the key to the local parameter dictionary from the command noun and the parameter name.
        /// </summary>
        /// <param name="commandNoun">The noun in the PowerShell command, e.g. the noun for command New-AzVM is VM.</param>
        /// <param name="parameterName">The command's parameter name, e.g. "New-AzVM -Name" the parameter name is Name</param>
        /// <returns></returns>
        private static string GetLocalParameterKey(string commandNoun, string parameterName)
        {
            return _specialLocalParameterNames.Contains(parameterName) ? parameterName.ToUpper() : string.Concat(commandNoun, parameterName).ToUpper();
        }

        private static string GetAzCommandNoun(string commandName)
        {
            var monikerIndex = commandName?.IndexOf(AzPredictorConstants.AzCommandMoniker, StringComparison.OrdinalIgnoreCase);

            if (!monikerIndex.HasValue || (monikerIndex.Value == -1))
            {
                return null;
            }

            return commandName.Substring(monikerIndex.Value + AzPredictorConstants.AzCommandMoniker.Length);
        }

        /// <summary>
        /// Iterate over command elements to extract local parameter values.
        ///
        /// Store these values by a key
        /// consisting of the suffix of the command + the parameter name.  There are some exceptions, e.g.
        /// credential, location, where the parameter name itself is the key.
        ///
        /// For example, New-AzResourceGroup -Name Hello -Location 'EastUS' will store into local parameters:
        ///   ResourceGroupName => Hello
        ///   Location => 'EastUS'
        /// </summary>
        /// <param name="command">The command ast elements</param>
        private void ExtractLocalParameters(System.Collections.ObjectModel.ReadOnlyCollection<CommandElementAst> command)
        {
            // Azure PowerShell command is in the form of {Verb}-Az{Noun}, e.g. New-AzResource.
            // We need to extract the noun to construct the parameter name.

            var commandName = command.FirstOrDefault()?.ToString();
            var commandNoun = ParameterValuePredictor.GetAzCommandNoun(commandName);
            if (commandNoun == null)
            {
                return;
            }

            for (int i = 2; i < command.Count; i += 2)
            {
                if (command[i - 1] is CommandParameterAst && command[i] is StringConstantExpressionAst)
                {
                    var parameterName = command[i - 1].ToString().TrimStart(AzPredictorConstants.ParameterIndicator);
                    var key = ParameterValuePredictor.GetLocalParameterKey(commandNoun, parameterName);
                    var parameterValue = command[i].ToString();
                    this._localParameterValues.AddOrUpdate(key, parameterValue, (k, v) => parameterValue);
                }
            }
        }
    }
}
