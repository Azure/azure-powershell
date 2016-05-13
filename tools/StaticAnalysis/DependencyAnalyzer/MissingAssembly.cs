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
using System.Text.RegularExpressions;

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
        public int ProblemId { get; set; }
        public string Description { get; set; }
        public string Remediation { get; set; }
        public int Severity { get; set; }

        public string PrintHeaders()
        {
            return "\"Directory\",\"Assembly Name\",\"Assembly Version\",\"Referencing Assembly\"," +
                   "\"Severity\",\"ProblemId\",\"Description\",\"Remediation\"";
        }

        public string FormatRecord()
        {
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"",
                Directory, AssemblyName, AssemblyVersion, ReferencingAssembly,
                Severity, ProblemId, Description, Remediation);
        }

        public bool Match(IReportRecord other)
        {
            var result = false;
            var record = other as MissingAssembly;
            if (record != null)
            {
                result = string.Equals(EnvironmentHelpers.GetDirectoryName(record.Directory), 
                         EnvironmentHelpers.GetDirectoryName(Directory), StringComparison.OrdinalIgnoreCase)
                         && string.Equals(record.AssemblyName, AssemblyName, StringComparison.OrdinalIgnoreCase) 
                         && string.Equals(record.AssemblyVersion, AssemblyVersion, StringComparison.OrdinalIgnoreCase) 
                         && string.Equals(record.ReferencingAssembly, ReferencingAssembly, StringComparison.OrdinalIgnoreCase) 
                         && record.ProblemId == ProblemId;
            }
            
            return result;
        }

        public IReportRecord Parse(string line)
        {
            var matcher = "\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\"";
            var match = Regex.Match(line, matcher);
            if (!match.Success || match.Groups.Count < 9)
            {
                throw new InvalidOperationException(string.Format("Could not parse '{0}' as MissingAssembly record", line));
            }

            Directory = match.Groups[1].Value;
            AssemblyName = match.Groups[2].Value;
            AssemblyVersion = match.Groups[3].Value;
            ReferencingAssembly = match.Groups[4].Value;
            Severity = int.Parse(match.Groups[5].Value);
            ProblemId = int.Parse(match.Groups[6].Value);
            Description = match.Groups[7].Value;
            Remediation = match.Groups[8].Value;
            return this;
        }

        public override string ToString()
        {
            return FormatRecord();
        }
    }
}
