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
using System.IO;
using System.Text.RegularExpressions;

namespace StaticAnalysis.DependencyAnalyzer
{
    /// <summary>
    /// Indicates a conflict between assembly reference and actual assembly in a directory
    /// </summary>
    public class AssemblyVersionConflict : IReportRecord
    {
        /// <summary>
        /// The directory containing a conflict
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// The name of the assembly
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// The version referenced in the parent assembly manifest
        /// </summary>
        public Version ExpectedVersion { get; set; }

        /// <summary>
        /// The version of the assembly on disk
        /// </summary>
        public Version ActualVersion { get; set; }

        /// <summary>
        /// The identity of the parent assembly
        /// </summary>
        public string ParentAssembly { get; set; }

        /// <summary>
        /// Machine readable identity of the problem
        /// </summary>
        public int ProblemId { get; set; }

        /// <summary>
        /// A textual description of the problem
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A textual description of steps to remediate the issue
        /// </summary>
        public string Remediation { get; set; }

        public int Severity { get; set; }

        public string PrintHeaders()
        {
            return
                "\"Directory\",\"AssemblyName\",\"Expected Version\",\"Actual Version\",\"Parent Assembly\",\"Severity\"," +
                "\"ProblemId\",\"Description\",\"Remediation\"";
        }

        public string FormatRecord()
        {
            return
                string.Format(
                    "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\"",
                    Directory, AssemblyName, ExpectedVersion, ActualVersion, ParentAssembly, Severity,
                    ProblemId, Description, Remediation);
        }
        public bool Match(IReportRecord other)
        {
            var result = false;
            var record = other as AssemblyVersionConflict;
            if (record != null)
            {
                result = string.Equals(EnvironmentHelpers.GetDirectoryName(record.Directory), 
                    EnvironmentHelpers.GetDirectoryName(Directory), StringComparison.OrdinalIgnoreCase)
                     && string.Equals(record.AssemblyName, AssemblyName, StringComparison.OrdinalIgnoreCase) 
                     && string.Equals(record.ParentAssembly, ParentAssembly, StringComparison.OrdinalIgnoreCase) 
                     &&record.ProblemId == ProblemId;
            }
            
            return result;
        }

        public IReportRecord Parse(string line)
        {
            var matcher = "\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\"";
            var match = Regex.Match(line, matcher);
            if (!match.Success || match.Groups.Count < 10)
            {
                throw new InvalidOperationException(string.Format("Could not parse '{0}' as AssemblyVersionConflict record", line));
            }

            Directory = match.Groups[1].Value;
            AssemblyName = match.Groups[2].Value;
            ExpectedVersion = Version.Parse(match.Groups[3].Value);
            ActualVersion = Version.Parse(match.Groups[4].Value);
            ParentAssembly = match.Groups[5].Value;
            Severity = int.Parse(match.Groups[6].Value);
            ProblemId = int.Parse(match.Groups[7].Value);
            Description = match.Groups[8].Value;
            Remediation = match.Groups[9].Value;
            return this;
        }

        public override string ToString()
        {
            return FormatRecord();
        }
    }
}
