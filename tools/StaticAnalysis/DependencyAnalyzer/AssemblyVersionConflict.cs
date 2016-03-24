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
                "\"Description\",\"Remediation\"";
        }

        public string FormatRecord()
        {
            return
                string.Format(
                    "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"",
                    Directory, AssemblyName, ExpectedVersion, ActualVersion, ParentAssembly, Severity,
                    Description, Remediation);
        }

        public override string ToString()
        {
            return FormatRecord();
        }
    }
}
