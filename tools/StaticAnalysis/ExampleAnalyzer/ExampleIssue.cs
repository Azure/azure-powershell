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
using Tools.Common.Issues;

namespace StaticAnalysis.ExampleAnalyzer
{
    public class ExampleIssue : IReportRecord
    {
        public int ProblemId { get; set; }
        public string Description { get; set; }
        public string Remediation { get; set; }
        public int Severity { get; set; }
        public string PrintHeaders()
        {
            return "\"Severity\",\"ProblemId\",\"Description\",\"Remediation\"";
        }

        public string FormatRecord()
        {
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",
                Severity, ProblemId, Description, Remediation);
        }

        public bool Match(IReportRecord other)
        {
            var result = false;
            var record = other as ExampleIssue;
            if (record != null)
            {
                result =(record.ProblemId == ProblemId) &&
                        (record.Severity == Severity) &&
                        (record.Description == Description);
            }

            return result;
        }

        public IReportRecord Parse(string line)
        {
            var matcher = "\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\",\"([^\"]+)\"";
            var match = Regex.Match(line, matcher);
            if (!match.Success || match.Groups.Count < 5)
            {
                throw new InvalidOperationException(string.Format("Could not parse '{0}' as ExampleIssue record", line));
            }

            Severity = int.Parse(match.Groups[1].Value);
            ProblemId = int.Parse(match.Groups[2].Value);
            Description = match.Groups[3].Value;
            Remediation = match.Groups[4].Value;
            return this;
        }
    }
}