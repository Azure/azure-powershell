﻿// ----------------------------------------------------------------------------------
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
    [Serializable]
    public class OutputMetadata
    {
        private List<string> _parameterSets = new List<String>();

        /// <summary>
        /// The output type
        /// </summary>
        public TypeMetadata Type { get; set; }

        /// <summary>
        /// The parameter sets for the given output type
        /// </summary>
        public List<string> ParameterSets { get { return _parameterSets; } }
    }
}
