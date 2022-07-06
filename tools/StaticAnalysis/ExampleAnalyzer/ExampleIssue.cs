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
using System.Collections.Generic;

namespace StaticAnalysis.ExampleAnalyzer
{
    public class ExampleIssue : IReportRecord
    {
        public string Module { get; set; }
        public string Cmdlet { get; set; }
        public int Example { get; set; }
        public string RuleName { get; set; }
        public string Extent { get; set; }
        public int ProblemId { get; set; }
        public int Severity { get; set; }
        public string Description { get; set; }
        public string Remediation { get; set; }
        public string PrintHeaders()
        {
            return "\"Module\",\"Cmdlet\",\"Example\",\"RuleName\",\"ProblemId\",\"Severity\",\"Description\",\"Extent\",\"Remediation\"";
        }

        public string FormatRecord()
        {
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\"",
                Module, Cmdlet, Example, RuleName, ProblemId, Severity, Description, Extent, Remediation);
        }

        public bool Match(IReportRecord other)
        {
            var result = false;
            var record = other as ExampleIssue;
            if (record != null)
            {
                result = (record.Module == Module)&&
                (record.Cmdlet == Cmdlet)&&
                (record.Example == Example)&&
                (record.ProblemId == ProblemId)&&
                (record.Description == Description);
            }
            return result;
        }

        public IReportRecord Parse(string line)
        {
            var matcher = "\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\"";
            var match = Regex.Match(line, matcher);
            if (!match.Success || match.Groups.Count < 10)
            {
                throw new InvalidOperationException(string.Format("Could not parse '{0}' as ExampleIssue record", line));
            }
            Module = match.Groups[1].Value;
            Cmdlet = match.Groups[2].Value;
            Example = int.Parse(match.Groups[3].Value);
            RuleName = match.Groups[4].Value;
            ProblemId = int.Parse(match.Groups[5].Value);
            Severity = int.Parse(match.Groups[6].Value);
            Description = match.Groups[7].Value;
            Extent = match.Groups[8].Value;
            Remediation = match.Groups[9].Value;
            return this;
        }
    }
}