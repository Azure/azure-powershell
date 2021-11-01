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
using System.Text.RegularExpressions;
using Tools.Common.Issues;

namespace StaticAnalysis.HelpAnalyzer
{
    public class HelpIssue : IReportRecord
    {
        /// <summary>
        /// The assembly containing the help issue
        /// </summary>
        public string Assembly { get; set; }
        /// <summary>
        /// The associated help file.
        /// </summary>
        public string HelpFile { get; set; }
        /// <summary>
        /// The target of the report (cmdlet name, etc..)
        /// </summary>
        public string Target { get; set; }

        public int ProblemId { get; set; }
        public string Description { get; set; }
        public string Remediation { get; set; }
        public int Severity { get; set; }
        public string PrintHeaders()
        {
            return "\"Assembly\",\"HelpFile\",\"Target\",\"Severity\",\"ProblemId\",\"Description\",\"Remediation\"";
        }

        public string FormatRecord()
        {
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\"",
                Assembly, HelpFile, Target, Severity, ProblemId, Description, Remediation);
        }

        public bool Match(IReportRecord other)
        {
            var result = false;
            var record = other as HelpIssue;
            if (record != null)
            {
                result = string.Equals(record.Assembly, Assembly, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(record.HelpFile, HelpFile, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(record.Target, Target, StringComparison.OrdinalIgnoreCase) &&
                         record.ProblemId == ProblemId;
            }

            return result;
        }

        public IReportRecord Parse(string line)
        {
            var matcher = "\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]*)\",\"([^\"]*)\"";
            var match = Regex.Match(line, matcher);
            if (!match.Success || match.Groups.Count < 8)
            {
                throw new InvalidOperationException(string.Format("Could not parse '{0}' as HelpIssue record", line));
            }

            Assembly = match.Groups[1].Value;
            HelpFile = match.Groups[2].Value;
            Target = match.Groups[3].Value;
            Severity = int.Parse(match.Groups[4].Value);
            ProblemId = int.Parse(match.Groups[5].Value);
            Description = match.Groups[6].Value;
            Remediation = match.Groups[7].Value;
            return this;
        }
    }
}
