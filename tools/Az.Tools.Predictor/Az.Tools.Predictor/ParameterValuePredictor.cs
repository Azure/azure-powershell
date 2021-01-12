using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        private readonly ConcurrentDictionary<string, string> _localParameterValues = new ConcurrentDictionary<string, string>();

        private readonly Dictionary<string, Dictionary<string, string>> _command_param_to_resource_map;

        public ParameterValuePredictor()
        {
            var fileInfo = new FileInfo(typeof(Settings).Assembly.Location);
            var directory = fileInfo.DirectoryName;
            var mappingFilePath = Path.Join(directory, "command_param_to_resource_map.json");
            _command_param_to_resource_map = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(File.ReadAllText(mappingFilePath), JsonUtilities.DefaultSerializerOptions);
        }

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
        /// <param name="commandNoun">The command noun</param>
        /// <param name="parameterName">The parameter name</param>
        /// <returns>The parameter value from the history command. Null if that is not available.</returns>
        public string GetParameterValueFromAzCommand(string commandNoun, string parameterName)
        {
            if (_command_param_to_resource_map.ContainsKey(commandNoun))
            {
                parameterName = parameterName.ToLower();
                if (_command_param_to_resource_map[commandNoun].ContainsKey(parameterName))
                {
                    var key = _command_param_to_resource_map[commandNoun][parameterName];
                    if (_localParameterValues.TryGetValue(key, out var value))
                    {
                        return value;
                    }
                }
            }
            return null;
        }

        
        public static string GetAzCommandNoun(string commandName)
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
            var commandNoun = ParameterValuePredictor.GetAzCommandNoun(commandName)?.ToLower();
            if (commandNoun == null)
            {
                return;
            }

            for (int i = 2; i < command.Count; i += 2)
            {
                if (command[i - 1] is CommandParameterAst parameterAst && command[i] is StringConstantExpressionAst)
                {
                    var parameterName = command[i - 1].ToString().ToLower().Trim('-');
                    if (_command_param_to_resource_map.ContainsKey(commandNoun))
                    {
                        if (_command_param_to_resource_map[commandNoun].ContainsKey(parameterName))
                        {
                            var key = _command_param_to_resource_map[commandNoun][parameterName];
                            var parameterValue = command[i].ToString();
                            this._localParameterValues.AddOrUpdate(key, parameterValue, (k, v) => parameterValue);
                        }
                    }
                }   
            }
        }
    }
}
