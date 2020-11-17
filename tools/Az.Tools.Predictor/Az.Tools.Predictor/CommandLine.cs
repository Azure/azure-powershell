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

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// A command line consists of the command name and the parameter set,
    /// where the parameter set is a set of parameters (order independent) that go along with the command.
    /// </summary>
    sealed class CommandLine
    {
        /// <summary>
        /// Gets the command name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the <see cref="ParameterSet "/>.
        /// </summary>
        public ParameterSet ParameterSet { get; }

        /// <summary>
        /// Create a new instance of <see cref="CommandLine"/> with the command name and parameter set.
        /// </summary>
        /// <param name="name">The command name.</param>
        /// <param name="parameterSet">The parameter set.</param>
        public CommandLine(string name, ParameterSet parameterSet)
        {
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(name), $"{nameof(name)} must not be null or whitespace.");

            Name = name;
            ParameterSet = parameterSet;
        }
    }
}
