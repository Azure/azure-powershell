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

namespace StaticAnalysis.DependencyAnalyzer
{
    /// <summary>
    /// Record to indicate a difference in assembly file versions for shared assemblies with the same 
    /// assembly version. This could result in unexpected behavior, depending on the assembly load order.
    /// </summary>
    public class SharedAssemblyConflict : IReportRecord
    {
        public string AssemblyName { get; set; }
        public Version AssemblyVersion { get; set; }
        public List<Tuple<string, Version>> AssemblyPathsAndFileVersions { get; set; }
        public string Description { get; set; }
        public string Remediation { get; set; }
        public int Severity { get; set; }

        public string PrintHeaders()
        {
            return "\"Target\",\"AssemblyName\",\"AssemblyVersion\",\"Severity\",\"Description\",\"Remediation\"";
        }

        public string FormatRecord()
        {
            var targets =
                AssemblyPathsAndFileVersions.Select(s => string.Format("File version {0} in {1}", s.Item2, s.Item1));
            var targetString = string.Join(", ", targets);
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\"", targetString, AssemblyName,
                AssemblyVersion, Severity, Description, Remediation);
        }

        public override string ToString()
        {
            return FormatRecord();
        }
    }
}
