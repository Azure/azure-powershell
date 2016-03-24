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

namespace StaticAnalysis.DependencyAnalyzer
{
    /// <summary>
    /// Record to indicate an assembly that is not in the dependency tree for a cmdlet assembly
    /// </summary>
    public class MissingAssembly : IReportRecord
    {
        public string Directory { get; set; }
        public string AssemblyName { get; set; }
        public string AssemblyVersion { get; set; }
        public string ReferencingAssembly { get; set; }
        public string Description { get; set; }
        public string Remediation { get; set; }
        public int Severity { get; set; }

        public string PrintHeaders()
        {
            return "\"Directory\",\"Assembly Name\",\"Assembly Version\",\"Referencing Assembly\"," +
                   "\"Severity\",\"Description\",\"Remediation\"";
        }

        public string FormatRecord()
        {
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\"",
                Directory, AssemblyName, AssemblyVersion, ReferencingAssembly,
                Severity, Description, Remediation);
        }

        public override string ToString()
        {
            return FormatRecord();
        }
    }
}
