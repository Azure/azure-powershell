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
using System.Management.Automation;

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    /// <summary>
    /// Data about the cmdlet
    /// </summary>
    [Serializable]
    public class CmdletBreakingChangeMetadata
    {
        private IList<OutputMetadata> _outputTypes = new List<OutputMetadata>();
        private IList<ParameterMetadata> _parameters = new List<ParameterMetadata>();

        private List<string> _aliases = new List<string>();

        /// <summary>
        /// The verb portion of the cmdlet name
        /// </summary>
        public string VerbName { get; set; }

        /// <summary>
        /// The noun portion of the cmdlet name
        /// </summary>
        public string NounName { get; set; }

        /// <summary>
        /// The name of the cmdlet
        /// </summary>
        public string Name { get { return string.Format("{0}-{1}", VerbName, NounName); } }
        
        /// <summary>
        /// The name of the class that implements the cmdlet
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Indicates whether the cmdlet may ask for confirmation
        /// </summary>
        public bool SupportsShouldProcess { get; set; }

        /// <summary>
        /// The impact of the operation, used to determine prompting with ShouldProcess
        /// </summary>
        public ConfirmImpact ConfirmImpact { get; set; }

        /// <summary>
        /// Indicates whether the cmdlet supports paging
        /// </summary>
        public bool SupportsPaging { get; set; }

        /// <summary>
        /// The set of output types for the cmdlet
        /// </summary>
        public IList<OutputMetadata> OutputTypes { get { return _outputTypes; } }

        /// <summary>
        /// The set of cmdlet parameters
        /// </summary>
        public IList<ParameterMetadata> Parameters { get { return _parameters; } }

        /// <summary>
        /// The set of aliases
        /// </summary>
        public List<string> AliasList { get { return _aliases; } }
    }
}
