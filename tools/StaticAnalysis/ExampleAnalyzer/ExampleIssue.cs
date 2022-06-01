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
        public int ProblemId { get; set; }
        public int Severity { get; set; }
        public string Description { get; set; }
        public string Remediation { get; set; }
        public string PrintHeaders()
        {
            return "\"Module\",\"Cmdlet\",\"Example\",\"RuleName\",\"ProblemId\",\"Severity\",\"Description\",\"Remediation\"";
        }

        public string FormatRecord()
        {
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"",
                Module, Cmdlet, Example, RuleName, ProblemId, Severity, Description, Remediation);
        }

        public bool Match(IReportRecord other)
        {
            var result = false;
            var record = other as ExampleIssue;
            if (record != null)
            {
                result =(record.Severity == Severity) &&
                        (record.Description == Description);
            }

            return result;
        }

        public IReportRecord Parse(string line)
        {
            var matcher = "\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\"";
            var match = Regex.Match(line, matcher);
            if (!match.Success || match.Groups.Count < 8)
            {
                throw new InvalidOperationException(string.Format("Could not parse '{0}' as ExampleIssue record", line));
            }
            Module = match.Groups[1].Value;
            Cmdlet = match.Groups[2].Value;
            Example = int.Parse(match.Groups[3].Value);
            RuleName = match.Groups[4].Value;
            var problemMap = new Dictionary<string, int>
            {
                {"Invalid_Cmdlet", 3001},
                {"Is_Alias", 3002},
                {"Capitalization_Conventions_Violated", 3003},
                {"Unknown_Parameter_Set",3101},
                {"Invalid_Parameter_Name",3102},
                {"Duplicate_Parameter_Name",3103},
                {"Unassigned_Parameter",3104}
            };
            ProblemId = problemMap[RuleName];
            var severityMap = new Dictionary<string, int>
            {
                {"Error", 1}
            };
            Severity = severityMap[match.Groups[5].Value];
            Description = match.Groups[6].Value;
            Remediation = match.Groups[7].Value;
            return this;
        }
    }
}