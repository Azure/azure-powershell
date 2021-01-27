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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation.Language;
using System.Threading.Tasks;
using System.Threading;
using System.Text.Json;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// A predictor to learn and provide values for Azure PowerShell commands' parameters values.
    /// </summary>
    sealed class ParameterValuePredictor
    {
        private readonly ConcurrentDictionary<string, string> _localParameterValues = new ConcurrentDictionary<string, string>();

        private System.Threading.Mutex _mutex = new System.Threading.Mutex(false, "paramValueHistoryFile_update");

        private readonly Dictionary<string, Dictionary<string, string>> _commandParamToResourceMap;

        private string _paramValueHistoryFilePath = "";
        private CancellationTokenSource _cancellationTokenSource;


        private ITelemetryClient _telemetryClient;

        public ParameterValuePredictor(ITelemetryClient telemetryClient)
        {
            Validation.CheckArgument(telemetryClient, $"{nameof(telemetryClient)} cannot be null.");

            _telemetryClient = telemetryClient;

            var fileInfo = new FileInfo(typeof(Settings).Assembly.Location);
            var directory = fileInfo.DirectoryName;
            var mappingFilePath = Path.Join(directory, "command_param_to_resource_map.json");
            Exception exception = null;

            try
            {
                _commandParamToResourceMap = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(File.ReadAllText(mappingFilePath), JsonUtilities.DefaultSerializerOptions);
            }
            catch (Exception e)
            {
                // We don't want it to crash the module when the file doesn't exist or when it's mal-formatted.
                exception = e;
            }
            _telemetryClient.OnLoadParameterMap(new ParameterMapTelemetryData(exception));

            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string[] paths = new string[] { path, "Microsoft", "Windows", "PowerShell", "AzPredictor", "paramValueHistory.json" };
            _paramValueHistoryFilePath = System.IO.Path.Combine(paths);
            Directory.CreateDirectory(Path.GetDirectoryName(_paramValueHistoryFilePath));

            Task.Run(() =>
            {
                if (System.IO.File.Exists(_paramValueHistoryFilePath))
                {
                    _mutex.WaitOne();
                    try
                    {
                        var localParameterValues = JsonSerializer.Deserialize<ConcurrentDictionary<string, string>>(File.ReadAllText(_paramValueHistoryFilePath), JsonUtilities.DefaultSerializerOptions);
                        foreach (var v in localParameterValues)
                        {
                            _localParameterValues.AddOrUpdate(v.Key, key => v.Value, (key, oldValue) => oldValue);
                        }
                    }
                    finally
                    {
                        _mutex.ReleaseMutex();
                    }
                }

                
            });

        }

        

        /// <summary>
        /// Process the command from history
        /// </summary>
        /// <param name="command"></param>
        public void ProcessHistoryCommand(CommandAst command)
        {
            if (command != null)
            {
                ExtractLocalParameters(command);
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
            parameterName = parameterName.ToLower();
            var key = parameterName;
            Dictionary<string, string> commandNounMap = null;

            if (_commandParamToResourceMap?.TryGetValue(commandNoun, out commandNounMap) == true)
            {
                if (commandNounMap.TryGetValue(parameterName, out var parameterNameMappedValue))
                {
                    key = parameterNameMappedValue;
                }
            }

            if (_localParameterValues.TryGetValue(key, out var value))
            {
                return value;
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
        /// <param name="command">The command ast element</param>
        /// <remarks>
        /// This doesn't support positional parameter.
        /// </remarks>
        private void ExtractLocalParameters(CommandAst command)
        {
            // Azure PowerShell command is in the form of {Verb}-Az{Noun}, e.g. New-AzResource.
            // We need to extract the noun to construct the parameter name.

            var commandName = command.GetCommandName();
            var commandNoun = ParameterValuePredictor.GetAzCommandNoun(commandName)?.ToLower();
            if (commandNoun == null)
            {
                return;
            }

            Dictionary<string, string> commandNounMap = null;
            _commandParamToResourceMap?.TryGetValue(commandNoun, out commandNounMap);

            for (int i = 1; i < command.CommandElements.Count;)
            {
                if (command.CommandElements[i] is CommandParameterAst parameterAst)
                {
                    var parameterName = parameterAst.ParameterName.ToLower();
                    string parameterValue = null;

                    // In the form of "-Name:Value"
                    if (parameterAst.Argument != null)
                    {
                        parameterValue = parameterAst.Argument.ToString();
                        ++i;
                    }
                    else if (i + 1 < command.CommandElements.Count)
                    {
                        // We don't support positional parameter.
                        // The next element is either
                        // 1. The value of this parameter name.
                        // 2. This parameter is a switch parameter which doesn't have a value. The next element is a parameter.

                        var nextElement = command.CommandElements[i + 1];

                        if (nextElement is CommandParameterAst)
                        {
                            ++i;
                            continue;
                        }

                        parameterValue = command.CommandElements[i + 1].ToString();
                        i += 2;
                    }

                    var parameterKey = parameterName;

                    if (commandNounMap != null)
                    {
                        if (commandNounMap.TryGetValue(parameterName, out var mappedValue))
                        {
                            parameterKey = mappedValue;
                        }
                    }
                    _cancellationTokenSource?.Cancel();
                    _cancellationTokenSource = new CancellationTokenSource();
                    Task.Run(() =>
                    {
                        this._localParameterValues.AddOrUpdate(parameterKey, parameterValue, (k, v) => parameterValue);
                        if (_cancellationTokenSource.IsCancellationRequested)
                        {
                            throw new OperationCanceledException();
                        }
                        String localParameterValuesJson = JsonSerializer.Serialize<ConcurrentDictionary<string, string>>(_localParameterValues, JsonUtilities.DefaultSerializerOptions);
                        _mutex.WaitOne();
                        try
                        {
                            System.IO.File.WriteAllText(_paramValueHistoryFilePath, localParameterValuesJson);
                        }
                        finally
                        {
                            _mutex.ReleaseMutex();
                        }
                    });
                }
            }
        }
    }
}
