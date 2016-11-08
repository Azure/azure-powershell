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
using System.Text;
using System.Threading.Tasks;

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    /// <summary>
    /// Information about a parameter in a parameter set
    /// </summary>
    [Serializable]
    public class ParameterSetMetadata
    {
        /// <summary>
        /// Specifies if the parameter is mandatory in the given parameter set
        /// </summary>
        public bool Mandatory { get; set; }

        /// <summary>
        /// Name of the parameter set
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Position of the parameter in the parameter set
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Indicates whether the parameter takes its value from a
        /// pipeline object
        /// </summary>
        public bool ValueFromPipeline { get; set; }

        /// <summary>
        /// Indicates whether the parameter takes its value from a property
        /// of a pipeline object that has either the same name or the same 
        /// alias as this parameter
        /// </summary>
        public bool ValueFromPipelineByPropertyName { get; set; }
    }
}
