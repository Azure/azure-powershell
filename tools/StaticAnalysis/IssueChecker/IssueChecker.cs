//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Tools.Common.Issues;
using Tools.Common.Loggers;
using StaticAnalysis.BreakingChangeAnalyzer;
using StaticAnalysis.DependencyAnalyzer;

namespace StaticAnalysis.IssueChecker
{
    public class IssueChecker : IStaticAnalyzer
    {
        private readonly List<(string, string)> exceptionLogInfoList = new List<(string, string)>()
        {
            ("BreakingChangeIssues.csv", typeof(BreakingChangeIssue).FullName),
            ("AssemblyVersionConflict.csv", typeof(AssemblyVersionConflict).FullName),
            ("SharedAssemblyConflict.csv", typeof(SharedAssemblyConflict).FullName),
            ("MissingAssemblies.csv", typeof(MissingAssembly).FullName),
            ("ExtraAssemblies.csv", typeof(ExtraAssembly).FullName),
        };
        public AnalysisLogger Logger { get; set; }

        public string Name { get; private set; }

        public IssueChecker()
        {
            Name = "Issue Checker";
        }

        public void Analyze(IEnumerable<string> scopes)
        {
            Analyze(scopes, null);
        }

        public void Analyze(IEnumerable<string> scopes, IEnumerable<string> modulesToAnalyze)
        {
            foreach (string scope in scopes)
            {
                Console.WriteLine(scope);
            }
            if (scopes.ToList().Count != 1)
            {
                throw new InvalidOperationException(string.Format("scopes for IssueChecker should be a array contains only reportsDirectory, but here is [{0}]", string.Join(", ", scopes.ToList())));
            }
            string reportsDirectory = scopes.First();

            bool hasCriticalIssue = false;
            foreach ((string, string) item in exceptionLogInfoList)
            {
                string exceptionFileName = item.Item1;
                string recordTypeName = item.Item2;

                string exceptionFilePath = Path.Combine(reportsDirectory, exceptionFileName);
                if (!File.Exists(exceptionFilePath))
                {
                    continue;
                }
                if (IsSingleExceptionFileHasCriticalIssue(exceptionFilePath, recordTypeName))
                {
                    hasCriticalIssue = true;
                }
            }
            if (hasCriticalIssue)
            {
                throw new InvalidOperationException(string.Format("One or more errors occurred in validation. " +
                                                                  "See the analysis reports at {0} for details",
                    reportsDirectory));
            }
        }

        private bool IsSingleExceptionFileHasCriticalIssue(string exceptionFilePath, string reportRecordTypeName) 
        {
            bool hasError = false;
            using (var reader = new StreamReader(exceptionFilePath))
            {
                List<IReportRecord> recordList = new List<IReportRecord>();
                string header = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    IReportRecord newRecord = ReportRecordFactory.Create(reportRecordTypeName);
                    recordList.Add(newRecord.Parse(line));
                }
                var errorText = new StringBuilder();
                errorText.AppendLine(recordList.First().PrintHeaders());
                foreach (IReportRecord record in recordList)
                {
                    if (record.Severity < 2)
                    {
                        hasError = true;
                        errorText.AppendLine(record.FormatRecord());
                    }
                }
                if (hasError)
                {
                    Console.WriteLine("{0} Errors", exceptionFilePath);
                    Console.WriteLine(errorText.ToString());
                }
            }
            return hasError;
        }

        public void Analyze(IEnumerable<string> cmdletProbingDirs, Func<IEnumerable<string>, IEnumerable<string>> directoryFilter, Func<string, bool> cmdletFilter)
        {
            throw new NotImplementedException();
        }

        public void Analyze(IEnumerable<string> cmdletProbingDirs, Func<IEnumerable<string>, IEnumerable<string>> directoryFilter, Func<string, bool> cmdletFilter, IEnumerable<string> modulesToAnalyze)
        {
            throw new NotImplementedException();
        }

        public AnalysisReport GetAnalysisReport()
        {
            throw new NotImplementedException();
        }
    }
}
