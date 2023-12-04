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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Management.Automation.Runspaces;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// Treating parameter lists as sets of parameters to show that parameter order
    /// does not matter to resulting prediction - the prediction should adapt to the
    /// order of the parameters typed by the user.
    /// </summary>
    sealed class ParameterSet
    {
        /// <summary>
        /// Gets the list of the parameters with their names and values.
        /// </summary>
        public IReadOnlyList<Parameter> Parameters { get; }

        private readonly CommandAst _commandAst;
        private readonly IAzContext _azContext;

        // The bound parameters are used to parse the positional parameters.
        // We don't always need to handle positional parameters. The data set we get from the service are in the format
        // of named parameters. In that case, we don't need to spend time to get the bound parameters.
        private IDictionary<string, ParameterBindingResult> _boundParameters;

        private IDictionary<string, ParameterBindingResult> BoundParameters
        {
            get
            {
                if (_boundParameters == null)
                {
                    Validation.CheckInvariant<CommandLineException>(_azContext != null, "The az context must not be null.");

                    Runspace.DefaultRunspace = _azContext.DefaultRunspace;
                    var boundResult = StaticParameterBinder.BindCommand(_commandAst);
                    Runspace.DefaultRunspace = null;
                    if (boundResult.BindingExceptions.Any())
                    {
                        throw new CommandLineException("There are errors in binding the parameters.");
                    }

                    _boundParameters = boundResult.BoundParameters;
                }

                return _boundParameters;
            }
        }

        public ParameterSet(CommandAst commandAst, IAzContext azContext = null)
        {
            Validation.CheckArgument(commandAst, $"{nameof(commandAst)} cannot be null.");

            _commandAst = commandAst;
            _azContext = azContext;

            var parameters = new List<Parameter>();
            CommandParameterAst param = null;
            Ast arg = null;

            // positional parameters must be before named parameters.
            // This loop will convert them to named parameters.
            // Loop through all the parameters. The first element of CommandElements is the command name, so skip it.
            bool hasSeenNamedParameter = false;
            bool hasSeenIncompleteParameter = false;
            try
            {
                for (var i = 1; i < commandAst.CommandElements.Count(); ++i)
                {
                    var elem = commandAst.CommandElements[i];

                    if (elem is null)
                    {
                        continue;
                    }

                    if (elem is CommandParameterAst p)
                    {
                        if (hasSeenIncompleteParameter)
                        {
                            throw new CommandLineException("'-' is in the middle of the parameter list.");
                        }

                        hasSeenNamedParameter = true;
                        AddNamedParameter(param, arg);
                        // In case there is a switch parameter, we store the parameter name/value and add them when we see the next pair.
                        param = p;
                        arg = null;
                    }
                    else if (elem?.ToString()?.Trim()?.Length == 1 && (AzPredictorConstants.ParameterIndicator == elem.ToString().Trim().FirstOrDefault()))
                    {
                        // We have an incomplete command line such as
                        // `New-AzResourceGroup -Name ResourceGroup01 -Location WestUS -`
                        // We'll ignore the incomplete parameter.
                        AddNamedParameter(param, arg);
                        param = null;
                        arg = null;
                        hasSeenIncompleteParameter = true;
                        parameters.Add(new Parameter(AzPredictorConstants.DashParameterName, null, false));
                    }
                    else
                    {
                        if (hasSeenIncompleteParameter || (hasSeenNamedParameter && param == null))
                        {
                            throw new CommandLineException("Positional parameters must be before named parameters.");
                        }

                        if (param == null)
                        {
                            // This is a positional parameter.
                            var pair = BoundParameters.First((pair) => pair.Value.Value == elem);

                            var parameterName = pair.Key;
                            var parameterValue = pair.Value.Value.ToString();
                            parameters.Add(new Parameter(parameterName, parameterValue, true));
                            BoundParameters.Remove(pair); // Remove it so that we can match another parameter with the same value.
                        }
                        else
                        {
                            arg = elem;
                            AddNamedParameter(param, arg);
                            param = null;
                            arg = null;
                        }
                    }
                }

                Validation.CheckInvariant<CommandLineException>((param != null) || (arg == null));
                AddNamedParameter(param, arg);

                Parameters = parameters;
            }
            catch (Exception e) when (!(e is CommandLineException))
            {
                throw new CommandLineException("There are errors in parsing the parameters.", e);
            }

            void AddNamedParameter(CommandParameterAst parameter, Ast parameterValue)
            {
                if (parameter != null)
                {
                    var value = parameterValue?.ToString();
                    if (value == null)
                    {
                        value = parameter.Argument?.ToString();
                    }

                    if (value != null)
                    {
                        value = CommandLineUtilities.UnescapePredictionText(value);
                    }

                    parameters.Add(new Parameter(parameter.ParameterName, value, false));
                }
            }
        }
    }
}
