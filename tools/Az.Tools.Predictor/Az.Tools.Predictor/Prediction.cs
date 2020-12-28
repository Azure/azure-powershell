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

using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// A prediction candidate consists of the command name and list of parameter sets,
    /// where each parameter set is a set of parameters (order independent) that go along with the command.
    /// </summary>
    sealed class Prediction
    {
        /// <summary>
        /// Gets the command name
        /// </summary>
        public string Command { get; }

        /// <summary>
        /// Gets the list of <see cref="ParameterSet "/>
        /// </summary>
        public IList<ParameterSet> ParameterSets { get; }

        /// <summary>
        /// Create a new instance of <see cref="Prediction "/> with the command and parameter set.
        /// </summary>
        /// <param name="command">The command name</param>
        /// <param name="parameters">The parameter set</param>
        public Prediction(string command, ParameterSet parameters)
        {
            this.Command = command;
            ParameterSets = new List<ParameterSet>
            {
                parameters
            };
        }
    }
}
