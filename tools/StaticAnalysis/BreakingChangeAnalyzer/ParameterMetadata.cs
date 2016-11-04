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

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    /// <summary>
    /// Information about cmdlet parameters
    /// </summary>
    [Serializable]
    public class ParameterMetadata
    {
        private List<string> _aliases = new List<string>();
        private List<ParameterSetMetadata> _parameterSets = new List<ParameterSetMetadata>();
        private List<string> _validateSet = new List<string>();

        /// <summary>
        /// The parameter name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The set of aliases
        /// </summary>
        public List<string> AliasList { get { return _aliases; } }

        /// <summary>
        /// The parameter type
        /// </summary>
        public TypeMetadata Type { get; set; }

        /// <summary>
        /// The set of parameter sets of the parameter
        /// </summary>
        public List<ParameterSetMetadata> ParameterSets { get { return _parameterSets; } }

        /// <summary>
        /// The set of valid arguments for the parameter
        /// </summary>
        public List<string> ValidateSet { get { return _validateSet; } }
    }
}
